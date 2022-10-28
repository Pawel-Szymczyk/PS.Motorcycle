using Newtonsoft.Json;
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
        public Guid Id { get; set; }

        public string About { get; set; }
        public string ImageUrl { get; set; }
        public string ImagesGalleryUrls { get; set; }

        public TwoWheelerType Type { get; }
        public int Length { get; set; }
        public int Height { get; set; }
        public int Width { get; set; }
        public int KerbMass { get; set; }
        public int SitHeight { get; set; }
        public int Wheelbase { get; set; }
        public int GroundClearance { get; set; }
        public int ProductionYear { get; set; }
        public float Price { get; set; }
        public float FuelCapacity { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public IChassis Chassis { get; set; }
        public IEngine Engine { get; set; }
        //public Chassis Chassis { get; set; }
        //public Engine Engine { get; set; }
    }
}
