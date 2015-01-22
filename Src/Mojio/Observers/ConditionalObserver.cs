using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mojio
{
    [CollectionNameAttribute("Observer")]
    public partial class ConditionalObserver : ConditionalObserverBase
    {
        /// <summary>
        /// Field of the entity for the conditional test required.
        /// </summary>
        public string Field { get; set; } 

		/// <summary>
		/// First threshold used in the conditional, required.
		/// </summary>
        public double Threshold1 { get; set; }

        /// <summary>
        /// Second threshold used in the conditional, optional.
        /// </summary>
        public double? Threshold2 { get; set; }

        /// <summary>
        /// First operator (<, > , <=, >=, ==, !=) used in the conditional, required.
        /// </summary>
        public string Operator1 { get; set; }

        /// <summary>
        /// Second operator (<, > , <=, >=, ==, !=) used in the conditional, optional.
        /// </summary>
        public string Operator2 { get; set; }

        /// <summary>
        /// conjunction between (and, or) used in the conditional, optional.
        /// </summary>
        public string Conjunction { get; set; }   

		/// <summary>
		/// True when the Field is within the bounds of the operators and thresholds.
		/// </summary>
        public bool? ConditionValue { get; set; }

        public ConditionalObserver()
            : base(ObserverType.Conditional, ObserverTiming.edge)
        {

        }

        /// <summary>
        /// The operators can be <, > , <=, >=, ==, !=
        /// <param name="type"></param>
        /// <param name="subject">The</param>
        /// <param name="parent"></param>
        /// <param name="field">The name of the field on the entity where the condition will be applied</param>
        /// <param name="operator1">Comparitor against the threshold</param>
        /// <param name="threshold1">The threshold</param>
        /// <param name="operator2">Optional second operator for a second threshold</param>
        /// <param name="threshold2">Optional second threshold</param>
        /// <param name="conjunction">Logical operator to combine the two thresholds.</param>
        /// </summary>
        public ConditionalObserver(Type subject = null, Guid subjectId = new Guid(),
            string field="Speed", string operator1=">", double threshold1=80.0,
            ObserverTiming timing = ObserverTiming.edge
            )
            : this(subject, subjectId, null, new Guid(),
                field, operator1, threshold1,
                null, null, null, 
                timing)
        {
        }

        public ConditionalObserver(Type subject = null, Guid subjectId = new Guid(),
            string field = "Speed", string operator1 = ">", double threshold1 = 80.0,
            string operator2 = "<", double? threshold2 = 100.0, string conjunction = "and",
            ObserverTiming timing = ObserverTiming.edge
            )
            : this(subject, subjectId, null, new Guid(),
                field, operator1, threshold1,
                operator2, threshold2, conjunction, 
                timing)
        {
        }
        public ConditionalObserver(Type subject = null, Guid subjectId = new Guid(),
            Type parent = null, Guid parentId = new Guid(),
            string field="Speed", string operator1=">", double threshold1=80.0,
            ObserverTiming timing = ObserverTiming.edge
            )
            : this( subject,  subjectId, parent, parentId, 
                field,  operator1,  threshold1,
                null, null,  null, 
                timing)
        {
        }

        public ConditionalObserver(Type subject = null, Guid subjectId = new Guid(),
            Type parent = null, Guid parentId = new Guid(),
            string field = "Speed", string operator1 = ">", double threshold1 = 80.0,
            string operator2 = "<", double? threshold2 = 100.0, string conjunction = "and",
            ObserverTiming timing = ObserverTiming.edge
            )
            : base(ObserverType.Conditional, subject, parent, timing)
        {
            SubjectId = subjectId;
            ParentId = parentId;
            SetCondition(field, operator1, threshold1, operator2, threshold2, conjunction);
        }

        public void SetCondition(string field, string operator1, double threshold1, 
            string operator2=null, double? threshold2=null, string conjunction=null)
        {
            Field = field;
            Threshold1 = threshold1;
            Threshold2 = threshold2;
            Operator1 = operator1;
            Operator2 = operator2;
            Conjunction = conjunction;
        }

    }
}
