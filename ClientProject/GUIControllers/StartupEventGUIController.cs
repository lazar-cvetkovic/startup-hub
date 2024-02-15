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
    internal class StartupEventGUIController
    {
        private List<StartupEvent> _startupEventsList;
        private Panel _mainPanel;
        private ComboBox _selectedPanelComboBox;

        private bool _isUserAdmin;

        internal StartupEventsUC CreateStartupEventsUC()
        {
            var eventsUC = new StartupEventsUC();

            _selectedPanelComboBox = eventsUC.SelectedPanelCmb;
            _mainPanel = eventsUC.MainPanel;
            _mainPanel.Controls.Clear();

            _isUserAdmin = MainCoordinator.Instance.ConnectedUser.Role == UserRole.Admin;

            InitializeProperPanel();
            HandleComboBoxActivation();

            return eventsUC;
        }

        private void InitializeProperPanel()
        {
            if (_isUserAdmin)
            {
                ChangeUC(new AdminStartupEventUC());
            }
            else
            {
                ChangeToMainEventPanel();
            }
        }

        private void ChangeUC(UserControl control)
        {
            _mainPanel.Controls.Clear();
            control.Dock = DockStyle.Fill;
            _mainPanel.Controls.Add(control);
        }

        private void ChangeToMainEventPanel()
        {
            var flowUC = new FlowPanelUC();
            ChangeUC(flowUC);

            var serverResponse = Communication.Instance.FindStartupEvents();

            if (serverResponse != null && serverResponse.Exception != null)
            {
                HelperMethods.ShowErrorMessage(serverResponse.Exception.Message);
                return;
            }

            if (serverResponse == null || serverResponse.Result == null)
            {
                return;
            }

            _startupEventsList = serverResponse.Result as List<StartupEvent>;
            _startupEventsList.ForEach(e => AddEventPreview(e, flowUC.FlowPanel));
        }

        internal void ChangeToSpecificEventPanel(StartupEvent program) => ChangeUC(new SpecificEventUC(program));

        private void ChangeToAdminPanel() => ChangeUC(new AdminStartupEventUC());

        private void HandleComboBoxActivation()
        {
            _selectedPanelComboBox.Visible = _isUserAdmin;
            _selectedPanelComboBox.DataSource = new BindingList<PanelType> { PanelType.AdminPanel, PanelType.UserPanel };
            _selectedPanelComboBox.SelectedIndexChanged += HandleComboBoxChanged;
        }

        private void HandleComboBoxChanged(object sender, EventArgs e)
        {
            if (_selectedPanelComboBox.SelectedIndex == (int)PanelType.AdminPanel)
            {
                ChangeToAdminPanel();
            }
            else
            {
                ChangeToMainEventPanel();
            }
        }


        internal SpecificEventUC CreateSpecificEventUC(StartupEvent startupEvent) => new SpecificEventUC(startupEvent);

        internal void AddEventPreview(StartupEvent startupEvent, FlowLayoutPanel flowPanel)
        {
            var eventPreviewUC = new EventPreviewUC(startupEvent.Id, startupEvent.Name, startupEvent.Date);
            Button readMoreButton = eventPreviewUC.GetReadMoreButton();
            readMoreButton.Click += ReadMoreButtonClicked;

            var panel = new Panel
            {
                Size = new System.Drawing.Size(230, 307)
            };

            eventPreviewUC.Dock = DockStyle.Fill;
            panel.Controls.Add(eventPreviewUC);

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
            var response = GetStartupEventById(id);

            if (response.exception != null)
            {
                HelperMethods.ShowErrorMessage(response.exception.Message);
                return;
            }

            if (response.startupEvent == null)
            {
                Console.WriteLine("Startup event was null, returning.");
                return;
            }

            ChangeToSpecificEventPanel(response.startupEvent);
        }

        private (StartupEvent startupEvent, Exception exception) GetStartupEventById(int id)
        {
            var primaryKey = new Dictionary<string, int>() { { "Id", id } };

            var response = Communication.Instance.LoadStartupEvent(primaryKey);

            return ((StartupEvent)response.Result, response.Exception);
        }
    }
}
