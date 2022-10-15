using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PS.Motorcycle.Domain.Interfaces
{
    public interface ISuspension
    {
        public bool HasSuspension { get; set; }
        public string Type { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
