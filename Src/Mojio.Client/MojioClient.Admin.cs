using System;

namespace Mojio.Client
{
    public partial class MojioClient
    {
        /// <summary>
        /// imports one or more devices
        /// </summary>
        /// <param name="items">each row is of the format: imei,name,pin,msisdn</param>
        /// <returns></returns>
        public Task<MojioResponse<List<Device>>> ImportDevicesAsync(List<string> items)
        {
            string controller = "admin";

            var request = GetRequest(Request(controller, "none", "importdevices"), Method.POST);

            request.AddBody(items);

            return RequestAsync<List<Device>>(request);
        }

        /// <summary>
        /// imports one or more devices
        /// </summary>
        /// <param name="items">each row is of the format: imei,name,pin,msisdn</param>
        /// <returns></returns>
        public Task<MojioResponse<Results<Events.Event>>> GetAllEvents(int? pageSize, int? pageOffset, List<string> mojioIds, List<Guid> tripIds, DateTime? start, DateTime? end, List<Events.EventType> eventTypes)
        {
            string controller = "admin";

            var request = GetRequest(Request(controller, "none", "getallevents"), Method.POST);

            var json = new System.Dynamic.ExpandoObject();

            json.PageSize = pageSize ?? 0;
            json.PageOffset = pageOffset ?? 0;
            json.MojioIds = mojioIds;
            json.TripIds = tripIds;
            json.Start = start;
            json.End = end;
            json.EventTypes = eventTypes;

            request.AddBody(json);

            return RequestAsync<Results<Events.Event>>(request);
        }
    }
}

