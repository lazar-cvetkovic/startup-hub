﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Domain
{
    public class StartupEvent
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public string Location { get; set; }
        public int UserId { get; set; }
    }
}
