using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PS.Motorcycle.Domain.Models
{
    internal class Suspension
    {
        private bool HasSuspension { get; set; }
        private string Type { get; set; }
        private string Name { get; set; }
        private string Description { get; set; }

        public Suspension()
        {
            this.HasSuspension = false;
            this.Type = string.Empty;
            this.Name = string.Empty;
            this.Description = string.Empty;
        }
    }
}
