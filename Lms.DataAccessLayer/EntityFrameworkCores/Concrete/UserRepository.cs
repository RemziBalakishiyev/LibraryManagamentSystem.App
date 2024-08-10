using Lms.DataAccessLayer.Abstract;
using Lms.DataAccessLayer.EntityFrameworkCores.Contexts;
using Lms.Entity.Accounts;

namespace Lms.DataAccessLayer.EntityFrameworkCores.Concrete;

public class UserRepository : GenericRepository<User>, IUserRepository
{
    public UserRepository(LmsContext dbContext) : base(dbContext)
    {
    }
}
