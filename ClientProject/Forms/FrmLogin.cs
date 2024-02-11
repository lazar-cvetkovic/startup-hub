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

        public FrmLogin()
        {
            InitializeComponent();
            InitializeEvents();
        }

        #region Helper Text Logic
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
            }
        }
        #endregion
    }
}
