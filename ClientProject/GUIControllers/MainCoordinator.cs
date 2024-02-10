using ClientProject.Forms;
using Common.Helpers;
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

        private Button _currentButton;
        private Color _selectedButtonColor = Color.FromArgb(97, 20, 203);
        private Color _defaultButtonColor = Color.FromArgb(142, 79, 216);

        public FrmLogin LoginForm { get; set; }
        public FrmRegistration RegistrationForm { get; set; }
        public FrmMain MainForm { get; set; }

        private EventRegistrationGUIController _registrationController;
        private FundingProgramGUIController _fundingController;
        private StartupEventGUIController _startupEventController;
        private UserGUIController _userController;

        private Label _titleLabel;
        private Panel _mainPanel;

        private MainCoordinator()
        {
            _registrationController = new EventRegistrationGUIController();
            _fundingController = new FundingProgramGUIController();
            _startupEventController = new StartupEventGUIController();
            _userController = new UserGUIController();
        }

        public void Initialize(Label titleLabel, Button homeButton, Panel mainPanel)
        {
            _titleLabel = titleLabel;
            _mainPanel = mainPanel;
            ActivateButton(homeButton);
        }

        private void ActivateButton(object buttonSender)
        {
            if (buttonSender == null || _currentButton == (Button)buttonSender) return;

            if(_currentButton != null)
                _currentButton.BackColor = _defaultButtonColor;

            _currentButton = (Button)buttonSender;
            _currentButton.BackColor = _selectedButtonColor;

            _titleLabel.Text = _currentButton.Text;
        }

        public void ChangePanel(Control control)
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

        internal void ShowFundingProgramsUC(object sender, EventArgs e)
        {
            ActivateButton(sender);
        }

        internal void ShowHomeUC(object sender, EventArgs e)
        {
            ActivateButton(sender);
        }

        internal void ShowStartupEventsUC(object sender, EventArgs e)
        {
            ActivateButton(sender);
        }
    }
}
