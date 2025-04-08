using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TaskTrackingSystem.Controllers
{
    
    [Authorize(Roles = "Staff")]
    public class StaffController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
