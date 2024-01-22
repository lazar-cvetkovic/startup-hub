using ClientProject.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public FrmLogin LoginForm { get; set; }
        public FrmRegistration RegistrationForm { get; set; }
        public FrmMain MainForm { get; set; }

        private EventRegistrationGUIController _registrationController;
        private FundingProgramGUIController _fundingController;
        private StartupEventGUIController _startupEventController;
        private UserGUIController _userController;

        private MainCoordinator()
        {
            _registrationController = new EventRegistrationGUIController();
            _fundingController = new FundingProgramGUIController();
            _startupEventController = new StartupEventGUIController();
            _userController = new UserGUIController();
        }
    }
}
