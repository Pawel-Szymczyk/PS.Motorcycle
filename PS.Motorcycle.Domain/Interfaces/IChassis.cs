using PS.Motorcycle.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PS.Motorcycle.Domain.Interfaces
{
    public interface IChassis
    {
        //public List<ISuspension> Suspensions { get; set; }

        //public List<IWheel> Wheels { get; set; }

        //public List<IBreak> Breaks { get; set; }

        public List<Suspension> Suspensions { get; set; }

        public List<Wheel> Wheels { get; set; }

        public List<Brake> Brakes { get; set; }
    }
}
