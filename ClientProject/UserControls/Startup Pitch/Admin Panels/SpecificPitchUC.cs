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

namespace ClientProject.UserControls.Startup_Pitch.Admin_Panels
{
    public partial class SpecificPitchUC : UserControl
    {
        public Button BtnSendFeedback => btnSendFeedback;
        public Button BtnDownloadPitch => btnDownloadPitch;

        private StartupPitch _startupPitch;

        public SpecificPitchUC(StartupPitch startupPitch)
        {
            InitializeComponent();
            InitializeUI(startupPitch);

            _startupPitch = startupPitch; 
        }

        private void InitializeUI(StartupPitch startupPitch)
        {
            lblName.Text = startupPitch.Name;
            lblDescription.Text = startupPitch.Description;
        }

        public bool IsInputValid() => !String.IsNullOrEmpty(txtFeedback.Text);

        public StartupPitch GetFilledStartupPitch()
        {
            _startupPitch.Feedback = txtFeedback.Text;
            return _startupPitch;
        }
    }
}
