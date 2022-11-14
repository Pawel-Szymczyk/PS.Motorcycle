using PS.Motorcycle.Domain.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PS.Motorcycle.Domain.Models.DTO
{
    public class MotorcycleResponse<T>
    {
        public IEnumerable<T> Items { get; set; }

        public Paging Paging { get; set; }
    }
}
