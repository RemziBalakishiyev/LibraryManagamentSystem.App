using Lms.BusinessLogic.Abstract;
using Lms.BusinessLogic.Concrete;
using Lms.BusinessLogic.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Lms.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    //[Authorize(Roles = "Worker")]
    public class BookController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly IAuthorService _authorService;
        private readonly IBookService _bookService;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public BookController(
            ICategoryService categoryService,
            IAuthorService authorService,
            IBookService bookService,
            IWebHostEnvironment webHostEnvironment)
        {
            _categoryService = categoryService;
            _authorService = authorService;
            _bookService = bookService;
            _webHostEnvironment = webHostEnvironment;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> AddBook()
        {

            TempData["Categories"] = await _categoryService.GetCategoriesDictionaryAsync();
            CreateBookDto createBookDto = new CreateBookDto();
            return View(createBookDto);
        }

        [HttpGet]
        public async Task<IActionResult> SearchAuthors(string term)
        {
            var authors = await _authorService.SearchAuthorFullName(term);

            return Json(authors.Data);
        }

        [HttpPost]
        public async Task<IActionResult> AddBook(CreateBookDto createBookDto, IList<IFormFile> imageFiles)
        {
            if (imageFiles != null && imageFiles.Count > 0)
            {
                string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "uploads");

             
                if (!Directory.Exists(uploadsFolder))
                {
                    Directory.CreateDirectory(uploadsFolder);
                }

                foreach (var imageFile in imageFiles)
                {
                    if (imageFile.Length > 0)
                    {
                        try
                        {
                            string uniqueFileName = Guid.NewGuid().ToString() + "_" + Path.GetFileName(imageFile.FileName);
                            string filePath = Path.Combine(uploadsFolder, uniqueFileName);

                            using (var fileStream = new FileStream(filePath, FileMode.Create))
                            {
                                await imageFile.CopyToAsync(fileStream);
                            }

                            createBookDto.UploadFileDtos.Add(new UploadFileDto
                            {
                                FileName = uniqueFileName,
                                RelativePath = Path.Combine("uploads", uniqueFileName),
                                ContentType = imageFile.ContentType
                            });
                        }
                        catch (Exception e)
                        {
                            // Log or handle the exception
                            // You can use logging frameworks such as Serilog or NLog for better logging
                            var ex = e;
                        }
                    }
                }
            }

            var result = await _bookService.CreateAsync(createBookDto);

            if (result.ResponseType == CoreLayer.Enums.ResponseType.ValidationError)
            {
                foreach (var item in result.ResponseValidationResults)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }

                var errors = ModelState.Where(x => x.Value.Errors.Count > 0)
                    .ToDictionary(
                        kvp => kvp.Key,
                        kvp => kvp.Value.Errors.Select(e => e.ErrorMessage).ToArray()
                    );

                return Json(new { success = false, errors });
            }

            if (result.ResponseType == CoreLayer.Enums.ResponseType.SuccessResult)
            {
                return RedirectToAction("Index", "Books");
            }

            ModelState.AddModelError(string.Empty, "An error occurred while adding the book. Please try again.");
            return View(createBookDto);
        }
    }
}
