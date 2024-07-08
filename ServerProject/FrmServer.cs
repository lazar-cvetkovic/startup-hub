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
        private Server _server;

        public FrmServer()
        {
            InitializeComponent();
            InitializeServer();
        }

        private void InitializeServer()
        {
            _server = new Server();

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

        internal void AddClientToTable(ClientHandler clientHandler) => this.Invoke(new Action(() => _clients.Add(clientHandler)));

        internal void RemoveClientInTable(ClientHandler clientHandler)
        {
            try
            {
                this.Invoke(new Action(() => _clients.Remove(clientHandler)));
            }
            catch (Exception e)
            {
                Console.Write(e.Message);
            }        
        }

        private void StartServerButtonClick(object sender, EventArgs e) => StartServer();

        private void StartServer()
        {
            _server.Start(this);
            _clients.Clear();
            HandleServerUI(true);
        }

        private void StopServerButtonClick(object sender, EventArgs e)
        {
            _server.Stop();
            _clients.Clear();
            HandleServerUI(false);
        }

        private void HandleServerUI(bool isServerStarted)
        {
            btnStart.Enabled = !isServerStarted;
            btnStop.Enabled = isServerStarted;

            lblServerState.ForeColor = isServerStarted ? Color.DarkGreen : Color.Crimson;
            lblServerState.Text = isServerStarted ? "Server is active." : "Server is inactive.";
        }
    }
}
