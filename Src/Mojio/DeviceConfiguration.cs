using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace Mojio
{
    /// <summary>
    /// 
    /// </summary>
    public enum DeviceType : int
    {
        /// <summary>The xirgo</summary>
        Xirgo = 1,
    }

    /// <summary>
    /// 
    /// </summary>
    public class DeviceConfiguration : StringEntity
    {
        /// <summary>Gets or sets the type of the device.</summary>
        /// <value>The type of the device.</value>
        public DeviceType DeviceType { get; set; }
        
        /// <summary>Gets or sets the name of the profile.</summary>
        /// <value>The name of the profile.</value>
        public string ProfileName
        {
            get { return Id; }
            set { Id = value; }
        }
        
        /// <summary>Gets or sets the date modified.</summary>
        /// <value>The date modified.</value>
        public DateTime DateModified { get; set; }
        
        /// <summary>Gets or sets the firmware version.</summary>
        /// <value>The firmware version.</value>
        public string FirmwareVersion { get; set; }
        
        /// <summary>Gets or sets the server version.</summary>
        /// <value>The server version.</value>
        public string ServerVersion { get; set; }

        /// <summary>The configurations</summary>
        public Dictionary<string, BaseConfig> Configurations = new Dictionary<string, BaseConfig>();
    }

    /// <summary>
    /// 
    /// </summary>
    public class BaseConfig
    {
        /// <summary>
        /// Mnemonic code of configuration parameter
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// Configuration parameter description
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Units of parameter
        /// </summary>
        public string Units { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    public class BaseValueInt : BaseConfig
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BaseValueInt"/> class.
        /// </summary>
        /// <param name="code">The code.</param>
        /// <param name="desc">The desc.</param>
        /// <param name="units">The units.</param>
        public BaseValueInt(string code, string desc, string units)
        {
            Code = code;
            Description = desc;
            Units = units;
        }

        /// <summary>Gets the minimum.</summary>
        /// <value>The minimum.</value>
        public int Min { get; private set; }

        /// <summary>Gets the maximum.</summary>
        /// <value>The maximum.</value>
        public int Max { get; private set; }

        /// <summary>Gets the value.</summary>
        /// <value>The value.</value>
        public int Value { get; private set; }
        
        /// <summary>Gets the resolution.</summary>
        /// <value>The resolution.</value>
        public int Resolution { get; private set; }
        
        /// <summary>
        /// Gets or sets a value indicating whether [ignore zero value].
        /// </summary>
        /// <value><c>true</c> if [ignore zero value]; otherwise, <c>false</c>.</value>
        public bool IgnoreZeroValue { get; set; }

        /// <summary>Sets the configuration.</summary>
        /// <param name="min">The minimum.</param>
        /// <param name="max">The maximum.</param>
        /// <param name="val">The value.</param>
        /// <param name="res">The resource.</param>
        /// <param name="ignoreZero">if set to <c>true</c> [ignore zero].</param>
        public void SetConfig(int min, int max, int val, int res, bool ignoreZero = false)
        {
            Min = min;
            Max = max;
            Value = val;
            Resolution = res;
            IgnoreZeroValue = ignoreZero;
            Parse();
        }

        /// <summary>Sets the value.</summary>
        /// <param name="value">The value.</param>
        public void SetValue(int value)
        {
            Parse();
            Value = value;
        }

        private void Parse()
        {
            if (IgnoreZeroValue && Value == 0)
                return;

            if (Min > Max)
                throw new ArgumentException(String.Format("{0}: Invalid min/max thresholds.  min: {1}, max: {2}", base.Code, Min, Max));
            else if (Value < Min)
                throw new ArgumentException(String.Format("{0}: val: {1} less than min: {2}", base.Code, Value, Min));
            else if (Value > Max)
                throw new ArgumentException(String.Format("Configuration val: {0} is greater than max: {1}", Value, Max));
            else if ((Value != 0) && Value % Resolution > 0)
                throw new ArgumentException(String.Format("Configuration val: {0} not within res: {1}", Value, Resolution));
            else
                return;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public class BaseValueFloat : BaseConfig
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BaseValueFloat"/> class.
        /// </summary>
        /// <param name="code">The code.</param>
        /// <param name="desc">The desc.</param>
        /// <param name="units">The units.</param>
        public BaseValueFloat(string code, string desc, string units)
        {
            Code = code;
            Description = desc;
            Units = units;
            Epsilon = 0.001f;
        }

        /// <summary>Gets the minimum.</summary>
        /// <value>The minimum.</value>
        public float Min { get; private set; }

        /// <summary>Gets the maximum.</summary>
        /// <value>The maximum.</value>
        public float Max { get; private set; }

        /// <summary>Gets the value.</summary>
        /// <value>The value.</value>
        public float Value { get; private set; }

        /// <summary>Gets the resolution.</summary>
        /// <value>The resolution.</value>
        public float Resolution { get; private set; }
        
        /// <summary>Gets or sets the epsilon.</summary>
        /// <value>The epsilon.</value>
        public float Epsilon { get; set; }
        
        /// <summary>
        /// Gets or sets a value indicating whether [ignore zero value].
        /// </summary>
        /// <value><c>true</c> if [ignore zero value]; otherwise, <c>false</c>.</value>
        public bool IgnoreZeroValue { get; set; }

        /// <summary>Sets the configuration.</summary>
        /// <param name="min">The minimum.</param>
        /// <param name="max">The maximum.</param>
        /// <param name="val">The value.</param>
        /// <param name="res">The resource.</param>
        /// <param name="ignoreZero">if set to <c>true</c> [ignore zero].</param>
        public void SetConfig(float min, float max, float val, float res, bool ignoreZero = false)
        {
            Epsilon = 0.001f;
            Parse();
            Min = min;
            Max = max;
            Value = val;
            IgnoreZeroValue = ignoreZero;
            Resolution = res;
        }

        /// <summary>Sets the value.</summary>
        /// <param name="value">The value.</param>
        public void SetValue(float value)
        {
            Parse();
            Value = value;
        }

        private void Parse()
        {
            if (IgnoreZeroValue && Value == 0)
                return;

            if (Min > Max)
                throw new ArgumentException(String.Format("{0}: Invalid min/max thresholds.  min: {1}, max: {2}", base.Code, Min, Max));
            else if (Value < Min)
                throw new ArgumentException(String.Format("{0}: val: {1} less than min: {2}", base.Code, Value, Min));
            else if (Value > Max)
                throw new ArgumentException(String.Format("Configuration val: {0} is greater than max: {1}", Value, Max));
            else if ((Value != 0) && (decimal)Value % (decimal)Resolution > (decimal)Epsilon)
                throw new ArgumentException(String.Format("Configuration val: {0} not within res: {1}", Value, Resolution));
            else
                return;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public class BaseValueBool : BaseConfig
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BaseValueBool"/> class.
        /// </summary>
        /// <param name="code">The code.</param>
        /// <param name="desc">The desc.</param>
        /// <param name="units">The units.</param>
        public BaseValueBool(string code, string desc, string units)
        {
            Code = code;
            Description = desc;
            Units = units;
        }
        
        /// <summary>
        /// Gets a value indicating whether [value].
        /// </summary>
        /// <value><c>true</c> if [value]; otherwise, <c>false</c>.</value>
        public bool Value { get; private set; }
        
        /// <summary>Sets the value.</summary>
        /// <param name="val">if set to <c>true</c> [value].</param>
        public void SetValue(bool val)
        {
            Value = val;
        }
    }
}
