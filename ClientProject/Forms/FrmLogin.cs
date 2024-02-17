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

namespace ClientProject
{
    public partial class FrmLogin : Form
    {
        private const string EmailHelperText = "Enter your email here...";
        private const string PasswordHelperText = "Enter your password here...";

        public string Email => txtEmail.Text;
        public string Password => txtPassword.Text;
        public Button LoginButton => btnLogin;
        public Button ShowRegisterFormButton => btnRegister;

        public FrmLogin()
        {
            InitializeComponent();
            InitializeEvents();
            InitializeHelperText();
            MainCoordinator.Instance.InitializeLoginForm(this);
        }

        #region Helper Text Logic
        private void InitializeHelperText()
        {
            txtEmail.Text = EmailHelperText;
            txtPassword.Text = PasswordHelperText;

            txtEmail.ForeColor = Color.Gray;
            txtPassword.ForeColor = Color.Gray;

            txtPassword.UseSystemPasswordChar = false;
        }

        private void InitializeEvents()
        {
            txtEmail.Tag = "email";
            txtPassword.Tag = "password";

            txtEmail.Enter += HandleSelectedTextbox;
            txtPassword.Enter += HandleSelectedTextbox;

            txtEmail.Leave += HandleDeselectedTextbox;
            txtPassword.Leave += HandleDeselectedTextbox;
        }

        private void HandleSelectedTextbox(object sender, EventArgs e)
        {
            var textBox = (TextBox)sender;
            if (textBox.Text == EmailHelperText || textBox.Text == PasswordHelperText)
            {
                textBox.Text = "";
                textBox.ForeColor = Color.Black;

                if((string)textBox.Tag == "password")
                {
                    txtPassword.UseSystemPasswordChar = true;
                }
            }
        }

        private void HandleDeselectedTextbox(object sender, EventArgs e)
        {
            var textBox = (TextBox)sender;
            if (string.IsNullOrWhiteSpace(textBox.Text))
            {
                bool isEmail = (string)textBox.Tag == "email";

                textBox.Text = isEmail ? EmailHelperText : PasswordHelperText;
                textBox.ForeColor = Color.Gray;

                if (!isEmail)
                {
                    txtPassword.UseSystemPasswordChar = false;
                }
            }
        }
        #endregion

        private void HandleCloseClick(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
