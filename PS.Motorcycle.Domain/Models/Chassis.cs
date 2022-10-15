﻿using PS.Motorcycle.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PS.Motorcycle.Domain.Models
{
    public class Chassis : IChassis
    {

        private List<Suspension> suspensions;
        private List<Wheel> wheels;
        private List<Break> breaks;

        public Chassis()
        {
            this.suspensions = new List<Suspension>();
            this.wheels = new List<Wheel>();
            this.breaks = new List<Break>();
        }
    }
}
