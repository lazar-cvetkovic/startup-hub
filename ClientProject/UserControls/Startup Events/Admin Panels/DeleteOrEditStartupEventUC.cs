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

namespace ClientProject.UserControls.Startup_Events.Admin_Panels
{
    public partial class DeleteOrEditStartupEventUC : UserControl
    {
        public DeleteOrEditStartupEventUC(List<StartupEvent> startupEvents)
        {
            InitializeComponent();
            InitializeDataGridView(startupEvents);
        }

        private void InitializeDataGridView(List<StartupEvent> startupEvents)
        {
            var bindingListOfEvents = new BindingList<StartupEvent>(startupEvents);
            dgvResults.DataSource = bindingListOfEvents;
        }

        public (StartupEvent, Exception) GetSelectedEvent()
        {
            if (dgvResults.CurrentRow == null)
            {
                return (null, new Exception("No row is currently selected."));
            }

            var selectedRow = dgvResults.CurrentRow;
            if (selectedRow.DataBoundItem is StartupEvent selectedEvent)
            {
                return (selectedEvent, null);
            }
            else
            {
                return (null, new Exception("The selected row is not valid."));
            }
        }
    }
}
