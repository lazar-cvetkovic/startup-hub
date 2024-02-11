using ClientProject.UserControls;
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
        FlowLayoutPanel _flowPanel;

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
            AddEventPreview(1, "Startup Event 1", DateTime.Now);
            AddEventPreview(2, "Startup Event 2", DateTime.Now);
            AddEventPreview(3, "Startup Event 3", DateTime.Now);
            AddEventPreview(4, "Startup Event 4", DateTime.Now);
            AddEventPreview(5, "Startup Event 5", DateTime.Now);
            AddEventPreview(5, "Startup Event 5", DateTime.Now);
            AddEventPreview(5, "Startup Event 5", DateTime.Now);
            AddEventPreview(5, "Startup Event 5", DateTime.Now);
            AddEventPreview(5, "Startup Event 5", DateTime.Now);
            AddEventPreview(5, "Startup Event 5", DateTime.Now);
            AddEventPreview(5, "Startup Event 5", DateTime.Now);
            AddEventPreview(5, "Startup Event 5", DateTime.Now);
            AddEventPreview(5, "Startup Event 5", DateTime.Now);
            AddEventPreview(5, "Startup Event 5", DateTime.Now);
            AddEventPreview(5, "Startup Event 5", DateTime.Now);
            AddEventPreview(5, "Startup Event 5", DateTime.Now);
            AddEventPreview(5, "Startup Event 5", DateTime.Now);
            AddEventPreview(5, "Startup Event 5", DateTime.Now);
            AddEventPreview(5, "Startup Event 5", DateTime.Now);
            AddEventPreview(5, "Startup Event 5", DateTime.Now);
            AddEventPreview(5, "Startup Event 5", DateTime.Now);
            AddEventPreview(5, "Startup Event 5", DateTime.Now);
            AddEventPreview(5, "Startup Event 5", DateTime.Now);
            AddEventPreview(5, "Startup Event 5", DateTime.Now);
            AddEventPreview(5, "Startup Event 5", DateTime.Now);
            AddEventPreview(5, "Startup Event 5", DateTime.Now);
            AddEventPreview(5, "Startup Event 5", DateTime.Now);
            AddEventPreview(5, "Startup Event 5", DateTime.Now);
            AddEventPreview(5, "Startup Event 5", DateTime.Now);
            AddEventPreview(5, "Startup Event 5", DateTime.Now);
            AddEventPreview(5, "Startup Event 5", DateTime.Now);
            AddEventPreview(5, "Startup Event 5", DateTime.Now);
            AddEventPreview(5, "Startup Event 5", DateTime.Now);
            AddEventPreview(5, "Startup Event 5", DateTime.Now);
            AddEventPreview(5, "Startup Event 5", DateTime.Now);
            AddEventPreview(5, "Startup Event 5", DateTime.Now);
            AddEventPreview(5, "Startup Event 5", DateTime.Now);
            AddEventPreview(5, "Startup Event 5", DateTime.Now);
            AddEventPreview(5, "Startup Event 5", DateTime.Now);
            AddEventPreview(5, "Startup Event 5", DateTime.Now);
            AddEventPreview(5, "Startup Event 5", DateTime.Now);
            AddEventPreview(5, "Startup Event 5", DateTime.Now);
            AddEventPreview(5, "Startup Event 5", DateTime.Now);
            AddEventPreview(5, "Startup Event 5", DateTime.Now);
        }

        internal SpecificEventUC CreateSpecificEventUC() => new SpecificEventUC();

        internal void AddEventPreview(int id, string eventName, DateTime dateTime)
        {
            var eventPreviewUC = new EventPreviewUC(id, eventName, dateTime);
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

            if (button != null)
            {
                int id = (int)button.Tag;
                MainCoordinator.Instance.ChangePanel(CreateSpecificEventUC());
            }
        }
    }
}
