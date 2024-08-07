using Lms.Entity.Commons;

namespace Lms.Entity.Books;

public class Book : EditedBaseEntity
{
    public Book()
    {
        BookAuthors = new HashSet<BookAuthor>();
    }
   
    public string Name { get; set; }
    public string Description { get; set; }
    public double Price { get; set; }
    public ICollection<BookAuthor> BookAuthors { get; set; }
    public int CategoryId { get; set; }
    public Category Category { get; set; }

}
