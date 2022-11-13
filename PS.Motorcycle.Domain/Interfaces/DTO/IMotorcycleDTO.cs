using PS.Motorcycle.Domain.Types;

namespace PS.Motorcycle.Domain.Interfaces.DTO
{
    public interface IMotorcycleDTO
    {
        BodyType BodyType { get; set; }
        float FuelCapacity { get; set; }
        Guid Id { get; set; }
        string ImageUrl { get; set; }
        string LogoUrl { get; set; }
        string Make { get; set; }
        string Model { get; set; }
        float Price { get; set; }
        int ProductionYear { get; set; }
        TwoWheelerType Type { get; set; }
        string CreateDate { get; set; }
        string UpdateDate { get; set; }
        int Rate { get; set; }
    }
}