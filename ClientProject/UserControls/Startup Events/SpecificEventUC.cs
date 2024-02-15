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
    public partial class SpecificEventUC : UserControl
    {
        public SpecificEventUC(StartupEvent startupEvent)
        {
            InitializeComponent();
            InitializeUI(startupEvent);
        }

        private void InitializeUI(StartupEvent startupEvent)
        {
            lblDate.Text = startupEvent.Date.ToString("f");
            lblDescription.Text = startupEvent.Description;
            lblEventName.Text = startupEvent.Name;
            lblPlace.Text = startupEvent.Location;
        }
    }
}
