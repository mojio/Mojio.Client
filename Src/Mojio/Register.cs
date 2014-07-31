using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public string UserName { get; set; }

        /// <summary>
        /// Email address
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Password
        /// </summary>
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
        public string OldPassword { get; set; }

        /// <summary>
        /// New password
        /// </summary>
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
        public string UserNameOrEmail { get; set; }

        /// <summary>
        /// Password
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// Reset token
        /// </summary>
        public string ResetToken { get; set; }
    }
}
