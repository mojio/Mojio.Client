using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mojio
{
    [CollectionNameAttribute("Observer")]
    public partial class BooleanFieldObserver : ConditionalObserverBase
    {
        /// <summary>
        /// Field of the entity for the conditional test required.
        /// </summary>
        public string Field { get; set; }

        /// <summary>
        /// True when the Field is within the bounds of the operators and thresholds.
        /// </summary>
        public bool? ConditionValue { get; set; }

        public BooleanFieldObserver()
            : base(ObserverType.BooleanField, ObserverTiming.edge)
        {
        }

        /// <summary>
        /// The operators can be <, > , <=, >=, ==, !=
        /// <param name="type"></param>
        /// <param name="subject">The</param>
        /// <param name="parent"></param>
        /// <param name="field">The name of the field on the entity where the condition will be applied</param>
        /// </summary>
        public BooleanFieldObserver(Type subject = null, Guid subjectId = new Guid(),
            string field = "Speed",
            ObserverTiming timing = ObserverTiming.edge
            )
            : this(subject, subjectId, null, new Guid(),
                field, timing)
        {
        }

        public BooleanFieldObserver(Type subject = null, Guid subjectId = new Guid(),
            Type parent = null, Guid parentId = new Guid(),
            string field = "Speed", 
            ObserverTiming timing = ObserverTiming.edge
            )
            : base(ObserverType.BooleanField, subject, parent, timing)
        {
            SubjectId = subjectId;
            ParentId = parentId;
            Field = field;
        }
    }
}
