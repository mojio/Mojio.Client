using System;
using System.Threading.Tasks;

namespace Mojio.Client
{
    public partial class MojioClient
    {
        /// <summary>
        ///     Get the service schedule associated with a vehicle.
        /// </summary>
        /// <param name="id">Trip</param>
        /// <returns></returns>
        public async Task<MojioResponse<Results<VehicleService>>> GetVehicleServiceScheduleAsync(Guid id)
        {
            return await GetByAsync<VehicleService, Vehicle>(id);
        }
    }
}