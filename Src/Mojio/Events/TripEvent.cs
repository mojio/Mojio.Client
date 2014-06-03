using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mojio.Events
{
    /// <summary>
    /// trip status event
    /// </summary>
    [CollectionNameAttribute (typeof(Event))]
    public partial class TripEvent : Event
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TripEvent"/> class.
        /// </summary>
        public TripEvent()
            : this(EventType.TripEvent)
        {
        }

        public TripEvent(EventType type ) : base(type)
        {
        }

        /// <summary>Gets or sets the trip identifier.</summary>
        /// <value>The trip identifier.</value>
        [Observable(typeof(Trip))]
        [Parent(typeof(Trip))]
        public Guid? TripId { get; set; }

        /// <summary>
        /// altitude
        /// </summary>
        public double? Altitude { get; set; }

        /// <summary>
        /// heading degrees
        /// </summary>
        public double? Heading { get; set; }

        // This property is not saved
        /// <summary>Gets or sets the force trip end.</summary>
        /// <value>The force trip end.</value>
        [JsonIgnore]
        public bool? ForceTripEnd { get; set; }

        /// <summary>
        /// distance
        /// </summary>
        public double? Distance { get; set; }

        /// <summary>
        /// fuel level (percent 0 - 100)
        /// </summary>
        public double? FuelLevel { get; set; }

        /// <summary>
        /// fuel efficiency (liters per 100km)
        /// </summary>
        public double? FuelEfficiency { get; set; }

        /// <summary>
        /// Current speed
        /// </summary>
        public double? Speed { get; set; }

        /// <summary>
        /// Current acceleration
        /// </summary>
        public double? Acceleration { get; set; }

        /// <summary>
        /// Current deceleration
        /// </summary>
        public double? Deceleration { get; set; }

        /// <summary>
        /// stop time
        /// </summary>
        public double? Odometer { get; set; }

        /// <summary>
        /// RPM
        /// </summary>
        public int? RPM { get; set; }
    }

    /// <summary>
    /// off status event 
    /// </summary>
    [CollectionNameAttribute (typeof(Event))]
    public class OffStatusEvent : TripEvent
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OffStatusEvent"/> class.
        /// </summary>
        public OffStatusEvent ()
        {
            EventType = Events.EventType.OffStatus;
        }
    }

    /// <summary>
    /// trip status event
    /// </summary>
    [CollectionNameAttribute (typeof(Event))]
    public class TripStatusEvent : TripEvent
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TripStatusEvent"/> class.
        /// </summary>
        public TripStatusEvent ()
        {
            EventType = Events.EventType.TripStatus;
        }

        /// <summary>
        /// max speed
        /// </summary>
        public double? MaxSpeed { get; set; }

        /// <summary>
        /// average speed
        /// </summary>
        public double? AverageSpeed { get; set; }

        /// <summary>
        /// moving time
        /// </summary>
        public double? MovingTime { get; set; }

        /// <summary>
        /// idle time
        /// </summary>
        public double? IdleTime { get; set; }

        /// <summary>
        /// stop time
        /// </summary>
        public double? StopTime { get; set; }

        /// <summary>
        /// Max RPM
        /// </summary>
        public int? MaxRPM { get; set; }

        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>A <see cref="System.String" /> that represents this instance.</returns>
        public override string ToString ()
        {
            try {
                string str = base.ToString () + ", TripEvent-> ";

                str += string.Format ("MaxSpeed {0}, AveSpeed {1}, MovingTime {2}, IdleTime {3}, StopTime {4}, MaxRPM {5}",
                    this.MaxSpeed,
                    this.AverageSpeed,
                    this.MovingTime,
                    this.IdleTime,
                    this.StopTime,
                    this.MaxRPM);

                return str;
            } catch (Exception ex) {
                //Console.WriteLine(ex.Message);
                return ex.Message;
            }
        }
    }

    ///// <summary>
    ///// trip end event
    ///// </summary>
    //[CollectionNameAttribute (typeof(Event))]
    //public class TripEndEvent : TripStatusEvent
    //{
    //    /// <summary>
    //    /// Initializes a new instance of the <see cref="TripEndEvent"/> class.
    //    /// </summary>
    //    public TripEndEvent ()
    //    {
    //        EventType = Events.EventType.TripEnd;
    //    }

    //    /// <summary>
    //    /// Returns a <see cref="System.String" /> that represents this instance.
    //    /// </summary>
    //    /// <returns>A <see cref="System.String" /> that represents this instance.</returns>
    //    public override string ToString ()
    //    {
    //        return "TripEnd:" + base.ToString ();
    //    }
    //}

    ///// <summary>
    ///// trip start event
    ///// </summary>
    //[CollectionNameAttribute (typeof(Event))]
    //public class TripStartEvent : TripStatusEvent
    //{
    //    /// <summary>
    //    /// Initializes a new instance of the <see cref="TripStartEvent"/> class.
    //    /// </summary>
    //    public TripStartEvent ()
    //    {
    //        EventType = Events.EventType.TripStart;
    //    }

    //    /// <summary>
    //    /// Initializes a new instance of the <see cref="TripStartEvent"/> class.
    //    /// </summary>
    //    /// <param name="tripEvent">The trip event.</param>
    //    public TripStartEvent (TripEvent tripEvent)
    //    {
    //        EventType = Events.EventType.TripStart;
    //    }

    //    /// <summary>
    //    /// Returns a <see cref="System.String" /> that represents this instance.
    //    /// </summary>
    //    /// <returns>A <see cref="System.String" /> that represents this instance.</returns>
    //    public override string ToString ()
    //    {
    //        return "TripStart:" + base.ToString ();
    //    }
    //}
}
