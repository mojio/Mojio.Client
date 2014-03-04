using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mojio.Events
{
    public class Log : Event
    {
        public enum Levels
        {
            Debug,
            Info,
            Warning,
            Error,
            Fatal
        }

        public Log()
        {
            EventType = Events.EventType.Log;
        }

        /// <summary>
        /// App at the time of the log event
        /// </summary>
        public Guid? AppId { get; set; }

        /// <summary>
        /// Diagnostic message level
        /// Message level describes the type of message and its severity
        /// </summary>
        [DefaultValue(-1)]
        public Levels Level { get; set; }

        /// <summary>
        /// message
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// user id
        /// </summary>
        public Guid? UserId { get; set; }

        public string ControllerName { get; set; }

        public string ActionName { get; set; }
    }
}
