using ClientProject.Enums;
using ClientProject.UserControls;
using ClientProject.UserControls.Funding_Programs;
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
        private List<FundingProgram> _fundingProgramsList;
        private Panel _mainPanel;
        private ComboBox _selectedPanelComboBox;

        private bool _isUserAdmin;

        public FundingProgramsUC CreateFundingProgramsUC()
        {
            var fundingProgramsUC = new FundingProgramsUC();

            _selectedPanelComboBox = fundingProgramsUC.CmbSelectedPanel;
            _mainPanel = fundingProgramsUC.MainPanel;
            _mainPanel.Controls.Clear();

            _isUserAdmin = MainCoordinator.Instance.ConnectedUser.Role == UserRole.Admin;

            InitializeProperPanel();
            HandleComboBoxActivation();

            return fundingProgramsUC;
        }

        private void InitializeProperPanel()
        {
            if (_isUserAdmin)
            {
                ChangeUC(new AdminFundingProgramUC());
            }
            else
            {
                ChangeToMainFundingPanel();
            }
        }

        private void ChangeUC(UserControl control)
        {
            _mainPanel.Controls.Clear();
            control.Dock = DockStyle.Fill;
            _mainPanel.Controls.Add(control);
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

        private void HandleComboBoxActivation()
        {
            _selectedPanelComboBox.Visible = _isUserAdmin;
            _selectedPanelComboBox.DataSource = new BindingList<PanelType> { PanelType.AdminPanel, PanelType.UserPanel };
            _selectedPanelComboBox.SelectedIndexChanged += HandleComboBoxChanged;
        }

        private void HandleComboBoxChanged(object sender, EventArgs e)
        {
            if(_selectedPanelComboBox.SelectedIndex == (int)PanelType.AdminPanel)
            {
                ChangeToAdminPanel();
            }
            else
            {
                ChangeToMainFundingPanel();
            }
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
