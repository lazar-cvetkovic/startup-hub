using ClientProject.GUIControllers;
using Common.Domain;
using Common.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClientProject.UserControls.Funding_Programs.Admin_Panels
{
    public partial class EditFundingProgramUC : UserControl
    {
        public EditFundingProgramUC(FundingProgram fundingProgram)
        {
            InitializeComponent();
            InitializeFields(fundingProgram);
        }

        private void InitializeFields(FundingProgram fundingProgram)
        {
            txtName.Name = fundingProgram.Name;
            txtAmount.Text = fundingProgram.FundingAmount;
            txtDeadline.Text = fundingProgram.Deadline.ToString("yyyy/MM/dd HH:mm", CultureInfo.InvariantCulture);
            txtDescription.Text = fundingProgram.Description;
        }

        public (bool, Exception) IsInputValid()
        {
            string name = txtName.Text;
            string amount = txtAmount.Text;
            string deadlineString = txtDeadline.Text;
            string description = txtDescription.Text;

            if (StringExtensions.AreNullOrEmpty(name, amount, deadlineString, description))
            {
                return (false, new Exception("Please fill out every field."));
            }

            if (!DateTime.TryParseExact(deadlineString, "yyyy/MM/dd HH:mm",
                CultureInfo.InvariantCulture, DateTimeStyles.AllowWhiteSpaces, out DateTime deadline))
            {
                return (false, new Exception("Date field needs to be in the format - yyyy/MM/dd HH:mm"));
            }

            if (name.Length > 50 || amount.Length > 50)
            {
                return (false, new Exception("Name and amount limit is 50 characters."));
            }

            return (true, null);
        }

        public FundingProgram CreatedFundingProgram() => new FundingProgram
        {
            Name = txtName.Text,
            FundingAmount = txtAmount.Text,
            Deadline = DateTime.ParseExact(txtDeadline.Text, "yyyy/MM/dd HH:mm",
                                           CultureInfo.InvariantCulture, DateTimeStyles.AllowWhiteSpaces),
            Description = txtDescription.Text,
            UserId = MainCoordinator.Instance.ConnectedUser.Id
        };
    }
}
