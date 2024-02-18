using ClientProject.UserControls;
using Common.Domain;
using Common.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientProject.GUIControllers
{
    internal class EventRegistrationGUIController
    {
        private StartupEvent _startupEvent;
        private List<RegisteredQuestion> _registeredQuestions;
        private StartupEventRegistrationUC _registrationUC;

        private bool _isRegistrationAlreadyCreated;
        private int _startupEventId;

        public StartupEventRegistrationUC CreateStartupEventRegistrationUC(StartupEvent startupEvent)
        {
            StartupEventRegistration registration = GetRegistration(startupEvent);
            _startupEventId = startupEvent.Id; 

            _isRegistrationAlreadyCreated = registration != null;
            List<RegisteredQuestion> registeredQuestions = new List<RegisteredQuestion>();

            if (_isRegistrationAlreadyCreated)
            {
                registeredQuestions = GetQuestions(startupEvent, registration);
            }

            _registrationUC = new StartupEventRegistrationUC(_isRegistrationAlreadyCreated, _startupEventId, registration, registeredQuestions);
            _registrationUC.BtnConfirm.Click += HandleConfirmationClick;

            return _registrationUC;
        }
        
        private void HandleConfirmationClick(object sender, EventArgs e)
        {
            if (_isRegistrationAlreadyCreated)
            {
                HandleEditingConfirmation();
            }
            else
            {
                HandleCreatingConfirmation();
            }
        }

        private void HandleCreatingConfirmation()
        {
            FullRegistration fullRegistration = _registrationUC.GetFullRegistration();
            var response = Communication.Instance.CreateEventRegistration(fullRegistration);

            if(response.Exception == null)
            {
                HelperMethods.ShowInfoMessage("Successfully created the registration!");
            }
            else
            {
                HelperMethods.ShowErrorMessage(response.Exception.Message);
            }
        }

        private void HandleEditingConfirmation()
        {
            FullRegistration fullRegistration = _registrationUC.GetFullRegistration();
            var response = Communication.Instance.SaveEventRegistration(fullRegistration);

            if (response.Exception == null)
            {
                HelperMethods.ShowInfoMessage("Successfully edited the registration!");
            }
            else
            {
                HelperMethods.ShowErrorMessage(response.Exception.Message);
            }
        }

        #region Database Methods
        private StartupEventRegistration GetRegistration(StartupEvent startupEvent)
        {
            var keyDictionary = new Dictionary<string, int>()
            {
                { "UserId", MainCoordinator.Instance.ConnectedUser.Id },
                { "EventId", startupEvent.Id }
            };

            var response = Communication.Instance.LoadEventRegistration(keyDictionary);

            return (StartupEventRegistration)response.Result;
        }
        
        private List<RegisteredQuestion> GetQuestions(StartupEvent startupEvent, StartupEventRegistration registration)
        {
            var keyDictionary = new Dictionary<string, int>()
            {
                { "UserId", MainCoordinator.Instance.ConnectedUser.Id },
                { "EventId", startupEvent.Id }
            };

            var response = Communication.Instance.LoadStartupEventQuestions(keyDictionary);

            return response.Result as List<RegisteredQuestion>;
        }
        #endregion
    }
}
