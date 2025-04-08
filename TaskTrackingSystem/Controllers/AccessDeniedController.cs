using Microsoft.AspNetCore.Mvc;

namespace TaskTrackingSystem.Controllers
{
    public class AccessDeniedController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
