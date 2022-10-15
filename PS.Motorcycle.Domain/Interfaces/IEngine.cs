using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PS.Motorcycle.Domain.Interfaces
{
    public interface IEngine
    {
        public int Capacity { get; set; }
        public float Mpg { get; set; }
        public string Bore { get; set; }
        public string Lubrication { get; set; }
        public string FuelSystem { get; set; }
        public string Drive { get; set; }
        public string Power { get; set; }
        public string EngineDescription { get; set; }
        public string CompressionRatio { get; set; }
        public string Ignition { get; set; }
        public string Transmission { get; set; }
        public string Starter { get; set; }
        public string Co2 { get; set; }
        public string Torque { get; set; }
    }
}
