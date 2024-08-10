using Lms.DataAccessLayer.Abstract;
using Lms.DataAccessLayer.EntityFrameworkCores.Contexts;
using Lms.Entity.Books;

namespace Lms.DataAccessLayer.EntityFrameworkCores.Concrete;

public class BookRepository : GenericRepository<Book>, IBookRepository
{
    public BookRepository(LmsContext dbContext) : base(dbContext)
    {
    }
}
