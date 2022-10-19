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

        private List<Suspension> suspensions;
        private List<Wheel> wheels;
        private List<Break> breaks;


        public List<Suspension> Suspensions
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

        public List<Wheel> Wheels
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

        public List<Break> Breaks
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
            this.suspensions = new List<Suspension>();
            this.wheels = new List<Wheel>();
            this.breaks = new List<Break>();
        }

        public Chassis(List<Suspension> suspensions, List<Wheel> wheels, List<Break> breaks)
        {
            this.suspensions = suspensions;
            this.wheels = wheels;
            this.breaks = breaks;
        }
    }
}
