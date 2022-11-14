using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PS.Motorcycle.Domain.Models.DTO
{
    public class MotorcycleRequest
    {
        public string SearchPhrase { get; set; } // search work
        public string OrderBy { get; set; } = "Make"; // oder by specified item
        public int PageNumber { get; set; } // current page
        public int PageSize { get; set; } // page size
        public bool AscendingOrder { get; set; } // ascending if true, otherwise discending order

    }
}
