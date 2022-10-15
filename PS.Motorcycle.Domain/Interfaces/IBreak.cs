using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PS.Motorcycle.Domain.Interfaces
{
    public interface IBreak
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public int NumberOfDiscs { get; set; }
    }
}
