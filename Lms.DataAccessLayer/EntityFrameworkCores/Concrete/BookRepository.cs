using Lms.DataAccessLayer.Abstract;
using Lms.DataAccessLayer.EntityFrameworkCores.Contexts;
using Lms.Entity.Books;
using Microsoft.EntityFrameworkCore;

namespace Lms.DataAccessLayer.EntityFrameworkCores.Concrete;

public class BookRepository : GenericRepository<Book>, IBookRepository
{
    public BookRepository(LmsContext dbContext) : base(dbContext)
    {
    }

    public async Task<IEnumerable<Book>> GetBooksWithDetails()
    {
        return await TableEntity
              .Include(x => x.BookAuthors)
              .ThenInclude(x => x.Author)
              .Include(x => x.Category)
              .Include(x => x.UploadedFiles)
              .OrderByDescending(x => x.Id)
              .ToListAsync();
    }

    public async Task<Book> GetBookWithDetailWithIdAsync(int id)
    {
        return await TableEntity
              .Include(x => x.BookAuthors)
              .ThenInclude(x => x.Author)
              .Include(x => x.Category)
              .Include(x => x.UploadedFiles)
              .FirstOrDefaultAsync(x => x.Id == id);
    }
}
