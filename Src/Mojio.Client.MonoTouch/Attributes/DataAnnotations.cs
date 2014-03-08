/**
 * MonoDroid does not currently ship with DataAnnotations.
 * 
 * This file is used to add empty container class to allow Mojio.Client to build.
 */
using System;

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
        public string ErrorMessage { get; set; }
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

    public class ValidationAttribute : Attribute
    {
        public string ErrorMessage;

        public virtual bool IsValid(object value)
        {
            return true;
        }
    }
}