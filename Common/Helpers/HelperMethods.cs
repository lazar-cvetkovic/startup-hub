﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Common.Helpers
{
    public static class HelperMethods
    {
        public static void ShowInfoMessage(string message) => MessageBox.Show(message, "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);

        public static void ShowErrorMessage(string message) => MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

        public static void ShowWarningMessage(string message) => MessageBox.Show(message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

        public static DialogResult ShowYesNoMessage(string message) => MessageBox.Show(message, "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

    }
}
