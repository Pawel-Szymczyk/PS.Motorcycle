using PS.Motorcycle.Domain.Models.Base;
using PS.Motorcycle.Domain.Interfaces;
using PS.Motorcycle.Domain.Types;
using Newtonsoft.Json;
using Azure.Search.Documents.Indexes;
using System.Text.Json.Serialization;

namespace PS.Motorcycle.Domain.Models
{
    public class Motorcycle : TwoWheeler, IMotorcycle
    {

        // attributes
        private Guid id;
        private string about;
        private string imageUrl;
        private string imagesGalleryUrls;
        private string logoUrl;

        private int lenght;
        private int height;
        private int width;
        private int kerbMass;
        private int sitHeight;
        private int wheelbase;
        private int groundClearance;
        private int productionYear;
        private float price;
        private float fuelCapacity;
        private string make;
        private string model;
        private TwoWheelerType type;
        private BodyType bodyType;

        private IChassis chassis;
        private IEngine engine;


        private long createDate;
        private long updateDate;

        private int rate;
        private string opinion;

        // properties
        //[SimpleField(IsKey = true, IsFilterable = true)]
        [JsonProperty("id")]
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

        [JsonProperty("lenght")]
        public override int Length 
        {
            get
            {
                return this.lenght;
            }

            set
            {
                this.lenght = value;
            }
        }

        [JsonProperty("height")]
        public override int Height 
        {
            get
            {
                return this.height;
            }

            set
            {
                this.height = value;
            }
        }

        [JsonProperty("width")]
        public override int Width 
        {
            get
            {
                return this.width;
            }

            set
            {
                this.width = value;
            }
        }

        [JsonProperty("kerbMass")]
        public override int KerbMass 
        {
            get
            {
                return this.kerbMass;
            }

            set
            {
                this.kerbMass = value;
            }
        }

        [JsonProperty("sitHeight")]
        public int SitHeight
        {
            get
            {
                return this.sitHeight;
            }

            set
            {
                this.sitHeight = value;
            }
        }

        [JsonProperty("wheelbase")]
        public int Wheelbase
        {
            get
            {
                return this.wheelbase;
            }

            set
            {
                this.wheelbase = value;
            }
        }

        [JsonProperty("groundClearance")]
        public int GroundClearance
        {
            get
            {
                return this.groundClearance;
            }

            set
            {
                this.groundClearance = value;
            }
        }

        [JsonProperty("year")]
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

        [JsonProperty("price")]
        public override float Price
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

        [JsonProperty("fuelCapacity")]
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
        [JsonProperty("make")]
        public override string Make
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
        [JsonProperty("model")]
        public override string Model
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

        [JsonProperty("type")]
        public override TwoWheelerType Type
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

        [JsonProperty("bodyType")]
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

        [JsonProperty("chassis")]
        public IChassis Chassis
        //public Chassis Chassis
        {
            get
            {
                return this.chassis;
            }

            set
            {
                this.chassis = value;
            }
        }

        [JsonProperty("engine")]
        public IEngine Engine
        //public Engine Engine
        {
            get
            {
                return this.engine;
            }

            set
            {
                this.engine = value;
            }
        }

        [JsonProperty("about")]
        public string About
        {
            get
            {
                return this.about;
            }

            set
            {
                this.about = value;
            }
        }

        [JsonProperty("imageUrl")]
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

        [JsonProperty("imagesGalleryUrls")]
        public string ImagesGalleryUrls
        {
            get
            {
                return this.imagesGalleryUrls;
            }

            set
            {
                this.imagesGalleryUrls = value;
            }
        }

        [JsonProperty("logoUrl")]
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





     


        [JsonProperty("createDate")]
        public long CreateDate
        {
            get
            {
                return this.createDate;
            }

            set
            {
                this.createDate = value;
            }
        }

        [JsonProperty("updateDate")]
        public long UpdateDate
        {
            get
            {
                return this.updateDate;
            }

            set
            {
                this.updateDate = value;
            }
        }

        [JsonProperty("opinion")]
        public string Opinion
        {
            get
            {
                return this.opinion;
            }

            set
            {
                this.opinion = value;
            }
        }

        [JsonProperty("rate")]
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


        // constructors 
        public Motorcycle()
        {
            this.type = TwoWheelerType.MOTORCYCLE;
            this.bodyType = BodyType.NONE;
            this.lenght = 0;
            this.height = 0;
            this.width = 0;
            this.kerbMass = 0;
            this.sitHeight = 0;
            this.wheelbase = 0;
            this.groundClearance = 0;
            this.price = 0;
            this.fuelCapacity = 0;
            this.make = String.Empty;
            this.model = String.Empty;

            this.about = String.Empty;
            this.imageUrl = String.Empty;
            this.imagesGalleryUrls = String.Empty;
            this.logoUrl = String.Empty;

            // add type: naked , sport, etc.

            this.engine = new Engine();
            this.chassis = new Chassis();

            this.createDate = new DateTimeOffset(DateTime.UtcNow).ToUnixTimeSeconds();
            this.updateDate = new DateTimeOffset(DateTime.UtcNow).ToUnixTimeSeconds();
            this.rate = 0;
            this.opinion = string.Empty;
        }


        //public Motorcycle(IChassis chassis, IEngine engine)
        public Motorcycle(IChassis chassis, IEngine engine)
        {
            this.type = TwoWheelerType.MOTORCYCLE;
            this.bodyType = BodyType.NONE;
            this.make = String.Empty;
            this.model = String.Empty;

            this.about = String.Empty;
            this.imageUrl = String.Empty;
            this.imagesGalleryUrls = String.Empty;
            this.logoUrl = String.Empty;

            this.chassis = chassis;
            this.engine = engine;

            this.createDate = new DateTimeOffset(DateTime.UtcNow).ToUnixTimeSeconds();
            this.updateDate = new DateTimeOffset(DateTime.UtcNow).ToUnixTimeSeconds();
            this.rate = 0;
            this.opinion = string.Empty;
        }


    }
}
