using ClientProject.UserControls;
using ClientProject.UserControls.Funding_Programs;
using Common.Domain;
using Common.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClientProject.GUIControllers
{
    internal class FundingProgramGUIController
    {
        FlowLayoutPanel _flowPanel;

        public FundingProgramsUC CreateFundingProgramsUC()
        {
            var fundingProgramsUC = new FundingProgramsUC();

            _flowPanel = fundingProgramsUC.FlowPanel;
            _flowPanel.Controls.Clear();

            FillEvents();

            return fundingProgramsUC;
        }

        private void FillEvents()
        {
            AddFundingProgramPreview(1, "Mini grant", DateTime.Now, "$120,000");
            AddFundingProgramPreview(1, "Mini grant", DateTime.Now, "$120,000");
            AddFundingProgramPreview(1, "Mini grant", DateTime.Now, "$120,000");
            AddFundingProgramPreview(1, "Mini grant", DateTime.Now, "$120,000");
            AddFundingProgramPreview(1, "Mini grant", DateTime.Now, "$120,000");
            AddFundingProgramPreview(1, "Mini grant", DateTime.Now, "$120,000");
            AddFundingProgramPreview(1, "Mini grant", DateTime.Now, "$120,000");
            AddFundingProgramPreview(1, "Mini grant", DateTime.Now, "$120,000");
        }

        internal SpecificFundingProgramUC CreateSpecificFundingProgramUC(string programName, DateTime dateTime, string fundingAmount, string description)
        {
            return new SpecificFundingProgramUC(programName, dateTime, fundingAmount, description);
        }

        internal void AddFundingProgramPreview(int id, string programName, DateTime dateTime, string fundingAmount)
        {
            var eventPreviewUC = new FundingProgramPreviewUC(id, programName, dateTime, fundingAmount);
            Button readMoreButton = eventPreviewUC.GetReadMoreButton();
            readMoreButton.Click += ReadMoreButtonClicked;

            var panel = new Panel
            {
                Size = new System.Drawing.Size(230, 307)
            };

            eventPreviewUC.Dock = DockStyle.Fill;
            panel.Controls.Add(eventPreviewUC);
            _flowPanel.Controls.Add(panel);
        }

        private void ReadMoreButtonClicked(object sender, EventArgs e)
        {
            Button button = sender as Button;

            if (button == null)
            {
                return;
            }

            int id = (int)button.Tag;
            var response = GetFundingProgramById(id);

            if(response.exception != null)
            {
                HelperMethods.ShowErrorMessage(response.exception.Message);
                return;
            }

            FundingProgram program = response.program;
            string programName = program.Name;
            string programDescription = program.Description;
            DateTime date = program.Deadline;
            string fundingAmount = program.FundingAmount;

            MainCoordinator.Instance.ChangePanel(CreateSpecificFundingProgramUC(programName, date, fundingAmount, programDescription));
        }

        private (FundingProgram program, Exception exception) GetFundingProgramById(int id)
        {
            var primaryKey = new Dictionary<string, int>() {{ "Id", id }};

            var response =  Communication.Instance.LoadFundingProgram(primaryKey);

            return ((FundingProgram)response.Result, response.Exception);
        }
    }
}
