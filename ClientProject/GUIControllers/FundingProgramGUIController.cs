using ClientProject.Enums;
using ClientProject.UserControls;
using ClientProject.UserControls.Funding_Programs;
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

            if (lastUC is AdminStartupEventUC)
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
                HelperMethods.ShowErrorMessage(serverResponse.Exception.Message);
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

        private void ChangeToAdminPanel() => ChangeUC(new AdminFundingProgramUC());

        private void HandleSwitchButtonActivation()
        {
            _switchPanelButton.Visible = _isUserAdmin;
            _switchPanelButton.Text = SwitchToUserText;
            _switchPanelButton.Click += HandleSwitchButtonClick;
        }

        private void HandleSwitchButtonClick(object sender, EventArgs e)
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

        internal void AddFundingProgramPreview(FundingProgram fundingProgram, FlowLayoutPanel flowPanel)
        {
            var programPreviewUC = new FundingProgramPreviewUC(fundingProgram.Id, fundingProgram.Name, fundingProgram.Deadline, fundingProgram.FundingAmount);
            Button readMoreButton = programPreviewUC.GetReadMoreButton();
            readMoreButton.Click += ReadMoreButtonClicked;

            var panel = new Panel
            {
                Size = new System.Drawing.Size(230, 307)
            };

            programPreviewUC.Dock = DockStyle.Fill;
            panel.Controls.Add(programPreviewUC);

            flowPanel.Controls.Add(panel);
        }

        private void ReadMoreButtonClicked(object sender, EventArgs e)
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
                HelperMethods.ShowErrorMessage(response.exception.Message);
                return;
            }

            if(response.program == null)
            {
                Console.WriteLine("Program was null, returning.");
                return;
            }

            ChangeToSpecificFundingPanel(response.program);
        }

        private (FundingProgram program, Exception exception) GetFundingProgramById(int id)
        {
            var primaryKey = new Dictionary<string, int>() {{ "Id", id }};

            var response =  Communication.Instance.LoadFundingProgram(primaryKey);

            return ((FundingProgram)response.Result, response.Exception);
        }
    }
}
