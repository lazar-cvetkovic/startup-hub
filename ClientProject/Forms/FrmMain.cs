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
using System.Windows.Media;

namespace ClientProject.Forms
{
    public partial class FrmMain : Form
    {
        // Fields used for window dragging logic
        private bool _isDragging = false;
        private Point _dragCursorPoint;
        private Point _dragFormPoint;

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

        #region Custom Windows Buttons
        private void ExitButtonClick(object sender, EventArgs e) => Application.Exit();

        private void MaximizeButtonClick(object sender, EventArgs e)
        {
            bool isWindowNormal = WindowState == FormWindowState.Normal;
            WindowState = isWindowNormal ? FormWindowState.Maximized : FormWindowState.Normal;
        }

        private void MinimizeButtonClick(object sender, EventArgs e) => WindowState = FormWindowState.Minimized;
        #endregion

        #region Form Dragging Logic
        private void OnMouseClickStart(object sender, MouseEventArgs e)
        {
            _isDragging = true;
            _dragCursorPoint = Cursor.Position;
            _dragFormPoint = this.Location;
        }

        private void OnMouseClickEnd(object sender, MouseEventArgs e)
        {
            _isDragging = false;
        }

        private void OnMouseMovement(object sender, MouseEventArgs e)
        {
            if (_isDragging && WindowState == FormWindowState.Normal)
            {
                Point dif = Point.Subtract(Cursor.Position, new Size(_dragCursorPoint));
                this.Location = Point.Add(_dragFormPoint, new Size(dif));
            }
        }
        #endregion
    }
}
