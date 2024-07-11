using ClientProject.UserControls;
using ClientProject.UserControls.Funding_Programs;
using ClientProject.UserControls.Startup_Pitch;
using ClientProject.UserControls.Startup_Pitch.Admin_Panels;
using ClientProject.UserControls.Startup_Pitch.User_Panels;
using Common.Domain;
using Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Common.Helpers.HelperMethods;

namespace ClientProject.GUIControllers
{
    internal class StartupPitchGUIController
    {
        private Panel _mainPanel;
        private SpecificPitchUC _specificPitchPanel;

        private bool _isUserAdmin;
        private CreateStartupPitchUC _createPitchPanel;

        internal Control CreateStartupPitchUC()
        {
            _isUserAdmin = MainCoordinator.Instance.ConnectedUser.Role == UserRole.Admin;

            var pitchUC = new StartupPitchUC();
            _mainPanel = pitchUC.MainPanel;

            if (_isUserAdmin)
            {
                SetupAdmin();
            }
            else
            {
                SetupUser();
            }

            return pitchUC;
        }

        private void SetupAdmin()
        {
            var flowUC = new FlowPanelUC();
            ChangeUC(flowUC);

            var response = GetStartupPitches();

            if(response.exception != null)
            {
                ShowErrorMessage(response.exception.Message);
                return;
            }

            List<StartupPitch> startupPitchesList = response.startupPitches;

            if(startupPitchesList == null)
            {
                return;
            }

            startupPitchesList.ForEach(e => AddPitchPreview(e, flowUC.FlowPanel));
        }

        private void SetupUser()
        {
            var response = GetStartupPitchByColumn("UserId", MainCoordinator.Instance.ConnectedUser.Id);

            if (response.exception != null)
            {
                ShowErrorMessage(response.exception.Message);
                return;
            }

            bool wasPitchSent = response.startupPitch != null;

            if (wasPitchSent)
            {
                ChangeToPitchAnswerUC(response.startupPitch);
            }
            else
            {
                ChangeToCreatePitchUC();
            }
        }

        private void ChangeToPitchAnswerUC(StartupPitch startupPitch)
        {
            var pitchAnswerUC = new StartupPitchAnswerUC(startupPitch);
            ChangeUC(pitchAnswerUC);
        }

        private void ChangeToCreatePitchUC()
        {
            _createPitchPanel = new CreateStartupPitchUC();
            _createPitchPanel.BtnSend.Click += HandleSendPitchClick;

            ChangeUC(_createPitchPanel);
        }

        private void ChangeUC(UserControl control)
        {
            _mainPanel.Controls.Clear();
            control.Dock = DockStyle.Fill;
            _mainPanel.Controls.Add(control);
        }

        internal void AddPitchPreview(StartupPitch startupPitch, FlowLayoutPanel flowPanel)
        {
            var eventPreviewUC = new PitchPreviewUC(startupPitch.Id, startupPitch.Name);
            Button giveFeedbackBtn = eventPreviewUC.BtnFeedback;
            giveFeedbackBtn.Click += HandleReadMoreClick;

            var panel = new Panel
            {
                Size = new System.Drawing.Size(230, 307)
            };

            eventPreviewUC.Dock = DockStyle.Fill;
            panel.Controls.Add(eventPreviewUC);

            flowPanel.Controls.Add(panel);
        }

        internal void ChangeToSpecificEventPanel(StartupPitch pitch)
        {
            _specificPitchPanel = new SpecificPitchUC(pitch);
            _specificPitchPanel.BtnSendFeedback.Click += HandleSendFeedbackClick;

            ChangeUC(_specificPitchPanel);
        }

        private void HandleReadMoreClick(object sender, EventArgs e)
        {
            Button button = sender as Button;

            if (button == null)
            {
                return;
            }

            int id = (int)button.Tag;
            var response = GetStartupPitchByColumn("Id", id);

            if (response.exception != null)
            {
                ShowErrorMessage(response.exception.Message);
                return;
            }

            if (response.startupPitch == null)
            {
                Console.WriteLine("Startup event was null, returning.");
                return;
            }

            ChangeToSpecificEventPanel(response.startupPitch);
        }

        private void HandleSendFeedbackClick(object sender, EventArgs e)
        {
            if (!_specificPitchPanel.IsInputValid())
            {
                ShowErrorMessage("Feedback is empty.");
                return;
            }

            StartupPitch startupPitch = _specificPitchPanel.GetFilledStartupPitch();

            var response = EditStartupPitch(startupPitch);

            if (response.isSuccessful)
            {
                ShowInfoMessage("Feedback has been successfully sent!");
                SetupAdmin();
            }
            else
            {
                ShowErrorMessage(response.exception.Message);
            }
        }

        private void HandleSendPitchClick(object sender, EventArgs e)
        {
            var validateInput = _createPitchPanel.IsInputValid();

            if (!validateInput.isValid)
            {
                ShowErrorMessage(validateInput.exception.Message);
                return;
            }

            var response = CreateStartupPitch(_createPitchPanel.GetCreatedStartupPitch());
            if (response.isSuccessful)
            {
                ShowInfoMessage("Successfully created!");
                SetupUser();
            }
            else
            {
                ShowErrorMessage(response.exception.Message);
            }
        }

        #region Database Methods
        private (StartupPitch startupPitch, Exception exception) GetStartupPitchByColumn(string columnName, object cellValue)
        {
            var searchParameters = new Dictionary<string, object>()
            {
                { columnName, cellValue }
            };

            var response = Communication.Instance.LoadStartupPitch(searchParameters);

            return ((StartupPitch)response.Result, response.Exception);
        }

        private (List<StartupPitch> startupPitches, Exception exception) GetStartupPitches()
        {
            var response = Communication.Instance.FindStartupPitches();

            return (response.Result as List<StartupPitch>, response.Exception);
        }

        private (bool isSuccessful, Exception exception) CreateStartupPitch(StartupPitch startupPitch)
        {
            var response = Communication.Instance.CreateStartupPitch(startupPitch);
            bool isSuccessful = response.Exception == null;

            return (isSuccessful, response.Exception);
        }

        private (bool isSuccessful, Exception exception) EditStartupPitch(StartupPitch startupPitch)
        {
            var response = Communication.Instance.SaveStartupPitch(startupPitch);
            bool isSuccessful = response.Exception == null;

            return (isSuccessful, response.Exception);
        }
        #endregion
    }
}
