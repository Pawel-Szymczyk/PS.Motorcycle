using PS.Motorcycle.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PS.Motorcycle.Domain.Models
{
    public class Tyre
    {
        public string Brand { get; set; }
        public string SpeedIndex { get; set; }
        public int Width { get; set; }
        public int Profile { get; set; }
        public int RimDiameter { get; set; }
        public int LoadIndexOfTyre { get; set; }

        public Tyre()
        {
            this.Brand = string.Empty;
            this.SpeedIndex = string.Empty;
            this.Width = 0;
            this.Profile = 0;
            this.RimDiameter = 0;
            this.LoadIndexOfTyre = 0;
        }
    }
}
