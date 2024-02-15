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
        private List<FundingProgram> _fundingProgramsList;
        private FlowLayoutPanel _flowPanel;

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
            var serverResponse = Communication.Instance.FindFundingPrograms();

            if (serverResponse != null && serverResponse.Exception != null)
            {
                HelperMethods.ShowErrorMessage(serverResponse.Exception.Message);
                return;
            }

            if (serverResponse == null || serverResponse.Result == null)
            {
                return;
            }

            _fundingProgramsList = serverResponse.Result as List<FundingProgram>;
            _fundingProgramsList.ForEach(p => AddFundingProgramPreview(p));
        }

        internal SpecificFundingProgramUC CreateSpecificFundingProgramUC(FundingProgram program) => new SpecificFundingProgramUC(program);

        internal void AddFundingProgramPreview(FundingProgram fundingProgram)
        {
            var programPreviewUC = new FundingProgramPreviewUC(fundingProgram.Id, fundingProgram.Name, fundingProgram.Deadline, fundingProgram.FundingAmount);
            Button readMoreButton = programPreviewUC.GetReadMoreButton();
            readMoreButton.Click += ReadMoreButtonClicked;

            var panel = new Panel
            {
                Size = new System.Drawing.Size(230, 307)
            };

            programPreviewUC.Dock = DockStyle.Fill;
            panel.Controls.Add(programPreviewUC);

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

            if(response.program == null)
            {
                Console.WriteLine("Program was null, returning.");
                return;
            }

            MainCoordinator.Instance.ChangePanel(CreateSpecificFundingProgramUC(response.program));
        }

        private (FundingProgram program, Exception exception) GetFundingProgramById(int id)
        {
            var primaryKey = new Dictionary<string, int>() {{ "Id", id }};

            var response =  Communication.Instance.LoadFundingProgram(primaryKey);

            return ((FundingProgram)response.Result, response.Exception);
        }
    }
}
