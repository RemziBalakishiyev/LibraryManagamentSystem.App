using Lms.BusinessLogic.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lms.BusinessLogic.Dtosl;

public class UpdateBookDto
{
    public UpdateBookDto()
    {
        UploadedFileDtos = new HashSet<UploadedFileDto>();
    }
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public double Price { get; set; }
    public int CategoryId { get; set; }
    public int? AuthorId { get; set; }
    public AddAuthorDto Author { get; set; }
    public ICollection<UploadedFileDto> UploadedFileDtos { get; set; }
}
