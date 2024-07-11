using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClientProject.UserControls.Startup_Pitch
{
    public partial class StartupPitchUC : UserControl
    {
        public StartupPitchUC()
        {
            InitializeComponent();
        }

        internal Panel MainPanel => panelMain;
    }
}
