using Lms.Entity.Commons;

namespace Lms.Entity.Books
{
    public class Author:EditedBaseEntity
    {
        public Author()
        {
            BookAuthors = new HashSet<BookAuthor>();
        }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public ICollection<BookAuthor> BookAuthors { get; set; }
    }
}
