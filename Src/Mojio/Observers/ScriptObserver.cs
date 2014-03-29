using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mojio
{
    [CollectionNameAttribute("Observer")]
    public partial class ScriptObserver : ConditionalObserver
    {
        public ScriptObserver()
            : base(ObserverType.Script)
        {

        }

        public string Script { get; set; }
    }
}
