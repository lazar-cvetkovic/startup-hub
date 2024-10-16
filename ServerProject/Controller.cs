﻿using Common.Domain;
using Common.Helpers;
using DatabaseBroker;
using ServerProject.SystemOperations;
using ServerProject.SystemOperations.Create;
using ServerProject.SystemOperations.Find;
using ServerProject.SystemOperations.Load;
using ServerProject.SystemOperations.Save;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerProject
{
    internal class Controller
    {
        private static Controller _instance = null;
        private static readonly object _lock = new object();

        public static Controller Instance
        {
            get
            {
                lock (_lock)
                {
                    _instance = _instance ?? new Controller();
                    return _instance;
                }
            }
        }

        private Broker _broker;

        private Controller()
        {
            try
            {
                _broker = new Broker();

            }
            catch (Exception e)
            {
                HelperMethods.ShowErrorMessage(e.Message);
            }        
        }

        internal User Login(User argument)
        {
            var systemOperation = new LoginUserSO(argument);
            systemOperation.ExecuteTemplate();

            return systemOperation.Result;
        }

        #region INSERT Operations
        internal void CreateEventRegistration(FullRegistration argument)
        {
            var systemOperation = new CreateEventRegistrationSO(argument);
            systemOperation.ExecuteTemplate();
        }

        internal void CreateFundingProgram(FundingProgram argument)
        {
            var systemOperation = new CreateFundingProgramSO(argument);
            systemOperation.ExecuteTemplate();
        }

        internal void CreateStartupEvent(StartupEvent argument)
        {
            var systemOperation = new CreateStartupEventSO(argument);
            systemOperation.ExecuteTemplate();
        }

        internal void CreateUser(User argument)
        {
            var systemOperation = new CreateUserSO(argument);
            systemOperation.ExecuteTemplate();
        }

        internal void CreateStartupPitch(StartupPitch argument)
        {
            var systemOperation = new CreateStartupPitchSO(argument);
            systemOperation.ExecuteTemplate();
        }

        #endregion

        #region SELECT Operations
        internal List<StartupEventRegistration> FindEventRegistrations()
        {
            var systemOperation = new FindEventRegistrationsSO();
            systemOperation.ExecuteTemplate();

            return systemOperation.Result;
        }

        internal List<FundingProgram> FindFundingPrograms()
        {
            var systemOperation = new FindFundingProgramsSO();
            systemOperation.ExecuteTemplate();

            return systemOperation.Result;
        }

        internal List<StartupEvent> FindStartupEvents()
        {
            var systemOperation = new FindStartupEventsSO();
            systemOperation.ExecuteTemplate();

            return systemOperation.Result;
        }

        internal List<StartupPitch> FindStartupPitches()
        {
            var systemOperation = new FindStartupPitchesSO();
            systemOperation.ExecuteTemplate();

            return systemOperation.Result;
        }


        internal List<RegisteredQuestion> LoadStartupEventQuestions(Dictionary<string, int> argument)
        {
            var systemOperation = new LoadStartupEventQuestionsSO(argument);
            systemOperation.ExecuteTemplate();

            return systemOperation.Result;
        }

        internal StartupEventRegistration LoadEventRegistration(Dictionary<string, int> argument)
        {
            var systemOperation = new LoadEventRegistrationSO(argument);
            systemOperation.ExecuteTemplate();

            return systemOperation.Result;
        }

        internal FundingProgram LoadFundingProgram(Dictionary<string, int> argument)
        {
            var systemOperation = new LoadFundingProgramSO(argument);
            systemOperation.ExecuteTemplate();

            return systemOperation.Result;
        }

        internal StartupEvent LoadStartupEvent(Dictionary<string, int> argument)
        {
            var systemOperation = new LoadStartupEventSO(argument);
            systemOperation.ExecuteTemplate();

            return systemOperation.Result;
        }

        internal StartupPitch LoadStartupPitch(Dictionary<string, object> argument)
        {
            var systemOperation = new LoadStartupPitchSO(argument);
            systemOperation.ExecuteTemplate();

            return systemOperation.Result;
        }
        #endregion

        #region UPDATE Operations
        internal void SaveEventRegistration(FullRegistration argument)
        {
            var systemOperation = new SaveEventRegistrationSO(argument);
            systemOperation.ExecuteTemplate();
        }

        internal void SaveFundingProgram(FundingProgram argument)
        {
            var systemOperation = new SaveFundingProgramSO(argument);
            systemOperation.ExecuteTemplate();
        }

        internal void SaveStartupEvent(StartupEvent argument)
        {
            var systemOperation = new SaveStartupEventSO(argument);
            systemOperation.ExecuteTemplate();
        }

        internal void SaveUser(User argument)
        {
            var systemOperation = new SaveUserSO(argument);
            systemOperation.ExecuteTemplate();
        }

        internal void SaveStartupPitch(StartupPitch argument)
        {
            var systemOperation = new SaveStartupPitchSO(argument);
            systemOperation.ExecuteTemplate();
        }
        #endregion

        #region DELETE Operations
        internal void DeleteStartupEvent(StartupEvent argument)
        {
            var systemOperation = new DeleteStartupEventSO(argument);
            systemOperation.ExecuteTemplate();
        }
        #endregion
    }
}
