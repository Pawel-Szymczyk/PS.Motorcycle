using PS.Motorcycle.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PS.Motorcycle.Domain.Models
{
    public class Chassis : IChassis
    {

        private List<ISuspension> suspensions;
        private List<IWheel> wheels;
        private List<IBreak> breaks;


        public List<ISuspension> Suspensions
        {
            get
            {
                return this.suspensions;
            }

            set
            {
                this.suspensions = value;
            }
        }

        public List<IWheel> Wheels
        {
            get
            {
                return this.wheels;
            }

            set
            {
                this.wheels = value;
            }
        }

        public List<IBreak> Breaks
        {
            get
            {
                return this.breaks;
            }

            set
            {
                this.breaks = value;
            }
        }

        public Chassis()
        {
            this.suspensions = new List<ISuspension>();
            this.wheels = new List<IWheel>();
            this.breaks = new List<IBreak>();
        }

        public Chassis(List<ISuspension> suspensions, List<IWheel> wheels, List<IBreak> breaks)
        {
            this.suspensions = suspensions;
            this.wheels = wheels;
            this.breaks = breaks;
        }
    }
}
