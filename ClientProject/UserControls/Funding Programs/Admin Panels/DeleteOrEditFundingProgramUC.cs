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

namespace ClientProject.UserControls.Funding_Programs.Admin_Panels
{
    public partial class DeleteOrEditFundingProgramUC : UserControl
    {
        public DeleteOrEditFundingProgramUC(List<FundingProgram> fundingPrograms)
        {
            InitializeComponent();
            InitializeDataGridView(fundingPrograms);
        }

        private void InitializeDataGridView(List<FundingProgram> fundingPrograms)
        {
            var bindingListOfPrograms = new BindingList<FundingProgram>(fundingPrograms);
            dgvResults.DataSource = bindingListOfPrograms;
        }

        public (FundingProgram, Exception) GetSelectedProgram()
        {
            if (dgvResults.CurrentRow == null)
            {
                return(null, new Exception("No row is currently selected."));
            }

            var selectedRow = dgvResults.CurrentRow;
            if (selectedRow.DataBoundItem is FundingProgram selectedProgram)
            {
                return (selectedProgram, null);
            }
            else
            {
                return (null, new Exception("The selected row is not valid."));
            }
        }
    }
}
