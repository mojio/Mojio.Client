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
        /// <summary>Username</summary>
        /// <value>The name of the user.</value>
        //[Required(ErrorMessage = "Required")]
        [Display (Name = "Username")]
        [RegularExpression (Constraints.UsernameRegEx, ErrorMessage = Constraints.UsernameError)]
        [StringLength (Constraints.UserNameMaxLength, MinimumLength = Constraints.UserNameMinLength, ErrorMessage = "{0} must be {2} to {1} characters")]
        public string UserName { get; set; }

        /// <summary>
        /// Email address
        /// </summary>
        [Required (ErrorMessage = "Required")]
        [DataType (DataType.EmailAddress, ErrorMessage = "Invalid Email")]
        [Display (Name = "Email")]
        [EmailAddress (ErrorMessage = "Not a valid email address")]
        public string Email { get; set; }

        /// <summary>
        /// Password
        /// </summary>
        [Required (ErrorMessage = "Required")]
        //[MembershipPassword(ErrorMessage = PasswordError)]
        [RegularExpression (Constraints.PasswordRegEx, ErrorMessage = Constraints.PasswordError)]
        [DataType (DataType.Password)]
        [StringLength (Constraints.PasswordMaxLength, MinimumLength = Constraints.PasswordMinLength, ErrorMessage = "{0} must be {2} to {1} characters")]
        [Display (Name = "Password")]
        public string Password { get; set; }
    }

    /// <summary>
    /// Change Password
    /// </summary>
    public class ChangePassword
    {
        /// <summary>
        /// Current password
        /// </summary>
        [Required (ErrorMessage = "Required")]
        [DataType (DataType.Password)]
        [Display (Name = "Current password")]
        public string OldPassword { get; set; }

        /// <summary>
        /// New password
        /// </summary>
        [Required (ErrorMessage = "Required")]
        [RegularExpression (Constraints.PasswordRegEx, ErrorMessage = Constraints.PasswordError)]
        [StringLength (Constraints.PasswordMaxLength, MinimumLength = Constraints.PasswordMinLength, ErrorMessage = "{0} must be {2} to {1} characters")]
        [DataType (DataType.Password)]
        [Display (Name = "New password")]
        [MembershipPassword (ErrorMessage = Constraints.PasswordError)]
        //[RegularExpression(MojioMembershipProvider.PasswordRegEx, ErrorMessage = MojioMembershipProvider.PasswordError)]
        public string NewPassword { get; set; }
    }

    /// <summary>
    /// Reset Password
    /// </summary>
    public class ResetPassword
    {
        /// <summary>
        /// Username OR email address
        /// </summary>
        [Required (ErrorMessage = "Required")]
        [Display (Name = "Email/Username")]
        public string UserNameOrEmail { get; set; }

        /// <summary>
        /// Password
        /// </summary>
        [Required (ErrorMessage = "Required")]
        [RegularExpression (Constraints.PasswordRegEx, ErrorMessage = Constraints.PasswordError)]
        [StringLength (Constraints.PasswordMaxLength, MinimumLength = Constraints.PasswordMinLength, ErrorMessage = "{0} must be {2} to {1} characters")]
        [DataType (DataType.Password)]
        [Display (Name = "New Password")]
        public string Password { get; set; }

        /// <summary>
        /// Reset token
        /// </summary>
        [Required (ErrorMessage = "Required")]
        [Display (Name = "Token")]
        public string ResetToken { get; set; }
    }
}
