using Microsoft.AspNetCore.Mvc;

namespace Lms.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BookController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
