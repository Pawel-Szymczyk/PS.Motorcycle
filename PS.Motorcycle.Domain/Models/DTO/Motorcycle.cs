using PS.Motorcycle.Domain.Models.Base;
using PS.Motorcycle.Domain.Interfaces;
using PS.Motorcycle.Domain.Types;
using Newtonsoft.Json;
using Azure.Search.Documents.Indexes;
using System.Text.Json.Serialization;
using PS.Motorcycle.Domain.Interfaces.DTO;

namespace PS.Motorcycle.Domain.Models.DTO
{
    public class MotorcycleDTO : IMotorcycleDTO
    {

        // attributes
        private Guid id;
        private int productionYear;
        private float price;
        private float fuelCapacity;
        private string make;
        private string model;
        private TwoWheelerType type;
        private BodyType bodyType;
        private string imageUrl;
        private string logoUrl;


        // properties
        //[SimpleField(IsKey = true, IsFilterable = true)]
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

        [JsonPropertyName("year")]
        public int ProductionYear
        {
            get
            {
                return this.productionYear;
            }

            set
            {
                this.productionYear = value;
            }
        }

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

        //[SearchableField(IsSortable = true)]
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

        //[SearchableField(IsSortable = true)]
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
        }

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
        }




    }
}
