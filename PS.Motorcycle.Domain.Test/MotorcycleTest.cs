using PS.Motorcycle.Domain.Interfaces;
using PS.Motorcycle.Domain;
using PS.Motorcycle.Domain.Models;

namespace PS.Motorcycle.Domain.Test
{
    [TestClass]
    public class MotorcycleTest
    {
        [TestMethod]
        public void CreateMotorcycleObjectTest()
        {
            IEngine engine = new Engine()
            {
                Capacity = 999,
                Bore = "73.4 x 59.0 (2.89 in x 2.32 in)",
                Lubrication = "Wet Sump",
                FuelSystem = "Fuel Injection",
                Drive = "chain",
                Mpg = (float)46.31,
                Power = "112 kW @ 11,000 rpm (152 PS)",
                EngineDescription = "4-stroke, 4-cylinder, liquid-cooled, DOHC",
                CompressionRatio = "12.2 : 1",
                Ignition = "Electronic ignition (transistorised)",
                Transmission = "6-speed constant mesh",
                Starter = "Electric",
                Co2 = "143g/km",
                Torque = "106.0 Nm @ 9,250rpm (78.18 lb. ft)†"
            };


            List<Break> breaks = new List<Break>();
            Break frontBreak = new Break() 
            { 
                Name = "Disc, twin",
                NumberOfDiscs = 2,
                Type = "Front"
            };
            Break rearBreak = new Break()
            {
                Name = "Disc",
                NumberOfDiscs = 1,
                Type = "Rear"
            };

            breaks.Add(frontBreak);
            breaks.Add(rearBreak);

            List<Suspension> suspensions = new List<Suspension>();
            Suspension frontSuspension = new Suspension()
            {
                HasSuspension = true,
                Description = "Inverted telescopic, coil spring, oil damped",
                Type = "Front"
                
            };
            Suspension rearSuspension = new Suspension()
            {
                HasSuspension = true,
                Description = "Link type, coil spring, oil damped",
                Type = "Rear"
            };

            suspensions.Add(frontSuspension);
            suspensions.Add(rearSuspension);

            List<Wheel> wheels = new List<Wheel>();
            Wheel frontWheel = new Wheel()
            {
                RimDiameter = 17,
                Type = "Front", 
                Tyre = new Tyre()
                {
                    Brand = "Michelin",
                    SpeedIndex = "W - up to over 169mph",
                    LoadIndexOfTire = 58,
                    Profile = 70,
                    RimDiameter = 17,
                    Width = 120
                }
            };
            Wheel rearWheel = new Wheel()
            {
                RimDiameter = 17,
                Type = "Rear",
                Tyre = new Tyre()
                {
                    Brand = "Michelin",
                    SpeedIndex = "W - up to over 169mph",
                    LoadIndexOfTire = 73,
                    Profile = 50,
                    RimDiameter = 17,
                    Width = 190
                }
            };

            wheels.Add(frontWheel);
            wheels.Add(rearWheel);


            IChassis chassis = new Chassis()
            {
                Breaks = breaks,
                Suspensions = suspensions,
                Wheels = wheels
            };




            IMotorcycle motorcycle = new Models.Motorcycle(chassis, engine);

            // works
            //motorcycle.Engine.Capacity = 1200;

            engine.Capacity = 1200;
            motorcycle.Engine = engine;


            // Arrange
            // Act
            // Assert
        }
    }
}