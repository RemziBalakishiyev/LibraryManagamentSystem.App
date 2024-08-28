using Lms.Entity.Books;

namespace Lms.BusinessLogic.Dtos;

public class CreateBookDto
{
    public CreateBookDto()
    {
        UploadFileDtos = new HashSet<UploadFileDto>();
    }
    public string Name { get; set; }
    public string Description { get; set; }
    public double Price { get; set; }
    public CreateAuthorDto Author { get; set; }
    public int? AuthorId { get; set; }
    public int CategoryId { get; set; }
    public ICollection<UploadFileDto> UploadFileDtos { get; set; }
}
