using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClientProject.UserControls
{
    public partial class FundingProgramsUC : UserControl
    {
        public FundingProgramsUC()
        {
            InitializeComponent();
        }

        internal Panel MainPanel => panelMain;

        internal Button BtnBack => btnBack;

        internal Button BtnSwitch => btnSwitch;
    }
}
