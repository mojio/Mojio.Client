using Mojio.Converters;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace Mojio.Events
{
    /// <summary>
    /// 
    /// </summary>
    public interface IEvent
    {
        /// <summary>
        /// mojio Id
        /// </summary>
        string MojioId { get; set; }

        /// <summary>
        /// owner Id
        /// </summary>
        Guid? OwnerId { get; set; }

        /// <summary>
        /// event type
        /// </summary>
        EventType EventType { get; set; }

        /// <summary>
        /// event timestamp
        /// </summary>
        DateTime Time { get; set; }

        /// <summary>
        /// location
        /// </summary>
        Location Location { get; set; }

        /// <summary>
        /// opcode
        /// </summary>
        string OpCode { get; set; }
    }

    /// <summary>
    /// event
    /// </summary>
    [JsonConverter (typeof(EventConverter))]
    public class Event : GuidEntity, IEvent, IOwner, ICloneable
    {
        public Event()
        {
            ServerTime = DateTime.Now.ToString();
        }

        /// <summary>
        /// mojio Id
        /// </summary>
        public string MojioId { get; set; }

        /// <summary>
        /// owner Id
        /// </summary>
        public Guid? OwnerId { get; set; }

        /// <summary>
        /// event type
        /// </summary>
        public EventType EventType { get; set; }

        /// <summary>
        /// event timestamp
        /// </summary>
        private DateTime _time;
        public DateTime Time {
            get
            {
                return _time;
            }
            set
            {
                _time = value;
                this.UpdateTime();
            }
        }

        /// <summary>
        /// location
        /// </summary>
        public Location Location { get; set; }

        /// <summary>
        /// TimeIsApproximate
        /// </summary>
        public bool? TimeIsApprox { get; set; }

        /// <summary>
        /// opcode
        /// </summary>
        public string OpCode { get; set; }

        /// <summary>
        /// opcode
        /// </summary>
        private string PacificTime { get; set; }

        /// <summary>
        /// opcode
        /// </summary>
        private string ServerTime { get; set; }

        /// <summary>Creates a new object that is a copy of the current instance.</summary>
        /// <returns>A new object that is a copy of this instance.</returns>
        public object Clone ()
        {
            return this.MemberwiseClone ();
        }

        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>A <see cref="System.String" /> that represents this instance.</returns>
        public override string ToString ()
        {
            try {
                string str = "MojioEvent-> ";

                if (this.Location != null && this.Location.IsValid)
                    return str + string.Format ("Type: {0}, Op {1}, Lat {2}, Lng {3}, Time (UTC) {4}, PST: {5}",
                        this.EventType.ToString (),
                        this.OpCode,
                        this.Location.Lat,
                        this.Location.Lng,
                        this.Time != null ? this.Time.ToString() : null,
                        this.PacificTime != null ? this.PacificTime.ToString() : null
                    );
                else
                    return str + string.Format("Type: {0}, Op {1}, Lat {2}, Lng {3}, Time (UTC) {4}, PST: {5}",
                        this.EventType.ToString (),
                        this.OpCode,
                        null,
                        null,
                        this.Time != null ? this.Time.ToString() : null,
                        this.PacificTime != null ? this.PacificTime.ToString() : null
                    );
            } catch (Exception ex) {
                //Console.WriteLine(ex.Message);
                return ex.Message;
            }
        }

        public static DateTime UtcToPacific(DateTime dateTime)
        {
            var zone = TimeZoneInfo.FindSystemTimeZoneById("Pacific Standard Time");
            DateTime newDate = DateTime.SpecifyKind(dateTime, DateTimeKind.Utc);
            return TimeZoneInfo.ConvertTimeFromUtc(newDate, zone);
        }

        public void UpdateTime()
        {
            DateTime dt = DateTime.Parse(this.Time.ToString(), CultureInfo.CurrentCulture, DateTimeStyles.AdjustToUniversal);
            PacificTime = UtcToPacific(dt).ToString();
        }
         
    }
}
