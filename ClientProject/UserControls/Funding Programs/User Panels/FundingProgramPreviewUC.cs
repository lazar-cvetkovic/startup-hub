using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClientProject.UserControls.Funding_Programs
{
    public partial class FundingProgramPreviewUC : UserControl
    {
        public FundingProgramPreviewUC(int id, string eventName, DateTime dateTime, string fundingAmount)
        {
            InitializeComponent();

            lblProgramName.Text = eventName;
            lblDate.Text = dateTime.ToString("f");
            lblAmount.Text = fundingAmount;
            btnReadMore.Tag = id;
        }

        public Button GetReadMoreButton() => btnReadMore;
    }
}
