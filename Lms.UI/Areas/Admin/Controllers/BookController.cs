using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Lms.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BookController : Controller
    {
        [Authorize(Roles ="Worker")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
