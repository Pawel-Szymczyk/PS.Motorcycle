using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PS.Motorcycle.Domain.Models
{
    internal class Wheel
    {
        private int RimDiameter { get; set; }
        private string Type { get; set; }


        private Wheel wheel;

        public Wheel()
        {
            this.RimDiameter = 0;
            this.Type = string.Empty;

            this.wheel = new Wheel();
        }
    }
}
