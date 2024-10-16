﻿using ClientProject.Forms;
using Common.Domain;
using Common.Enums;
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

            if (!IsInputValid(email, password))
            {
                return;
            }

            var user = new User
            {
                Email = email,
                Password = password
            };

            var response = Communication.Instance.Login(user);

            if (response.Exception != null)
            {
                HelperMethods.ShowErrorMessage(response.Exception.Message);
                return;
            }

            if(response == null || response.Result == null)
            {
                HelperMethods.ShowErrorMessage("User with that email and password doesn't exist.");
                return;
            }

            MainCoordinator.Instance.ConnectedUser = (User)response.Result;
            HelperMethods.ShowInfoMessage($"Welcome {MainCoordinator.Instance.ConnectedUser.Name}!");

            MainCoordinator.Instance.ShowMainForm();
        }

        private bool IsInputValid(string email, params string[] inputs)
        {
            inputs.Append(email);
            if(StringExtensions.AreNullOrEmpty(inputs))
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
            string email = _registerForm.Email;
            string password = _registerForm.Password;
            string username = _registerForm.Username;

            if (!IsInputValid(email, password, username))
            {
                return;
            }

            var user = new User
            {
                Email = email,
                Password = password,
                Name = username,
                Role = UserRole.Normal
            };

            var response = Communication.Instance.CreateUser(user);

            if (response.Exception != null)
            {
                HelperMethods.ShowErrorMessage(response.Exception.Message);
                return;
            }

            HelperMethods.ShowInfoMessage($"User has been successfully created!");

            MainCoordinator.Instance.ShowLoginForm();
        }

        private bool IsEmailValid(string email) => email.Contains('@') && email.Contains('.');

    }
}
