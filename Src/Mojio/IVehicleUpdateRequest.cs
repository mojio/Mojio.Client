using System;
namespace Mojio
{
    public interface IVehicleUpdateRequest
    {
        string LicensePlate { get; set; }
        string Name { get; set; }
        int? Odometer { get; set; }
        string VIN { get; set; }
    }
}
