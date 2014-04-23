using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mojio
{
    public enum Levels
    {
        /// <summary>Information iteresting to a developer</summary>
        Debug,
        /// <summary>Information interesting to support</summary>
        Info,
        /// <summary>An unexpected situation that the app can recover from</summary>
        Warning,
        /// <summary>An unexpected situation that the app cannot recover from and has to exit</summary>
        Error
    }

    public enum Layer
    {
        TCU,
        TCUProcessor,
        API,
        App
    }

    [Observable]
    public class Log : GuidEntity, IOwner
    {
        public Levels Level { get; set; }
        public Layer? Layer{ get; set; }
        public DateTime Time { get; set; }

        [Observable(typeof(App))]
        public Guid? AppId { get; set; }

        [Observable(typeof(User))]
        public Guid? OwnerId { get; set; }

        public LogType Type { get; set; }

        public string Message { get; set; }

        public Log()
        {
            Level = Levels.Info;
            Type = LogType.Message;
            Time = DateTime.UtcNow;
        }
    }
}
