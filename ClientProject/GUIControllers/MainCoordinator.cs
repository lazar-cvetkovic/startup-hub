using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientProject.GUIControllers
{
    internal class MainCoordinator
    {
        private static MainCoordinator _instance;
        public static MainCoordinator Instance
        {
            get
            {
                _instance = _instance ?? new MainCoordinator();
                return _instance;
            }
        }

        private MainCoordinator() { }
    }
}
