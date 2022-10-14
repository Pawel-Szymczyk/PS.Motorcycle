using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PS.Motorcycle.Domain.Models
{
    internal class Engine
    {
        private int Capacity { get; set; }
        private float Mpg { get; set; }
        private string Bore { get; set; }
        private string Lubrication { get; set; }
        private string FuelSystem { get; set; }
        private string Drive { get; set; }
        private string Power { get; set; }
        private string EngineDescription { get; set; }
        private string CompressionRatio { get; set; }
        private string Ignition { get; set; }
        private string Transmission { get; set; }
        private string Starter { get; set; }
        private string Co2 { get; set; }
        private string Torque { get; set; }


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
