using PS.Motorcycle.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PS.Motorcycle.Domain.Models
{
    public class Engine : IEngine
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


        public Engine()
        {
            this.Capacity = 0;
            this.Mpg = 0;
            this.Bore = string.Empty;
            this.Lubrication = string.Empty;
            this.FuelSystem = string.Empty;
            this.Drive = string.Empty;
            this.Power = string.Empty;
            this.EngineDescription = string.Empty;
            this.CompressionRatio = string.Empty;
            this.Ignition = string.Empty;
            this.Transmission = string.Empty;
            this.Starter = string.Empty;
            this.Co2 = string.Empty;
            this.Torque = string.Empty;
        }
    }
}
