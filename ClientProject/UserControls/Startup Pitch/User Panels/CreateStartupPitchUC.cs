using ClientProject.GUIControllers;
using Common.Domain;
using Common.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClientProject.UserControls.Startup_Pitch.User_Panels
{
    public partial class CreateStartupPitchUC : UserControl
    {
        public Button BtnSend => btnSend;

        private string _fileName;
        private byte[] _fileData;

        public CreateStartupPitchUC()
        {
            InitializeComponent();
        }

        public (bool isValid, Exception exception) IsInputValid()
        {
            string name = txtName.Text;
            string description = txtDescription.Text;

            if (StringExtensions.AreNullOrEmpty(name, description))
            {
                return (false, new Exception("Please fill out every field."));
            }

            if (_fileData == null || string.IsNullOrEmpty(_fileName))
            {
                return (false, new Exception("Please upload your pitch deck."));
            }

            return (true, null);
        }

        public StartupPitch GetCreatedStartupPitch() => new StartupPitch
        {
            Name = txtName.Text,
            Description = txtDescription.Text,
            UserId = MainCoordinator.Instance.ConnectedUser.Id,
            PitchFileData = _fileData,
            PitchFileName = _fileName,
            Feedback = string.Empty
        };

        private void HandleUploadFileClick(object sender, EventArgs e)
        {
            var openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "All Files (*.*)|*.*";
            openFileDialog.Title = "Select a File";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;
                _fileData = File.ReadAllBytes(filePath);
                _fileName = Path.GetFileName(filePath);

                lblFileName.Text = _fileName;
            }
        }
    }
}
