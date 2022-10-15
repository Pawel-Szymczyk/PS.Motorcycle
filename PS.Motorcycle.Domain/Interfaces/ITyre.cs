using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PS.Motorcycle.Domain.Interfaces
{
    public interface ITyre
    {
        public string Brand { get; set; }
        public string SpeedIndex { get; set; }
        public int Width { get; set; }
        public int Profile { get; set; }
        public int RimDiameter { get; set; }
        public int LoadIndexOfTire { get; set; }
    }
}
