using ClientProject.Forms;
using ClientProject.UserControls;
using Common.Domain;
using Common.Helpers;
using FontAwesome.Sharp;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Common.Helpers.HelperMethods;

namespace ClientProject.GUIControllers
{
    internal class MainCoordinator
    {
        private static MainCoordinator _instance;
        public static MainCoordinator Instance
        {
            get
            {
                _instance = _instance ?? new MainCoordinator();
                return _instance;
            }
        }

        private IconButton _currentButton;
        private Color _selectedButtonColor = Color.FromArgb(37, 36, 81);
        private Color _defaultButtonColor = Color.FromArgb(31, 30, 68);

        public FrmLogin LoginForm { get; set; }
        public FrmRegistration RegistrationForm { get; set; }
        public FrmMain MainForm { get; set; }
        public User ConnectedUser { get; set; }

        private EventRegistrationGUIController _registrationController;
        private FundingProgramGUIController _fundingController;
        private StartupEventGUIController _startupEventController;
        private UserGUIController _userController;
        private StartupPitchGUIController _startupPitchController;

        private Label _titleLabel;
        private Panel _mainPanel;
        private Form _currentForm;

        private MainCoordinator()
        {
            _registrationController = new EventRegistrationGUIController();
            _fundingController = new FundingProgramGUIController();
            _startupEventController = new StartupEventGUIController();
            _userController = new UserGUIController();
            _startupPitchController = new StartupPitchGUIController();
        }

        internal void InitializeMainForm(Label titleLabel, Button homeButton, Panel mainPanel, Button yourStartup)
        {
            _titleLabel = titleLabel;
            _mainPanel = mainPanel;
            bool isAdmin = ConnectedUser.Role == Common.Enums.UserRole.Admin;
            yourStartup.Text = isAdmin ? "All startups" : "Your startup";
            ActivateButton(homeButton);
            ChangePanel(new HomeUC());
        }

        internal void InitializeLoginForm(FrmLogin loginForm)
        {
            loginForm.ShowRegisterFormButton.Click += ShowRegisterForm;
            _userController.InitializeLoginForm(loginForm);
        }

        internal void InitializeRegistrationForm(FrmRegistration registrationForm)
        {
            registrationForm.ShowLoginFormButton.Click += ShowLoginForm;
            _userController.InitializeRegistrationForm(registrationForm);
        }

        private void ActivateButton(object buttonSender)
        {
            if (buttonSender == null || _currentButton == (IconButton)buttonSender) return;

            if (_currentButton != null)
            {
                _currentButton.BackColor = _defaultButtonColor;
                _currentButton.IconColor = Color.Gainsboro;
            }

            _currentButton = (IconButton)buttonSender;
            _currentButton.BackColor = _selectedButtonColor;
            _currentButton.IconColor = Color.Aquamarine;

            _titleLabel.Text = _currentButton.Text.Trim().ToLower();
        }

        internal void ChangePanel(Control control)
        {
            try
            {
                _mainPanel.Controls.Clear();
                _mainPanel.Controls.Add(control);
                control.Dock = DockStyle.Fill;
            }
            catch (Exception ex)
            {
                ShowErrorMessage(ex.Message);
            }
        }

        private void ChangeForms(Form newForm)
        {
            if (newForm == null || _currentForm == newForm)
            {
                return;
            }

            newForm.Show();
            _currentForm?.Close();
            _currentForm = newForm;
        }

        internal void ShowLoginForm(object sender, EventArgs e) => ShowLoginForm();
        internal void ShowLoginForm() => ChangeForms(new FrmLogin());

        internal void ShowRegisterForm(object sender, EventArgs e) => ShowRegisterForm();
        internal void ShowRegisterForm() => ChangeForms(new FrmRegistration());

        internal void ShowMainForm(object sender, EventArgs e) => ShowMainForm();
        internal void ShowMainForm() => ChangeForms(new FrmMain());

        internal void ShowHomeUC(object sender, EventArgs e)
        {
            ActivateButton(sender);
            ChangePanel(new HomeUC());
        }

        internal void ShowStartupEventsUC(object sender, EventArgs e)
        {
            ActivateButton(sender);
            ChangePanel(_startupEventController.CreateStartupEventsUC());
        }

        internal void ShowFundingProgramsUC(object sender, EventArgs e)
        {
            ActivateButton(sender);
            ChangePanel(_fundingController.CreateFundingProgramsUC());
        }

        internal void ShowStartupPitchUC(object sender, EventArgs e)
        {
            ActivateButton(sender);
            ChangePanel(_startupPitchController.CreateStartupPitchUC());
        }

        internal StartupEventRegistrationUC GetRegistrationUC(StartupEvent startupEvent) => _registrationController.CreateStartupEventRegistrationUC(startupEvent);
    }
}
