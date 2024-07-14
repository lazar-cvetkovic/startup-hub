using Common.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClientProject.UserControls.Startup_Pitch.Admin_Panels
{
    public partial class SpecificPitchUC : UserControl
    {
        public Button BtnSendFeedback => btnSendFeedback;
        public Button BtnDownloadPitch => btnDownloadPitch;

        private StartupPitch _startupPitch;
        private Panel _panelGameContainer;
        private Button _btnCloseGame;
        private Process _unityProcess;

        public SpecificPitchUC(StartupPitch startupPitch)
        {
            InitializeComponent();
            InitializeUI(startupPitch);

            _startupPitch = startupPitch; 
        }

        private void InitializeUI(StartupPitch startupPitch)
        {
            lblName.Text = startupPitch.Name;
            lblDescription.Text = startupPitch.Description;

            _panelGameContainer = new Panel
            {
                Dock = DockStyle.Fill,
                Visible = false
            };
            Controls.Add(_panelGameContainer);

            _btnCloseGame = new Button
            {
                Text = "Close",
                Size = new Size(75, 23),
                Anchor = AnchorStyles.Top | AnchorStyles.Left,
                Location = new Point(0, 0),
                Visible = false,
                BackColor = Color.White
            };

            _btnCloseGame.Click += HandleCloseGameClick;
            Controls.Add(_btnCloseGame);

            BtnPlayGame.Visible = startupPitch.PitchFileName.EndsWith(".zip");
        }

        public bool IsInputValid() => !String.IsNullOrEmpty(txtFeedback.Text);

        public StartupPitch GetFilledStartupPitch()
        {
            _startupPitch.Feedback = txtFeedback.Text;
            return _startupPitch;
        }

        private void HandleDownloadButtonClick(object sender, EventArgs e)
        {
            string fileName = _startupPitch.PitchFileName;
            byte[] fileData = _startupPitch.PitchFileData;

            if (fileData != null)
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.FileName = fileName;
                saveFileDialog.Filter = "All Files (*.*)|*.*";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    File.WriteAllBytes(saveFileDialog.FileName, fileData);
                    MessageBox.Show("File downloaded successfully.");
                }
            }
            else
            {
                Common.Helpers.HelperMethods.ShowErrorMessage("File not found in database.");
            }
        }

        private void HandlePlayGameClick(object sender, EventArgs e)
        {
            string fileName = _startupPitch.PitchFileName;
            byte[] fileData = _startupPitch.PitchFileData;

            if (fileData != null)
            {
                string tempPath = Path.Combine(Path.GetTempPath(), Path.GetFileNameWithoutExtension(fileName));
                string tempFilePath = Path.Combine(Path.GetTempPath(), fileName);

                if (File.Exists(tempFilePath))
                {
                    File.Delete(tempFilePath);
                }

                if (Directory.Exists(tempPath))
                {
                    Directory.Delete(tempPath, true);
                }

                File.WriteAllBytes(tempFilePath, fileData);

                if (Path.GetExtension(tempFilePath).ToLower() == ".zip")
                {
                    ZipFile.ExtractToDirectory(tempFilePath, tempPath);
                    string exePath = Directory.GetFiles(tempPath, "*.exe", SearchOption.AllDirectories).FirstOrDefault();
                    if (exePath != null)
                    {
                        RunUnityGame(exePath);
                    }
                    else
                    {
                        MessageBox.Show("No executable file found in the uploaded ZIP.");
                    }
                }
                else
                {
                    MessageBox.Show("The uploaded file is not a ZIP file.");
                }
            }
            else
            {
                Common.Helpers.HelperMethods.ShowErrorMessage("File not found in database.");
            }
        }

        private void HandleCloseGameClick(object sender, EventArgs e)
        {
            _panelGameContainer.Visible = false;
            _btnCloseGame.Visible = false;

            if (_unityProcess != null && !_unityProcess.HasExited)
            {
                _unityProcess.Kill();
            }
        }

        private void RunUnityGame(string filePath)
        {
            _unityProcess = new Process
            {
                StartInfo =
                {
                    FileName = filePath,
                    WorkingDirectory = Path.GetDirectoryName(filePath),
                    Arguments = "-screen-fullscreen 0",
                    UseShellExecute = true
                }
            };
            _unityProcess.Start();

            IntPtr unityHWND = IntPtr.Zero;
            for (int i = 0; i < 10; i++)
            {
                _unityProcess.WaitForInputIdle();
                unityHWND = _unityProcess.MainWindowHandle;
                if (unityHWND != IntPtr.Zero)
                    break;
                Thread.Sleep(500);
            }

            if (unityHWND == IntPtr.Zero)
            {
                MessageBox.Show("Failed to get the main window handle of the Unity game.");
                return;
            }

            SetParent(unityHWND, _panelGameContainer.Handle);
            SetWindowLong(unityHWND, GWL_STYLE, WS_CHILD | WS_VISIBLE);

            _panelGameContainer.Resize += (s, e) =>
            {
                MoveWindow(unityHWND, 0, 23, _panelGameContainer.Width, _panelGameContainer.Height - 23, true);
            };

            MoveWindow(unityHWND, 0, 23, _panelGameContainer.Width, _panelGameContainer.Height - 23, true);

            _panelGameContainer.Visible = true;
            _panelGameContainer.BringToFront();
            _btnCloseGame.Visible = true;
            _btnCloseGame.BringToFront();

            SetForegroundWindow(unityHWND);
        }

        protected override void OnVisibleChanged(EventArgs e)
        {
            base.OnVisibleChanged(e);
            if (!this.Visible)
            {
                HandleCloseGameClick(this, EventArgs.Empty);
            }
        }

        [DllImport("user32.dll", SetLastError = true)]
        private static extern IntPtr SetParent(IntPtr hWndChild, IntPtr hWndNewParent);

        [DllImport("user32.dll", SetLastError = true)]
        private static extern int SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);

        [DllImport("user32.dll", SetLastError = true)]
        private static extern bool MoveWindow(IntPtr hWnd, int x, int y, int nWidth, int nHeight, bool bRepaint);

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool SetForegroundWindow(IntPtr hWnd);

        private const int GWL_STYLE = (-16);
        private const int WS_CHILD = 0x40000000;
        private const int WS_VISIBLE = 0x10000000;
    }
}
