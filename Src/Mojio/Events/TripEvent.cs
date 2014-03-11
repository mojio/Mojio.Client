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
    public class TripEvent : Event
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TripEvent"/> class.
        /// </summary>
        public TripEvent ()
        {
            EventType = Events.EventType.TripEvent;
        }

        /// <summary>Gets or sets the trip identifier.</summary>
        /// <value>The trip identifier.</value>
        public Guid? TripId { get; set; }

        /// <summary>
        /// altitude
        /// </summary>
        public float? Altitude { get; set; }

        /// <summary>
        /// heading degrees
        /// </summary>
        public short? Heading { get; set; }

        /// <summary>
        /// Battery Voltage
        /// </summary>
        public float? BatteryVoltage { get; set; }
        // This property is not saved
        /// <summary>Gets or sets the force trip end.</summary>
        /// <value>The force trip end.</value>
        [JsonIgnore]
        public bool? ForceTripEnd { get; set; }

        /// <summary>
        /// distance
        /// </summary>
        public float? Distance { get; set; }

        /// <summary>
        /// fuel level (percent 0 - 100)
        /// </summary>
        public float? FuelLevel { get; set; }

        /// <summary>
        /// fuel efficiency (liters per 100km)
        /// </summary>
        public float? FuelEfficiency { get; set; }

        /// <summary>
        /// Current speed
        /// </summary>
        public float? Speed { get; set; }

        /// <summary>
        /// Current acceleration
        /// </summary>
        public float? Acceleration { get; set; }

        /// <summary>
        /// Current deceleration
        /// </summary>
        public float? Deceleration { get; set; }

        /// <summary>
        /// stop time
        /// </summary>
        public float? Odometer { get; set; }

        /// <summary>
        /// RPM
        /// </summary>
        public int? RPM { get; set; }

        /// <summary>
        /// Address of this location
        /// </summary>
        public Address Address { get; set; }

        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>A <see cref="System.String" /> that represents this instance.</returns>
        public override string ToString ()
        {
            try {
                string str = base.ToString () + ", ";

                str += string.Format ("Alt {0}, Hdg {1}, Battery {2}, Distance {3}, Fuel {4}, Efficiency {5}, Speed {6}, Odometer {7}, RPM {8}, Address {9}",
                    this.Altitude,
                    this.Heading,
                    this.BatteryVoltage,
                    this.Distance,
                    this.FuelLevel,
                    this.FuelEfficiency,
                    this.Speed,
                    this.Odometer,
                    this.RPM,
                    this.Address == null ? null : this.Address.ToString ());

                return str;
            } catch (Exception ex) {
                //Console.WriteLine(ex.Message);
                return ex.Message;
            }
        }
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
        public float? MaxSpeed { get; set; }

        /// <summary>
        /// average speed
        /// </summary>
        public float? AverageSpeed { get; set; }

        /// <summary>
        /// moving time
        /// </summary>
        public float? MovingTime { get; set; }

        /// <summary>
        /// idle time
        /// </summary>
        public float? IdleTime { get; set; }

        /// <summary>
        /// stop time
        /// </summary>
        public float? StopTime { get; set; }

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

    /// <summary>
    /// trip end event
    /// </summary>
    [CollectionNameAttribute (typeof(Event))]
    public class TripEndEvent : TripStatusEvent
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TripEndEvent"/> class.
        /// </summary>
        public TripEndEvent ()
        {
            EventType = Events.EventType.TripEnd;
        }

        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>A <see cref="System.String" /> that represents this instance.</returns>
        public override string ToString ()
        {
            return "TripEnd:" + base.ToString ();
        }
    }

    /// <summary>
    /// trip start event
    /// </summary>
    [CollectionNameAttribute (typeof(Event))]
    public class TripStartEvent : TripStatusEvent
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TripStartEvent"/> class.
        /// </summary>
        public TripStartEvent ()
        {
            EventType = Events.EventType.TripStart;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TripStartEvent"/> class.
        /// </summary>
        /// <param name="tripEvent">The trip event.</param>
        public TripStartEvent (TripEvent tripEvent)
        {
            EventType = Events.EventType.TripStart;
        }

        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>A <see cref="System.String" /> that represents this instance.</returns>
        public override string ToString ()
        {
            return "TripStart:" + base.ToString ();
        }
    }
}
