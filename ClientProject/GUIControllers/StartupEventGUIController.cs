using ClientProject.UserControls;
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
    internal class StartupEventGUIController
    {
        private List<StartupEvent> _startupEventsList;
        private FlowLayoutPanel _flowPanel;

        internal StartupEventsUC CreateStartupEventsUC()
        {
            var eventsUC = new StartupEventsUC();

            _flowPanel = eventsUC.FlowPanel;
            _flowPanel.Controls.Clear();

            FillEvents();

            return eventsUC;
        }

        private void FillEvents()
        {
            var serverResponse = Communication.Instance.FindStartupEvents();

            if (serverResponse != null && serverResponse.Exception != null)
            {
                HelperMethods.ShowErrorMessage(serverResponse.Exception.Message);
                return;
            }

            if (serverResponse == null || serverResponse.Result == null)
            {
                return;
            }

            _startupEventsList = serverResponse.Result as List<StartupEvent>;
            _startupEventsList.ForEach(e => AddEventPreview(e));
        }

        internal SpecificEventUC CreateSpecificEventUC(StartupEvent startupEvent) => new SpecificEventUC(startupEvent);

        internal void AddEventPreview(StartupEvent startupEvent)
        {
            var eventPreviewUC = new EventPreviewUC(startupEvent.Id, startupEvent.Name, startupEvent.Date);
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
            var response = GetStartupEventById(id);

            if (response.exception != null)
            {
                HelperMethods.ShowErrorMessage(response.exception.Message);
                return;
            }

            if (response.startupEvent == null)
            {
                Console.WriteLine("Startup event was null, returning.");
                return;
            }

            MainCoordinator.Instance.ChangePanel(CreateSpecificEventUC(response.startupEvent));
        }

        private (StartupEvent startupEvent, Exception exception) GetStartupEventById(int id)
        {
            var primaryKey = new Dictionary<string, int>() { { "Id", id } };

            var response = Communication.Instance.LoadStartupEvent(primaryKey);

            return ((StartupEvent)response.Result, response.Exception);
        }
    }
}
