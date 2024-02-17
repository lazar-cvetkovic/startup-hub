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

namespace ClientProject.UserControls.Startup_Events.Admin_Panels
{
    public partial class CreateStartupEventUC : UserControl
    {
        public CreateStartupEventUC()
        {
            InitializeComponent();
        }

        public (bool, Exception) IsInputValid()
        {
            string name = txtName.Text;
            string location = txtLocation.Text;
            string dateString = txtDate.Text;
            string description = txtDescription.Text;

            if (StringExtensions.AreNullOrEmpty(name, location, dateString, description))
            {
                return (false, new Exception("Please fill out every field."));
            }

            if (!DateTime.TryParseExact(dateString, "yyyy/MM/dd HH:mm",
                CultureInfo.InvariantCulture, DateTimeStyles.AllowWhiteSpaces, out DateTime deadline))
            {
                return (false, new Exception("Date field needs to be in the format - yyyy/MM/dd HH:mm"));
            }

            if (name.Length > 50 || location.Length > 50)
            {
                return (false, new Exception("Name and location limit is 50 characters."));
            }

            return (true, null);
        }

        public StartupEvent CreatedStartupEvent() => new StartupEvent
        {
            Name = txtName.Text,
            Location = txtLocation.Text,
            Date = DateTime.ParseExact(txtDate.Text, "yyyy/MM/dd HH:mm",
                                           CultureInfo.InvariantCulture, DateTimeStyles.AllowWhiteSpaces),
            Description = txtDescription.Text,
            UserId = MainCoordinator.Instance.ConnectedUser.Id
        };
    }
}
