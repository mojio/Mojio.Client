using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace Mojio
{
    public enum DeviceType : int
    {
        Xirgo = 1,
    }

    public class DeviceConfiguration : StringEntity
    {
        public DeviceType DeviceType { get; set; }
        public string ProfileName
        {
            get { return Id; }
            set { Id = value; }
        }
        public DateTime DateModified { get; set; }
        public string FirmwareVersion { get; set; }
        public string ServerVersion { get; set; }

        public Dictionary<string, BaseConfig> Configurations = new Dictionary<string, BaseConfig>();
    }

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

    public class BaseValueInt : BaseConfig
    {
        public BaseValueInt(string code, string desc, string units)
        {
            Code = code;
            Description = desc;
            Units = units;
        }

        public int Min { get; private set; }
        public int Max { get; private set; }
        public int Value { get; private set; }
        public int Resolution { get; private set; }
        public bool IgnoreZeroValue { get; set; }
        public void SetConfig(int min, int max, int val, int res, bool ignoreZero = false)
        {
            Min = min;
            Max = max;
            Value = val;
            Resolution = res;
            IgnoreZeroValue = ignoreZero;
            Parse();
        }

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

    public class BaseValueFloat : BaseConfig
    {
        public BaseValueFloat(string code, string desc, string units)
        {
            Code = code;
            Description = desc;
            Units = units;
            Epsilon = 0.001f;
        }

        public float Min { get; private set; }
        public float Max { get; private set; }
        public float Value { get; private set; }
        public float Resolution { get; private set; }
        public float Epsilon { get; set; }
        public bool IgnoreZeroValue { get; set; }

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

    public class BaseValueBool : BaseConfig
    {
        public BaseValueBool(string code, string desc, string units)
        {
            Code = code;
            Description = desc;
            Units = units;
        }
        public bool Value { get; private set; }
        public void SetValue(bool val)
        {
            Value = val;
        }
    }
}
