using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mojio
{
    public class UserUpdateRequest : IUserUpdateRequest
    {
        public string UserName { get; set; }

        public string Email { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }
    }
}
