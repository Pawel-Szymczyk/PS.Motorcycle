using PS.Motorcycle.Domain.Models.Base;
using PS.Motorcycle.Domain.Interfaces;
using PS.Motorcycle.Domain.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace PS.Motorcycle.Domain.Models
{
    public class Motorcycle : TwoWheeler, IMotorcycle
    {
        
        // attributes
        private int lenght;
        private int height;
        private int width;
        private int kerbMass;
        private int sitHeight;
        private int wheelBase;
        private int groundClearance;
        private float price;
        private float fuelCapacity;
        private string brand;
        private string model;
        private TwoWheelerType type;

        private IChassis chassis;
        private IEngine engine;


        // properties
        [JsonProperty("id")]
        public Guid Id { get; set; }

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

        [JsonProperty("wheelBase")]
        public int WheelBase
        {
            get
            {
                return this.wheelBase;
            }

            set
            {
                this.wheelBase = value;
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

        [JsonProperty("brand")]
        public override string Brand
        {
            get
            {
                return this.brand;
            }

            set
            {
                this.brand = value;
            }
        }

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

        // constructors 
        public Motorcycle()
        {
            this.type = TwoWheelerType.MOTORCYCLE;
            this.lenght = 0;
            this.height = 0;
            this.width = 0;
            this.kerbMass = 0;
            this.sitHeight = 0;
            this.wheelBase = 0;
            this.groundClearance = 0;
            this.price = 0;
            this.fuelCapacity = 0;
            this.brand = String.Empty;
            this.model = String.Empty;

            this.engine = new Engine();
            this.chassis = new Chassis();
        }


        //public Motorcycle(IChassis chassis, IEngine engine)
        public Motorcycle(IChassis chassis, IEngine engine)
        {
            this.type = TwoWheelerType.MOTORCYCLE;
            this.brand = String.Empty;
            this.model = String.Empty;

            this.chassis = chassis;
            this.engine = engine;
        }


    }
}
