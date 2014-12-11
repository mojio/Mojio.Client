using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mojio.Events
{
    /// <summary>
    /// 
    /// </summary>
    [CollectionNameAttribute(typeof(Event))]
    public class HarshMovementEvent : TripEvent
    {
        public double? Harshness { get; set; }

        public HarshMovementEvent()
        {
            EventType = Events.EventType.HarshMovement;
        }

        public void SetHarshness(MojioReport tcuReport)
        {
            //TODO:: figure out some other algorithm that might make more sense that could go into this calculation.
            //TODO:: figure out calibration, subtract out gravity.
            var accelerometer = new Accelerometer()
            {
                X = tcuReport.AccelerometerX,
                Y = tcuReport.AccelerometerY,
                Z = tcuReport.AccelerometerZ,
            };
            Harshness = accelerometer.Magnitude;
        }
    }
}
