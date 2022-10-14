using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PS.Motorcycle.Domain.Models
{
    internal class Tyre
    {
        private string Brand { get; set; }
        private string SpeedIndex { get; set; }
        private int Width { get; set; }
        private int Profile { get; set; }
        private int RimDiameter { get; set; }
        private int LoadIndexOfTire { get; set; }

        public Tyre()
        {
            this.Brand = string.Empty;
            this.SpeedIndex = string.Empty;
            this.Width = 0;
            this.Profile = 0;
            this.RimDiameter = 0;
            this.LoadIndexOfTire = 0;
        }
    }
}
