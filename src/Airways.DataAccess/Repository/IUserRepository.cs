using Airways.Core.Entity;

namespace Airways.DataAccess.Repository
{
    public interface IUserRepository: IBaseRepository<User>
    {
        Task<User?> GetUserByEmailAsync(string email);
    }
}
