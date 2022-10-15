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
            

            //IBreak break = new Break();
            IChassis chassis = new Chassis();

            //ISuspension susspension = new ISuspension();
            //ITyre tyre = new Tyre();
            //IWheel wheel = new IWheel();


            //IMotorcycle motorcycle = new Models.Motorcycle(break, chassis, engine, susspension, tyre, wheel);

            //var x = motorcycle.Type;


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