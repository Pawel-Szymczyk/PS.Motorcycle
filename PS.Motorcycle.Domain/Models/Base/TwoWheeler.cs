using Newtonsoft.Json;
using PS.Motorcycle.Domain.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PS.Motorcycle.Domain.Models.Base
{
    public abstract class TwoWheeler
    {
        //[JsonProperty(PropertyName = "id")]
        //public virtual string Id { get; set; }

        public abstract TwoWheelerType Type { get; set; }
        public abstract string Make { get; set; }
        public abstract string Model { get; set; }
        public abstract float Price { get; set; }
        public abstract int Length { get; set; }
        public abstract int Height { get; set; }
        public abstract int Width { get; set; }
        public abstract int KerbMass { get; set; }
    }
}
