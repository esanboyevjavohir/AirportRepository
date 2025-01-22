using Airways.Core.Common;
using Airways.Core.Entity;

namespace Airways.Application.DTO
{
    public class AuthorizationUserDTO : BaseEntity
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public Role Role { get; set; }
    }
}
