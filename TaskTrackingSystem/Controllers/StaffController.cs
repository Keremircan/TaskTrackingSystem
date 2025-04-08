using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TaskTrackingSystem.Data;
using TaskTrackingSystem.Models;

namespace TaskTrackingSystem.Controllers
{
    
    [Authorize(Roles = "Staff")]
    public class StaffController : Controller
    {
        private readonly TaskContext _context;
        public StaffController(TaskContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult List()
        {
            var staffid = HttpContext.Session.GetInt32("staffid");
            var works = _context.Works.Where(w=>w.StaffID == staffid && w.IsRead == 0).ToList();
            return View(works);
        }
        public IActionResult Complete()
        {
            var staffid = HttpContext.Session.GetInt32("staffid");
            var works = _context.Works.Where(w => w.StaffID == staffid && w.IsRead == 1).ToList();
            return View(works);
        }
        [HttpPost]
        public async Task<IActionResult> Complete(int id, string comment)
        {
            var curwork = _context.Works.Find(id);
            if (curwork != null)
            {
                curwork.IsCompleted = 1;
                curwork.Comment = comment;
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Track));
            }
            var staffid = HttpContext.Session.GetInt32("staffid");
            var works = _context.Works.Where(w => w.StaffID == staffid && w.IsRead == 1).ToList();
            return View(works);
        }
        public IActionResult Track()
        {
            var staffid = HttpContext.Session.GetInt32("staffid");
            var works = _context.Works.Where(w => w.StaffID == staffid && w.IsRead == 1).ToList();
            return View(works);
        }
        public IActionResult Read(int id)
        {
            var curwork = _context.Works.Find(id);
            if (curwork == null)
            {
                return NotFound();
            }

            curwork.IsRead = 1;
            _context.SaveChanges();

            return RedirectToAction(nameof(Complete));
        }
    }
}
