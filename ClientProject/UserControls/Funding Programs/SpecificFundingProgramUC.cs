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
    public partial class SpecificFundingProgramUC : UserControl
    {
        public SpecificFundingProgramUC(string programName, DateTime dateTime, string fundingAmount, string description)
        {
            InitializeComponent();
            InitializeUI(programName, dateTime, fundingAmount, description);
        }

        private void InitializeUI(string programName, DateTime dateTime, string fundingAmount, string description)
        {
            lblAmount.Text = fundingAmount;
            lblProgramName.Text = programName;
            lblDescription.Text = description;
            lblDate.Text = dateTime.ToString("f");
        }
    }
}
