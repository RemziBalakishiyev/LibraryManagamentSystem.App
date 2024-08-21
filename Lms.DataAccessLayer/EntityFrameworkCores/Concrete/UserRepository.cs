using Lms.DataAccessLayer.Abstract;
using Lms.DataAccessLayer.EntityFrameworkCores.Contexts;
using Lms.Entity.Accounts;
using Microsoft.EntityFrameworkCore;

namespace Lms.DataAccessLayer.EntityFrameworkCores.Concrete;

public class UserRepository : GenericRepository<User>, IUserRepository
{
    public UserRepository(LmsContext dbContext) : base(dbContext)
    {
    }

    public async Task<User> GetSigninUserWithDetailAsync(string email)
    {
        return await TableEntity
            .Include(x => x.UserDetail)
            .Where(x => x.Email == email && x.UserDetail.StatusId == 5)
            .FirstOrDefaultAsync();
    }
}
