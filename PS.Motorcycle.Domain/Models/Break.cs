using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PS.Motorcycle.Domain.Models
{
    internal class Break
    {
        private string Name { get; set; }
        private string Type { get; set; }
        private int NumberOfDiscs { get; set; }

        public Break()
        {
            this.Type = string.Empty;
            this.Name = string.Empty;
            this.NumberOfDiscs = 0;
        }
    }
}
