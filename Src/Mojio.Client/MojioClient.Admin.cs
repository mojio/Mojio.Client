using Mojio.Client.Linq;
using Mojio.Events;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Mojio.Client
{
    public partial class MojioClient
    {
        /// <summary>
        /// imports one or more devices
        /// </summary>
        /// <param name="items">each row is of the format: imei,name,pin,msisdn</param>
        /// <returns></returns>
        public Task<MojioResponse<List<Mojio>>> ImportMojiosAsync(List<string> items)
        {
            string controller = "admin";

            var request = GetRequest(Request(controller, "none", "importdevices"), Method.POST);

            request.AddBody(items);

            return RequestAsync<List<Mojio>>(request);
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

            dynamic json = new System.Dynamic.ExpandoObject();

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

        /// <summary>
        /// get device logs
        /// </summary>
        /// <param name="pageSize"></param>
        /// <param name="pageOffset"></param>
        /// <param name="ids"></param>
        /// <param name="imeis"></param>
        /// <param name="mojioIds"></param>
        /// <param name="ownerIds"></param>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <param name="vehicleIds"></param>
        /// <returns></returns>
        public Task<MojioResponse<Results<DeviceLog>>> GetDeviceLogs(int? pageSize, int? pageOffset, List<Guid> ids, List<string> imeis, List<Guid> mojioIds, List<Guid> ownerIds, DateTime? start, DateTime? end, List<Guid> vehicleIds)
        {
            var request = GetRequest(Request("admin", "none", "DeviceLogs"), Method.POST);

            dynamic json = new System.Dynamic.ExpandoObject();

            json.PageSize = pageSize ?? 0;
            json.PageOffset = pageOffset ?? 0;
            json.Ids = ids;
            json.Imeis = imeis;
            json.MojioIds = mojioIds;
            json.OwnerIds = ownerIds;
            json.Start = start;
            json.End = end;
            json.VehicleIds = vehicleIds;

            request.AddBody(json);

            return RequestAsync<Results<DeviceLog>>(request);
        }

        /// <summary>
        /// replays all events
        /// </summary>
        /// <param name="timeShift">whether to shift timing (null means start at current time)</param>
        /// <param name="timeFactor">factor to increase / decrease time by</param>
        /// <param name="events"></param>
        /// <returns></returns>
        public Task<MojioResponse> ReplayEvents(TimeSpan? timeShift, double? timeFactor, List<Events.Event> events)
        {
            string controller = "admin";

            var request = GetRequest(Request(controller, "none", "replayevents"), Method.POST);

            dynamic json = new System.Dynamic.ExpandoObject();

            json.TimeShift = timeShift;
            json.TimeFactor = timeFactor ?? 1.0;
            json.Events = events;

            request.AddBody(json);

            return RequestAsync(request);
        }
    }
}

