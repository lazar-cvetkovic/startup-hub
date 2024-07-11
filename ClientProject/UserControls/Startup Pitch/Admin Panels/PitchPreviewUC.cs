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
    public partial class PitchPreviewUC : UserControl
    {
        public PitchPreviewUC(int id, string name)
        {
            InitializeComponent();

            lblName.Text = name;
            btnFeedback.Tag = id;
        }

        public Button BtnFeedback { get => btnFeedback; }
    }
}
