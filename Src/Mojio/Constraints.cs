using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mojio
{
    public static class Constraints
    {
        /// <summary>The username reg ex</summary>
        public const string UsernameRegEx = @"^[a-zA-Z0-9_\-]*$";
        
        /// <summary>
        /// The user name minimum length
        /// </summary>
        public const int UserNameMinLength = 6;
        
        /// <summary>
        /// The user name maximum length
        /// </summary>
        public const int UserNameMaxLength = 32;

        /// <summary>The username error</summary>
        public const string UsernameError = "Username may only contain letters, numbers, and dashes.";
        
        /// <summary>The password reg ex</summary>
        public const string PasswordRegEx = @"(?=^[^\s]{0,1000}$)((?=.*?[A-Z])(?=.*?[a-z]))^.*";
        
        /// <summary>
        /// The password minimum length
        /// </summary>
        public const int PasswordMinLength = 7;
        
        /// <summary>
        /// The password maximum length
        /// </summary>
        public const int PasswordMaxLength = 32;
        
        /// <summary>The password error</summary>
        public const string PasswordError = "Password must be upper and lower case and include a number";
    }
}
