using ClientProject.Enums;
using ClientProject.UserControls;
using ClientProject.UserControls.Funding_Programs;
using ClientProject.UserControls.Funding_Programs.Admin_Panels;
using ClientProject.UserControls.Startup_Events;
using ClientProject.UserControls.Startup_Events.Admin_Panels;
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
    internal class StartupEventGUIController
    {
        private const string SwitchToAdminText = " Switch to Admin Panel";
        private const string SwitchToUserText = " Switch to User Panel";

        private List<StartupEvent> _startupEventsList;
        private Stack<UserControl> _userControlHistory;

        private Panel _mainPanel;
        private Button _switchPanelButton;

        private DeleteOrEditStartupEventUC _deleteOrEditUC;
        private EditStartupEventUC _editUC;
        private CreateStartupEventUC _createUC;

        private bool _isUserAdmin;
        private bool _isCurrentPanelUser;
        private SpecificEventUC _specificEventPanel;

        internal StartupEventsUC CreateStartupEventsUC()
        {
            var eventsUC = new StartupEventsUC();
            _userControlHistory = new Stack<UserControl>();

            _switchPanelButton = eventsUC.BtnSwitch;
            eventsUC.BtnBack.Click += LoadLastUC;

            _mainPanel = eventsUC.MainPanel;
            _mainPanel.Controls.Clear();

            _isUserAdmin = MainCoordinator.Instance.ConnectedUser.Role == UserRole.Admin;

            InitializeProperPanel();
            HandleSwitchButtonActivation();

            return eventsUC;
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
                ChangeToMainEventPanel();
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

            if(lastUC is AdminStartupEventUC)
            {
                _isCurrentPanelUser = false;
                _switchPanelButton.Text = SwitchToUserText;
            }

            if(lastUC is FlowPanelUC)
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

            if(_userControlHistory.Count == 0 || _userControlHistory.Peek().GetType() != control.GetType())
            {
                _userControlHistory.Push(control);
            }
        }

        private void ChangeToMainEventPanel()
        {
            var flowUC = new FlowPanelUC();
            ChangeUC(flowUC);

            var serverResponse = Communication.Instance.FindStartupEvents();

            if (serverResponse != null && serverResponse.Exception != null)
            {
                ShowErrorMessage(serverResponse.Exception.Message);
                return;
            }

            if (serverResponse == null || serverResponse.Result == null)
            {
                return;
            }

            _startupEventsList = serverResponse.Result as List<StartupEvent>;
            _startupEventsList.ForEach(e => AddEventPreview(e, flowUC.FlowPanel));
        }

        internal void ChangeToSpecificEventPanel(StartupEvent program)
        {
            _specificEventPanel = new SpecificEventUC(program);
            _specificEventPanel.BtnCreateEdit.Click += HandleCreateEventRegistrationClick;

            ChangeUC(_specificEventPanel);
        }

        private void HandleCreateEventRegistrationClick(object sender, EventArgs e)
        {
            ChangeUC(MainCoordinator.Instance.GetRegistrationUC(_specificEventPanel.SelectedStartupEvent));
        }

        private void ChangeToAdminPanel()
        {
            var adminPanel = new AdminStartupEventUC();
            adminPanel.BtnCreate.Click += HandleCreateClick;
            adminPanel.BtnEdit.Click += HandleOpenChooseEditPanelClick;
            adminPanel.BtnDelete.Click += HandleOpenChooseEditPanelClick;

            ChangeUC(adminPanel);
        }

        internal void AddEventPreview(StartupEvent startupEvent, FlowLayoutPanel flowPanel)
        {
            var eventPreviewUC = new EventPreviewUC(startupEvent.Id, startupEvent.Name, startupEvent.Date);
            Button readMoreButton = eventPreviewUC.GetReadMoreButton();
            readMoreButton.Click += HandleReadMoreClick;

            var panel = new Panel
            {
                Size = new System.Drawing.Size(230, 307)
            };

            eventPreviewUC.Dock = DockStyle.Fill;
            panel.Controls.Add(eventPreviewUC);

            flowPanel.Controls.Add(panel);
        }
        #endregion

        private void HandleSwitchButtonActivation()
        {
            _switchPanelButton.Visible = _isUserAdmin;
            _switchPanelButton.Text = SwitchToUserText;
            _switchPanelButton.Click += HandleSwitchClick;
        }

        private void HandleSwitchClick(object sender, EventArgs e)
        {
            if (_isCurrentPanelUser)
            {
                _switchPanelButton.Text = SwitchToUserText;
                ChangeToAdminPanel();
            }
            else
            {
                _switchPanelButton.Text = SwitchToAdminText;
                ChangeToMainEventPanel();
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
            var response = GetStartupEventById(id);

            if (response.exception != null)
            {
                ShowErrorMessage(response.exception.Message);
                return;
            }

            if (response.startupEvent == null)
            {
                Console.WriteLine("Startup event was null, returning.");
                return;
            }

            ChangeToSpecificEventPanel(response.startupEvent);
        }

        private void HandleCreateClick(object sender, EventArgs e)
        {
            _createUC = new CreateStartupEventUC();
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

            var response = CreateStartupEvent(_createUC.GetCreatedStartupEvent());

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
            var response = GetStartupEvents();

            if (response.exception != null)
            {
                ShowErrorMessage(response.exception.Message);
                return;
            }

            if (response.startupEvents == null)
            {
                ShowErrorMessage("Error getting the programs");
                return;
            }

            _deleteOrEditUC = new DeleteOrEditStartupEventUC(response.startupEvents);
            _deleteOrEditUC.BtnEdit.Click += HandleOpenEditPanelClick;
            _deleteOrEditUC.BtnDelete.Click += HandleDeleteEventClick;

            ChangeUC(_deleteOrEditUC);
        }

        private void HandleOpenEditPanelClick(object sender, EventArgs e)
        {
            var selectedProgram = _deleteOrEditUC.GetSelectedEvent();

            if (selectedProgram.exception != null)
            {
                ShowErrorMessage(selectedProgram.exception.Message);
                return;
            }

            _editUC = new EditStartupEventUC(selectedProgram.startupEvent);
            _editUC.BtnEdit.Click += HandleEditEventClick;

            ChangeUC(_editUC);
        }

        private void HandleEditEventClick(object sender, EventArgs e)
        {
            var validateInput = _editUC.IsInputValid();

            if (!validateInput.isValid)
            {
                ShowErrorMessage(validateInput.exception.Message);
                return;
            }

            var selectedEvent = _deleteOrEditUC.GetSelectedEvent();

            if (selectedEvent.exception != null)
            {
                ShowErrorMessage(selectedEvent.exception.Message);
                return;
            }

            StartupEvent startupEvent = _editUC.GetCreatedStartupEvent();
            startupEvent.Id = selectedEvent.startupEvent.Id;

            var response = EditStartupEvent(startupEvent);

            if (response.isSuccessful)
            {
                ShowInfoMessage("Successful edit!");
            }
            else
            {
                ShowErrorMessage(response.exception.Message);
            }
        }

        private void HandleDeleteEventClick(object sender, EventArgs e)
        {
            if(ShowYesNoMessage("Are you sure that you want to delete this startup event?") == DialogResult.No)
            {
                return;
            }

            var selectedEvent = _deleteOrEditUC.GetSelectedEvent();

            if (selectedEvent.exception != null)
            {
                ShowErrorMessage(selectedEvent.exception.Message);
                return;
            }

            var response = DeleteStartupEvent(selectedEvent.startupEvent);
            _deleteOrEditUC.Refresh();

            if (response.isSuccessful)
            {
                ShowInfoMessage("Successfully deleted!");
            }
            else
            {
                ShowErrorMessage(response.exception.Message);
            }
        }

        #region Database Methods
        private (StartupEvent startupEvent, Exception exception) GetStartupEventById(int id)
        {
            var primaryKey = new Dictionary<string, int>() { { "Id", id } };

            var response = Communication.Instance.LoadStartupEvent(primaryKey);

            return ((StartupEvent)response.Result, response.Exception);
        }

        private (List<StartupEvent> startupEvents, Exception exception) GetStartupEvents()
        {
            var response = Communication.Instance.FindStartupEvents();

            return (response.Result as List<StartupEvent>, response.Exception);
        }

        private (bool isSuccessful, Exception exception) CreateStartupEvent(StartupEvent startupEvent)
        {
            var response = Communication.Instance.CreateStartupEvent(startupEvent);
            bool isSuccessful = response.Exception == null;

            return (isSuccessful, response.Exception);
        }

        private (bool isSuccessful, Exception exception) EditStartupEvent(StartupEvent startupEvent)
        {
            var response = Communication.Instance.SaveStartupEvent(startupEvent);
            bool isSuccessful = response.Exception == null;

            return (isSuccessful, response.Exception);
        }

        private (bool isSuccessful, Exception exception) DeleteStartupEvent(StartupEvent startupEvent)
        {
            var response = Communication.Instance.DeleteStartupEvent(startupEvent);
            bool isSuccessful = response.Exception == null;

            return (isSuccessful, response.Exception);
        }
        #endregion
    }
}
