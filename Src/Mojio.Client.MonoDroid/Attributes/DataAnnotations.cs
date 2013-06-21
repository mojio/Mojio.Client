using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace System.ComponentModel.DataAnnotations
{
    class RequiredAttribute : Attribute
    {
        public string ErrorMessage;
    }

    class DisplayAttribute : Attribute
    {
        public string Name;
    }

    class RegularExpressionAttribute : Attribute
    {
        public string ErrorMessage;

        public RegularExpressionAttribute(string regex)
        {
        }
    }

    class StringLengthAttribute : Attribute
    {
        public int MinimumLength;
        public string ErrorMessage;

        public StringLengthAttribute(int len)
        {
        }
    }

    class DataTypeAttribute : Attribute
    {
        public string ErrorMessage;

        public DataTypeAttribute(DataType type)
        {
        }
    }

    enum DataType
    {
        EmailAddress,
        Password
    }

    class EmailAddressAttribute : Attribute
    {
    }

    class MembershipPasswordAttribute : Attribute
    {
        public string ErrorMessage;
    }

    class MaxLengthAttribute : Attribute
    {
        public string ErrorMessage;
        public MaxLengthAttribute(int len)
        {
        }
    }

    class CreditCardAttribute : Attribute
    {
        public string ErrorMessage;
    }
}