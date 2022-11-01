using Azure.Search.Documents.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PS.Motorcycle.Domain.Models
{
    public class Search
    {
        // The text to search for.
        public string SearchText { get; set; }

        // The list of results.
        public SearchResults<Motorcycle> resultList { get; set; }
    }
}
