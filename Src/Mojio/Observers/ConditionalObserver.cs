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
        /// Second operator (<, > , <=, >=, ==, !=) used in the conditional, optional.
        /// </summary>
        public string Conjunction { get; set; }   

		/// <summary>
		/// True when the Field is within the bounds of the operators and thresholds.
		/// </summary>
        public bool? ConditionValue { get; set; }

        public ConditionalObserver(ObserverType type)
            : base(ObserverType.Conditional)
        {

        }

        public ConditionalObserver(ObserverType type, 
            string field, string operator1, double threshold1, 
            string operator2=null, double? threshold2=null, string conjunction=null,
            Type subject = null, Type parent = null)
            : base(type, subject, parent)
        {
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
