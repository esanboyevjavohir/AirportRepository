using Airways.Core.Entity;
using Airways.DataAccess.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Airways.DataAccess.Repository.Impl
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        private readonly DataBaseContext _dataBaseContext;
        public  UserRepository(DataBaseContext dataBaseContext) : base(dataBaseContext) { }

        public async Task<User?> GetUserByEmailAsync(string email)
        {
            return await _dataBaseContext.AirwaysUser.FirstOrDefaultAsync(x => x.Email == email);
        }
    }
}
