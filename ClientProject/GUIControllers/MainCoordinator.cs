using ClientProject.Forms;
using ClientProject.UserControls;
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

        private EventRegistrationGUIController _registrationController;
        private FundingProgramGUIController _fundingController;
        private StartupEventGUIController _startupEventController;
        private UserGUIController _userController;

        private Label _titleLabel;
        private Panel _mainPanel;

        private bool _isAdministrator;

        private MainCoordinator()
        {
            _registrationController = new EventRegistrationGUIController();
            _fundingController = new FundingProgramGUIController();
            _startupEventController = new StartupEventGUIController();
            _userController = new UserGUIController();
        }

        internal void Initialize(Label titleLabel, Button homeButton, Panel mainPanel)
        {
            _titleLabel = titleLabel;
            _mainPanel = mainPanel;
            ActivateButton(homeButton);
            ChangePanel(new HomeUC());
        }

        private void ActivateButton(object buttonSender)
        {
            if (buttonSender == null || _currentButton == (IconButton)buttonSender) return;

            if(_currentButton != null)
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
    }
}
