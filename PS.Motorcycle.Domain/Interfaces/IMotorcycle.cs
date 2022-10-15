using PS.Motorcycle.Domain.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PS.Motorcycle.Domain.Interfaces
{
    public interface IMotorcycle
    {
        public TwoWheelerType Type { get; }
        public int Length { get; set;}
        public int Height { get; set; }
        public int Width { get; set; }
        public int KerbMass { get; set; }
        public int SitHeight { get; set; }
        public int WheelBase { get; set; }
        public int GroundClearance { get; set; }
        public float Price { get; set; }
        public float FuelCapacity { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public IChassis Chassis { get; set; }
        public IEngine Engine { get; set; }
    }
}
