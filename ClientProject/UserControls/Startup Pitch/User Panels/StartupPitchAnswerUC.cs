using Common.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClientProject.UserControls.Startup_Pitch.User_Panels
{
    public partial class StartupPitchAnswerUC : UserControl
    {
        const string TitleForFeedback = "Feedback for the startup";
        const string TitleForWaiting = "Pitch was successfully sent. Awaiting feedback from the mentor...";

        StartupPitch _startupPitch;

        public StartupPitchAnswerUC(StartupPitch startupPitch)
        {
            InitializeComponent();

            _startupPitch = startupPitch;
            HandleStartingState();
        }

        private void HandleStartingState()
        {
            bool wasFeedbackSent = _startupPitch.Feedback != null;

            lblFeedback.Text = wasFeedbackSent ? TitleForFeedback : TitleForWaiting;
            txtFeedback.Enabled = false;
        }
    }
}
