using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Security;

namespace Mojio
{
    public class Register
    {
        public const string UsernameRegEx = "^[a-zA-Z0-9_]*$";
        public const string UsernameError = "numbers, upper, lower case and underscore allowed";
        public const int UserNameMinLength = 4;
        public const int UserNameMaxLength = 16;
        public const string PasswordRegEx = @"(?=^[^\s]{8,32}$)((?=.*?\d)(?=.*?[A-Z])(?=.*?[a-z]))^.*";
        public const int PasswordMinLength = 8;
        public const int PasswordMaxLength = 32;
        public const string PasswordError = "Must contain uppercase, lowercase and numbers";

        /// <summary>
        /// username
        /// </summary>
        //[Required(ErrorMessage = "Required")]
        [Display(Name = "User name")]
        [RegularExpression(UsernameRegEx, ErrorMessage = UsernameError)]
        [StringLength(UserNameMaxLength, MinimumLength = UserNameMinLength, ErrorMessage = "Must be {1} to {0} characters")]
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
        [StringLength(PasswordMaxLength, MinimumLength = PasswordMinLength, ErrorMessage = "Must be {1} to {0} characters")]
        [Display(Name = "Password")]
        public string Password { get; set; }
    }

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
