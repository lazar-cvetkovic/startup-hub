using ClientProject.Forms;
using Common.Domain;
using Common.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClientProject.GUIControllers
{
    internal class UserGUIController
    {
        FrmLogin _loginForm;
        FrmRegistration _registerForm;

        internal void InitializeLoginForm(FrmLogin loginForm)
        {
            _loginForm = loginForm;
            _loginForm.LoginButton.Click += LoginButtonClicked;
        }

        private void LoginButtonClicked(object sender, EventArgs e)
        {
            string email = _loginForm.Email;
            string password = _loginForm.Password;

            if (!IsLoginInputValid(email, password))
            {
                return;
            }

            var user = new User
            {
                Email = email,
                Password = password
            };

            var response = Communication.Instance.Login(user);

            if(response.Exception != null)
            {
                HelperMethods.ShowErrorMessage(response.Exception.Message);
                return;
            }

            HelperMethods.ShowInfoMessage("Welcome!");
            MainCoordinator.Instance.ShowMainForm();
        }

        private bool IsLoginInputValid(string email, string password)
        {
            if(StringExtensions.AreNullOrEmpty(email, password))
            {
                HelperMethods.ShowErrorMessage("Please fill in the required inputs.");
                return false;
            }

            if (!IsEmailValid(email))
            {
                HelperMethods.ShowErrorMessage("Email must be in correct form.");
                return false;
            }

            return true;
        }

        internal void InitializeRegistrationForm(FrmRegistration frmRegistration)
        {
            _registerForm = frmRegistration;
            _registerForm.RegisterButton.Click += RegisterButtonClicked;
        }

        private void RegisterButtonClicked(object sender, EventArgs e)
        {
            
        }

        private bool IsEmailValid(string email) => email.Contains('@') && email.Contains('.');

    }
}
