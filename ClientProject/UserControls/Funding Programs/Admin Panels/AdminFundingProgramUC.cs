﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClientProject.UserControls.Funding_Programs
{
    public partial class AdminFundingProgramUC : UserControl
    {
        public Button BtnCreate => btnCreate;
        public Button BtnEdit => btnEdit;

        public AdminFundingProgramUC()
        {
            InitializeComponent();
            
        }
    }
}
