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

namespace ClientProject.UserControls
{
    public partial class SpecificFundingProgramUC : UserControl
    {
        public SpecificFundingProgramUC(FundingProgram program)
        {
            InitializeComponent();
            InitializeUI(program);
        }

        private void InitializeUI(FundingProgram program)
        {
            lblAmount.Text = program.FundingAmount;
            lblProgramName.Text = program.Name;
            lblDescription.Text = program.Description;
            lblDate.Text = program.Deadline.ToString("f");
        }
    }
}
