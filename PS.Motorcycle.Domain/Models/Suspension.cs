using PS.Motorcycle.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PS.Motorcycle.Domain.Models
{
    public class Suspension : ISuspension
    {
        public bool HasSuspension { get; set; }
        public string Type { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public Suspension()
        {
            this.HasSuspension = false;
            this.Type = string.Empty;
            this.Name = string.Empty;
            this.Description = string.Empty;
        }
    }
}
