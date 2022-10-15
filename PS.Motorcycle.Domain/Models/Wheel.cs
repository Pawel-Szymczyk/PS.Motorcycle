using PS.Motorcycle.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PS.Motorcycle.Domain.Models
{
    public class Wheel : IWheel
    {
        private ITyre tyre;

        public int RimDiameter { get; set; }
        public string Type { get; set; }

        public ITyre Tyre
        {
            get
            {
                return this.tyre;
            }

            set
            {
                this.tyre = value;
            }
        }

        public Wheel()
        {
            this.RimDiameter = 0;
            this.Type = string.Empty;

            this.tyre = new Tyre();
        }

        public Wheel(ITyre tyre)
        {
            this.RimDiameter = 0;
            this.Type = string.Empty;

            this.tyre = tyre;
        }
    }
}
