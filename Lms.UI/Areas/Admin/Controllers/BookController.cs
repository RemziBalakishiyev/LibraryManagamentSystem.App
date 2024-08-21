using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Lms.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles ="Worker")]
    public class BookController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
