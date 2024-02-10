using ClientProject.GUIControllers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClientProject.Forms
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
            InitializeMainCoordinator();
            AddButtonSubscriptions();
        }

        private void InitializeMainCoordinator() => MainCoordinator.Instance.Initialize(lblTitle, btnHome, panelMain);

        private void AddButtonSubscriptions()
        {
            btnFundingPrograms.Click += MainCoordinator.Instance.ShowFundingProgramsUC;
            btnHome.Click += MainCoordinator.Instance.ShowHomeUC;
            btnStartupEvents.Click += MainCoordinator.Instance.ShowStartupEventsUC;
        }
    }
}
