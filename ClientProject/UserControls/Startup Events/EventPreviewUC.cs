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
    public partial class EventPreviewUC : UserControl
    {
        public EventPreviewUC(int id, string eventName, DateTime dateTime)
        {
            InitializeComponent();

            lblEventName.Text = eventName;
            lblDate.Text = dateTime.ToString("f");
            btnReadMore.Tag = id;
        }

        public Button GetReadMoreButton() => btnReadMore;
    }
}
