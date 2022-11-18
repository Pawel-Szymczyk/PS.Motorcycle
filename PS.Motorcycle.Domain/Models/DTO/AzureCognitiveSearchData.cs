using Azure.Search.Documents.Models;
using PS.Motorcycle.Domain.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PS.Motorcycle.Domain.Models.DTO
{
    // class used in Azure Cognitive search (SearchMotorcycles)...
    public class AzureCognitiveSearchData
    {
        // The text to search for.
        public string searchText { get; set; }

        public BodyType bodyType { get; set; }

        // The current page being displayed.
        public int currentPage { get; set; }

        // The total number of pages of results.
        public int pageCount { get; set; }

        // The left-most page number to display.
        public int leftMostPage { get; set; }

        // The number of page numbers to display - which can be less than MaxPageRange towards the end of the results.
        public int pageRange { get; set; }

        // Used when page numbers, or next or prev buttons, have been selected.
        public string paging { get; set; }

        public string bodyTypeFilter { get; set; }


        // The list of results.
        public SearchResults<MotorcycleDTO> resultList;

        public AzureCognitiveSearchData()
        {
            this.searchText = string.Empty;
            this.bodyTypeFilter = string.Empty;
        }
    }


    // filter: *&filter="bodyType eq 4"



    public static class GlobalVariables
    {
        public static int ResultsPerPage
        {
            get
            {
                return 12;
            }
        }
        public static int MaxPageRange
        {
            get
            {
                return 5;
            }
        }

        public static int PageRangeDelta
        {
            get
            {
                return 2;
            }
        }
    }
}
