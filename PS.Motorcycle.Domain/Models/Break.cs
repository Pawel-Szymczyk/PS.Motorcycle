﻿using PS.Motorcycle.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PS.Motorcycle.Domain.Models
{
    public class Break : IBreak
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public int NumberOfDiscs { get; set; }

        public Break()
        {
            this.Type = string.Empty;
            this.Name = string.Empty;
            this.NumberOfDiscs = 0;
        }
    }
}
