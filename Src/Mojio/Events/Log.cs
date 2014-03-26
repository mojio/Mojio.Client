using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mojio.Events
{
    /// <summary>
    /// 
    /// </summary>
    public class Log : Event
    {
        /// <summary>
        /// 
        /// </summary>
        public enum Levels
        {
            /// <summary>The debug</summary>
            Debug,
            /// <summary>The information</summary>
            Info,
            /// <summary>The warning</summary>
            Warning,
            /// <summary>The error</summary>
            Error,
            /// <summary>The fatal</summary>
            Fatal,
            /// <summary>TCU Report</summary>
            TCUReport,
        }

        /// <summary>Initializes a new instance of the <see cref="Log"/> class.</summary>
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
        /// Device IMEI
        /// </summary>
        public string Imei { get; set; }

        /// <summary>
        /// user id
        /// </summary>
        public Guid? UserId { get; set; }

        /// <summary>Gets or sets the name of the controller.</summary>
        /// <value>The name of the controller.</value>
        public string ControllerName { get; set; }

        /// <summary>Gets or sets the name of the action.</summary>
        /// <value>The name of the action.</value>
        public string ActionName { get; set; }
    }
}
