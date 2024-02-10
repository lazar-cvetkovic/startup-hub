using Common.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ServerProject
{
    public partial class FrmServer : Form
    {
        private BindingList<ClientHandler> _clients = new BindingList<ClientHandler>();

        public FrmServer()
        {
            InitializeComponent();
            InitializeServer();
        }

        private void InitializeServer()
        {
            try
            {
                StartServer();
                dgvConnectedClients.DataSource = _clients;
            }
            catch (Exception ex)
            {
                HelperMethods.ShowErrorMessage(ex.Message);
            }
        }

        private void StartServerButtonClick(object sender, EventArgs e) => StartServer();

        private void StartServer()
        {
            Server.Instance.Start();
            HandleServerUI(true);
        }

        private void StopServerButtonClick(object sender, EventArgs e) => HandleServerUI(false);

        private void HandleServerUI(bool isServerStarted)
        {
            btnStart.Enabled = !isServerStarted;
            btnStop.Enabled = isServerStarted;

            lblServerState.ForeColor = isServerStarted ? Color.DarkGreen : Color.Crimson;
            lblServerState.Text = isServerStarted ? "Server is active." : "Server is inactive.";
        }
    }
}
