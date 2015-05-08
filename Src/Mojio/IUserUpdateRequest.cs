using System;
namespace Mojio
{
    public interface IUserUpdateRequest
    {
        string Email { get; set; }
        string FirstName { get; set; }
        string LastName { get; set; }
        string UserName { get; set; }
    }
}
