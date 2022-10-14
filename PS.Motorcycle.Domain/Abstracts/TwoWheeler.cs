using PS.Motorcycle.Domain.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PS.Motorcycle.Domain.Abstracts
{
    internal abstract class TwoWheeler
    {
        public abstract TwoWheelerType Type { get; set; }
        public abstract string Brand { get; set; }
        public abstract string Model { get; set; }
        public abstract float Price { get; set; }
        public abstract int Length { get; set; }
        public abstract int Height { get; set; }
        public abstract int Width { get; set; }
        public abstract int KerbMass { get; set; }
    }
}
