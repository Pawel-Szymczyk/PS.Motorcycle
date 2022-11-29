using PS.Motorcycle.Domain.Models.Base;
using PS.Motorcycle.Domain.Interfaces;
using PS.Motorcycle.Domain.Types;
using Newtonsoft.Json;
using Azure.Search.Documents.Indexes;
using System.Text.Json.Serialization;
using PS.Motorcycle.Domain.Interfaces.DTO;
using System.Globalization;

namespace PS.Motorcycle.Domain.Models.DTO
{
    public class EngineDTO
    {
        [SearchableField(IsFilterable = true, IsSortable = true, IsFacetable = true)]
        public int Capacity { get; set; }

        [SearchableField(IsFilterable = true, IsSortable = true, IsFacetable = true)]
        public string Drive { get; set; }

        [SearchableField(IsFilterable = true, IsSortable = true, IsFacetable = true)]
        public string Power { get; set; }
    }

    public class MotorcycleDTO : IMotorcycleDTO
    {

        // attributes
        private Guid id;
        private int year;
        private float price;
        private float fuelCapacity;
        private string make;
        private string model;
        private TwoWheelerType type;
        private BodyType bodyType;
        private string imageUrl;
        private string logoUrl;
        private string createDate;
        private string updateDate;
        private int rate;


        // properties
        [SimpleField(IsKey = true)]
        [JsonPropertyName("id")]
        public Guid Id
        {
            get
            {
                return this.id;
            }

            set
            {
                this.id = value;
            }
        }

        [SimpleField(IsFilterable = true, IsSortable = true)]
        [JsonPropertyName("year")]
        public int Year
        {
            get
            {
                return this.year;
            }

            set
            {
                this.year = value;
            }
        }

        [SimpleField(IsFilterable = true, IsSortable = true)]
        [JsonPropertyName("price")]
        public float Price
        {
            get
            {
                return this.price;
            }

            set
            {
                this.price = value;
            }
        }

        [SimpleField(IsFilterable = true, IsSortable = true, IsFacetable = true)]
        [JsonPropertyName("fuelCapacity")]
        public float FuelCapacity
        {
            get
            {
                return this.fuelCapacity;
            }

            set
            {
                this.fuelCapacity = value;
            }
        }

        [SearchableField(IsFilterable = true, IsSortable = true, IsFacetable = true)]
        [JsonPropertyName("make")]
        public string Make
        {
            get
            {
                return this.make;
            }

            set
            {
                this.make = value;
            }
        }

        [SearchableField(IsFilterable = true, IsSortable = true, IsFacetable = true)]
        [JsonPropertyName("model")]
        public string Model
        {
            get
            {
                return this.model;
            }

            set
            {
                this.model = value;
            }
        }

        [SimpleField(IsFilterable = true, IsSortable = true, IsFacetable = true)]
        [JsonPropertyName("type")]
        public TwoWheelerType Type
        {
            get
            {
                return this.type;
            }

            set
            {
                this.type = value;
            }
        } // we do not need it...

        [SimpleField(IsFilterable = true, IsSortable = true, IsFacetable = true)]
        [JsonPropertyName("bodyType")]
        public BodyType BodyType
        {
            get
            {
                return this.bodyType;
            }

            set
            {
                this.bodyType = value;
            }
        }

        [JsonPropertyName("imageUrl")]
        public string ImageUrl
        {
            get
            {
                return this.imageUrl;
            }

            set
            {
                this.imageUrl = value;
            }
        }

        [JsonPropertyName("logoUrl")]
        public string LogoUrl
        {
            get
            {
                return this.logoUrl;
            }

            set
            {
                this.logoUrl = value;
            }
        }

        [JsonPropertyName("createDate")]
        public string CreateDate
        {
            get
            {
                
                return this.createDate;
            }

            set
            {
                var dateTime = DateTimeOffset.FromUnixTimeSeconds((long)Convert.ToDouble(value)).UtcDateTime.ToString();
                this.createDate = dateTime;
            }
        }

        [JsonPropertyName("updateDate")]
        public string UpdateDate
        {
            get
            {
                return this.updateDate;
            }

            set
            {
                var dateTime = DateTimeOffset.FromUnixTimeSeconds((long)Convert.ToDouble(value)).UtcDateTime.ToString();
                this.updateDate = dateTime;
            }
        }

        [JsonPropertyName("rate")]
        public int Rate
        {
            get
            {
                return this.rate;
            }

            set
            {
                this.rate = value;
            }
        }

        [SearchableField]
        [JsonPropertyName("engine")]
        public EngineDTO Engine { get; set; }

        // constructors 
        public MotorcycleDTO()
        {
            this.type = TwoWheelerType.MOTORCYCLE;
            this.bodyType = BodyType.NONE;
            this.price = 0;
            this.fuelCapacity = 0;
            this.make = String.Empty;
            this.model = String.Empty;
            this.imageUrl = String.Empty;
            this.logoUrl = String.Empty;

            this.createDate = string.Empty;
            this.updateDate = string.Empty;
            this.rate = 0;

            
        }




    }
}
