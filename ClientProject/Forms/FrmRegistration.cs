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
    public partial class FrmRegistration : Form
    {
        private const string UsernameHelperText = "Enter your name here...";
        private const string EmailHelperText = "Enter your email here...";
        private const string PasswordHelperText = "Enter your password here...";

        public string Username => txtUsername.Text;
        public string Email => txtEmail.Text;
        public string Password => txtPassword.Text;
        public Button RegisterButton => btnRegister;
        public Button ShowLoginFormButton => btnLogin;

        public FrmRegistration()
        {
            InitializeComponent();
            InitializeEvents();
            MainCoordinator.Instance.InitializeRegistrationForm(this);
        }

        #region Helper Text Logic
        private void InitializeEvents()
        {
            txtUsername.Tag = "username";
            txtEmail.Tag = "email";
            txtPassword.Tag = "password";

            txtUsername.Enter += HandleSelectedTextbox;
            txtEmail.Enter += HandleSelectedTextbox;
            txtPassword.Enter += HandleSelectedTextbox;

            txtUsername.Leave += HandleDeselectedTextbox;
            txtEmail.Leave += HandleDeselectedTextbox;
            txtPassword.Leave += HandleDeselectedTextbox;
        }

        private void HandleSelectedTextbox(object sender, EventArgs e)
        {
            var textBox = (TextBox)sender;
            if (textBox.Text == UsernameHelperText || textBox.Text == EmailHelperText || textBox.Text == PasswordHelperText)
            {
                textBox.Text = "";
                textBox.ForeColor = Color.Black;
            }
        }

        private void HandleDeselectedTextbox(object sender, EventArgs e)
        {
            var textBox = (TextBox)sender;
            if (string.IsNullOrWhiteSpace(textBox.Text))
            {
                bool isUsername = (string)textBox.Tag == "username";
                bool isEmail = (string)textBox.Tag == "email";

                if (isUsername)
                {
                    textBox.Text = UsernameHelperText;
                }
                else if (isEmail)
                {
                    textBox.Text = EmailHelperText;
                }
                else
                {
                    textBox.Text = PasswordHelperText;
                }

                textBox.ForeColor = Color.Gray;
            }
        }
        #endregion
    }
}
