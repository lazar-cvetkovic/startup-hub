using ClientProject.Enums;
using ClientProject.UserControls;
using ClientProject.UserControls.Funding_Programs;
using ClientProject.UserControls.Funding_Programs.Admin_Panels;
using ClientProject.UserControls.Startup_Events;
using Common.Domain;
using Common.Enums;
using Common.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Common.Helpers.HelperMethods;

namespace ClientProject.GUIControllers
{
    internal class FundingProgramGUIController
    {
        private const string SwitchToAdminText = " Switch to Admin Panel";
        private const string SwitchToUserText = " Switch to User Panel";

        private List<FundingProgram> _fundingProgramsList;
        private Stack<UserControl> _userControlHistory;

        private Panel _mainPanel;
        private Button _switchPanelButton;
        private ChooseEditFundingProgramUC _chooseEditUC;
        private EditFundingProgramUC _editUC;
        private CreateFundingProgramUC _createUC;

        private bool _isUserAdmin;
        private bool _isCurrentPanelUser;

        public FundingProgramsUC CreateFundingProgramsUC()
        {
            var fundingProgramsUC = new FundingProgramsUC();
            _userControlHistory = new Stack<UserControl>();

            _switchPanelButton = fundingProgramsUC.BtnSwitch;
            fundingProgramsUC.BtnBack.Click += LoadLastUC;

            _mainPanel = fundingProgramsUC.MainPanel;
            _mainPanel.Controls.Clear();

            _isUserAdmin = MainCoordinator.Instance.ConnectedUser.Role == UserRole.Admin;

            InitializeProperPanel();
            HandleSwitchButtonActivation();

            return fundingProgramsUC;
        }

        #region UC Changing Logic
        private void InitializeProperPanel()
        {
            if (_isUserAdmin)
            {
                ChangeToAdminPanel();
            }
            else
            {
                ChangeToMainFundingPanel();
            }
        }

        private void LoadLastUC(object sender, EventArgs e)
        {
            if (_userControlHistory.Count == 1 || _userControlHistory.Count == 0)
            {
                return;
            }

            _userControlHistory.Pop();
            var lastUC = _userControlHistory.Peek();

            ChangeUC(lastUC);

            if (lastUC is AdminFundingProgramUC)
            {
                _isCurrentPanelUser = false;
                _switchPanelButton.Text = SwitchToUserText;
            }

            if (lastUC is FlowPanelUC)
            {
                _isCurrentPanelUser = true;
                _switchPanelButton.Text = SwitchToAdminText;
            }
        }

        private void ChangeUC(UserControl control)
        {
            _mainPanel.Controls.Clear();
            control.Dock = DockStyle.Fill;
            _mainPanel.Controls.Add(control);

            if (_userControlHistory.Count == 0 || _userControlHistory.Peek().GetType() != control.GetType())
            {
                _userControlHistory.Push(control);
            }
        }

        private void ChangeToMainFundingPanel()
        {
            var flowUC = new FlowPanelUC();
            ChangeUC(flowUC);

            var serverResponse = Communication.Instance.FindFundingPrograms();

            if (serverResponse != null && serverResponse.Exception != null)
            {
                ShowErrorMessage(serverResponse.Exception.Message);
                return;
            }

            if (serverResponse == null || serverResponse.Result == null)
            {
                return;
            }

            _fundingProgramsList = serverResponse.Result as List<FundingProgram>;
            _fundingProgramsList.ForEach(p => AddFundingProgramPreview(p, flowUC.FlowPanel));
        }

        internal void ChangeToSpecificFundingPanel(FundingProgram program) => ChangeUC(new SpecificFundingProgramUC(program));

        private void ChangeToAdminPanel()
        {
            var adminPanel = new AdminFundingProgramUC();
            adminPanel.BtnCreate.Click += HandleCreateClick;
            adminPanel.BtnEdit.Click += HandleOpenChooseEditPanelClick;

            ChangeUC(adminPanel);
        }

        internal void AddFundingProgramPreview(FundingProgram fundingProgram, FlowLayoutPanel flowPanel)
        {
            var programPreviewUC = new FundingProgramPreviewUC(fundingProgram.Id, fundingProgram.Name, fundingProgram.Deadline, fundingProgram.FundingAmount);
            Button readMoreButton = programPreviewUC.GetReadMoreButton();
            readMoreButton.Click += HandleReadMoreClick;

            var panel = new Panel
            {
                Size = new System.Drawing.Size(230, 307)
            };

            programPreviewUC.Dock = DockStyle.Fill;
            panel.Controls.Add(programPreviewUC);

            flowPanel.Controls.Add(panel);
        }
        #endregion

        #region Button Event Handling
        private void HandleSwitchButtonActivation()
        {
            _switchPanelButton.Visible = _isUserAdmin;
            _switchPanelButton.Text = SwitchToUserText;
            _switchPanelButton.Click += HandleSwitchClick;
        }

        private void HandleSwitchClick(object sender, EventArgs e)
        {
            if(_isCurrentPanelUser)
            {
                _switchPanelButton.Text = SwitchToAdminText;
                ChangeToAdminPanel();
            }
            else
            {
                _switchPanelButton.Text = SwitchToUserText;
                ChangeToMainFundingPanel();
            }

            _isCurrentPanelUser = !_isCurrentPanelUser;
        }

        private void HandleReadMoreClick(object sender, EventArgs e)
        {
            Button button = sender as Button;

            if (button == null)
            {
                return;
            }

            int id = (int)button.Tag;
            var response = GetFundingProgramById(id);

            if(response.exception != null)
            {
                ShowErrorMessage(response.exception.Message);
                return;
            }

            if(response.program == null)
            {
                Console.WriteLine("Program was null, returning.");
                return;
            }

            ChangeToSpecificFundingPanel(response.program);
        }

        private void HandleCreateClick(object sender, EventArgs e)
        {
            _createUC = new CreateFundingProgramUC();
            _createUC.BtnCreate.Click += HandleCreatePanelClick;

            ChangeUC(_createUC);
        }

        private void HandleCreatePanelClick(object sender, EventArgs e)
        {
            var validateInput = _createUC.IsInputValid();

            if (!validateInput.isValid)
            {
                ShowErrorMessage(validateInput.exception.Message);
                return;
            }

            var response = CreateFundingProgram(_createUC.GetCreatedFundingProgram());

            if (response.isSuccessful)
            {
                ShowInfoMessage("Successfully created!");
            }
            else
            {
                ShowErrorMessage(response.exception.Message);
            }
        }

        private void HandleOpenChooseEditPanelClick(object sender, EventArgs e)
        {
            var response = GetFundingPrograms();

            if(response.exception != null)
            {
                ShowErrorMessage(response.exception.Message);     
                return;
            }

            if (response.programs == null)
            {
                ShowErrorMessage("Error getting the programs");
                return;
            }

            _chooseEditUC = new ChooseEditFundingProgramUC(response.programs);
            _chooseEditUC.BtnEdit.Click += HandleOpenEditPanelClick;

            ChangeUC(_chooseEditUC);
        }

        private void HandleOpenEditPanelClick(object sender, EventArgs e)
        {
            var selectedProgram = _chooseEditUC.GetSelectedProgram();

            if(selectedProgram.exception != null)
            {
                ShowErrorMessage(selectedProgram.exception.Message);
                return;
            }

            _editUC = new EditFundingProgramUC(selectedProgram.program);
            _editUC.BtnEdit.Click += HandleEditProgramClick;

            ChangeUC(_editUC);
        }

        private void HandleEditProgramClick(object sender, EventArgs e)
        {
            var validateInput = _editUC.IsInputValid();

            if (!validateInput.isValid)
            {
                ShowErrorMessage(validateInput.exception.Message);
                return;
            }

            var selectedProgram = _chooseEditUC.GetSelectedProgram();

            if (selectedProgram.exception != null)
            {
                ShowErrorMessage(selectedProgram.exception.Message);
                return;
            }

            FundingProgram changedProgram = _editUC.GetCreatedFundingProgram();
            changedProgram.Id = selectedProgram.program.Id;

            var response = EditFundingProgram(changedProgram);

            if (response.isSuccessful)
            {
                ShowInfoMessage("Successful edit!");
            }
            else
            {
                ShowErrorMessage(response.exception.Message);
            }
        }
        #endregion

        #region Database Methods
        private (FundingProgram program, Exception exception) GetFundingProgramById(int id)
        {
            var primaryKey = new Dictionary<string, int>() {{ "Id", id }};

            var response =  Communication.Instance.LoadFundingProgram(primaryKey);

            return ((FundingProgram)response.Result, response.Exception);
        }

        private (List<FundingProgram> programs, Exception exception) GetFundingPrograms()
        {
            var response = Communication.Instance.FindFundingPrograms();

            return (response.Result as List<FundingProgram>, response.Exception);
        }

        private (bool isSuccessful, Exception exception) CreateFundingProgram(FundingProgram fundingProgram)
        {
            var response = Communication.Instance.CreateFundingProgram(fundingProgram);
            bool isSuccessful = response.Exception == null;

            return (isSuccessful, response.Exception);
        }

        private (bool isSuccessful, Exception exception) EditFundingProgram(FundingProgram fundingProgram)
        {
            var response = Communication.Instance.SaveFundingProgram(fundingProgram);
            bool isSuccessful = response.Exception == null;

            return (isSuccessful, response.Exception);
        }
        #endregion
    }
}
