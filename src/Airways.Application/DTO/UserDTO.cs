using Airways.Core.Common;

namespace Airways.Application.DTO
{
    public class UserDTO : BaseEntity
    { 

        public required string Name { get; set; }

        public required string Email { get; set; }

        public required string Address { get; set; }

    }
}
