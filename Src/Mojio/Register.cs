using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Security;

namespace Mojio
{
    /// <summary>
    /// Register
    /// </summary>
    public class Register
    {
        /// <summary>The username reg ex</summary>
        public const string UsernameRegEx = @"^[a-zA-Z0-9_\-]*$";
        /// <summary>The username error</summary>
        public const string UsernameError = "Username may only contain letters, numbers, and dashes.";
        /// <summary>
        /// The user name minimum length
        /// </summary>
        public const int UserNameMinLength = 6;
        /// <summary>
        /// The user name maximum length
        /// </summary>
        public const int UserNameMaxLength = 32;
        /// <summary>The password reg ex</summary>
        public const string PasswordRegEx = @"(?=^[^\s]{0,1000}$)((?=.*?\d)(?=.*?[A-Z])(?=.*?[a-z]))^.*";
        /// <summary>
        /// The password minimum length
        /// </summary>
        public const int PasswordMinLength = 7;
        /// <summary>
        /// The password maximum length
        /// </summary>
        public const int PasswordMaxLength = 32;
        /// <summary>The password error</summary>
        public const string PasswordError = "Password must contain an uppercase, lowercase letter and a number.";

        /// <summary>username</summary>
        /// <value>The name of the user.</value>
        //[Required(ErrorMessage = "Required")]
        [Display(Name = "Username")]
        [RegularExpression(UsernameRegEx, ErrorMessage = UsernameError)]
        [StringLength(UserNameMaxLength, MinimumLength = UserNameMinLength, ErrorMessage = "{0} must be {2} to {1} characters")]
        public string UserName { get; set; }

        /// <summary>
        /// email address
        /// </summary>
        [Required(ErrorMessage = "Required")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Invalid Email")]
        [Display(Name = "Email")]
        [EmailAddress(ErrorMessage = "Not a valid email address")]
        public string Email { get; set; }

        /// <summary>
        /// password
        /// </summary>
        [Required(ErrorMessage = "Required")]
        [MembershipPassword(ErrorMessage = PasswordError)]
        //[RegularExpression(PasswordRegEx, ErrorMessage=PasswordError)]
        [DataType(DataType.Password)]
        [StringLength(PasswordMaxLength, MinimumLength = PasswordMinLength, ErrorMessage = "{0} must be {2} to {1} characters")]
        [Display(Name = "Password")]
        public string Password { get; set; }
    }

    /// <summary>
    /// Change Password
    /// </summary>
    public class ChangePassword
    {
        /// <summary>
        /// current password
        /// </summary>
        [Required(ErrorMessage = "Required")]
        [DataType(DataType.Password)]
        [Display(Name = "Current password")]
        public string OldPassword { get; set; }

        /// <summary>
        /// new password
        /// </summary>
        [Required(ErrorMessage = "Required")]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "New password")]
        [MembershipPassword(ErrorMessage = Register.PasswordError)]
        //[RegularExpression(MojioMembershipProvider.PasswordRegEx, ErrorMessage = MojioMembershipProvider.PasswordError)]
        public string NewPassword { get; set; }
    }

    /// <summary>
    /// Reset Password
    /// </summary>
    public class ResetPassword
    {
        /// <summary>
        /// username OR email address
        /// </summary>
        [Required(ErrorMessage = "Required")]
        [Display(Name = "Email/Username")]
        public string UserNameOrEmail { get; set; }

        /// <summary>
        /// password
        /// </summary>
        [Required(ErrorMessage = "Required")]
        [DataType(DataType.Password)]
        [Display(Name = "New Password")]
        public string Password { get; set; }

        /// <summary>
        /// reset token
        /// </summary>
        [Required(ErrorMessage = "Required")]
        [Display(Name = "Token")]
        public string ResetToken { get; set; }
    }
}
