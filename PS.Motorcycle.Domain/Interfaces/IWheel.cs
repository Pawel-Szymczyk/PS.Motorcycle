using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PS.Motorcycle.Domain.Interfaces
{
    public interface IWheel
    {
        public int RimDiameter { get; set; }
        public string Type { get; set; }

        public ITyre Tyre { get; set; }
    }
}
