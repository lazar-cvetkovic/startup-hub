﻿using ClientProject.UserControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientProject.GUIControllers
{
    internal class StartupEventGUIController
    {
        public StartupEventsUC CreateStartupEventsUC()
        {
            return new StartupEventsUC();
        }
    }
}
