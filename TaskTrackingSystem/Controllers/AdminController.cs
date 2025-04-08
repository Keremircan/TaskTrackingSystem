using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TaskTrackingSystem.Data;
using TaskTrackingSystem.Models;

namespace TaskTrackingSystem.Controllers
{
    
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly TaskContext _context;
        public AdminController(TaskContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Assign()
        {
            var adminid = HttpContext.Session.GetInt32("adminid");
            var model = new WorkStaffViewModel
            {
                Work = new Work(), 
                Staffs = _context.Staffs.Where(s => s.AdminID == adminid).ToList()
            };

            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Assign([Bind("WorkID", "Title", "Description", "StaffID")] Work work)
        {
            if(ModelState.IsValid)
            {
                _context.Works.Add(work);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Track));
            }

            return View();
        }
        public IActionResult Track()
        {
            var adminid = HttpContext.Session.GetInt32("adminid");
            var staffs = _context.Staffs.Where(s => s.AdminID == adminid).ToList();

            return View(staffs);
        }
        [HttpPost]
        public IActionResult Track(int? staffid)
        {
            if(staffid == null)
            {
                ModelState.AddModelError("staffid", "Lütfen bir çalışan seçiniz.");

                var adminid = HttpContext.Session.GetInt32("adminid");
                var staffs = _context.Staffs.Where(s => s.AdminID == adminid).ToList();

                return View(staffs);
               
            }
            var staff = _context.Staffs.FirstOrDefault(s => s.ID == staffid);
            if (staff == null)
            {
                return NotFound();
            }
            HttpContext.Session.SetInt32("selectStaffid", staff.ID);
            return RedirectToAction(nameof(List));
        }
        public IActionResult List()
        {
            var staffid = HttpContext.Session.GetInt32("selectStaffid");

            var works = _context.Works.Where(w=>w.StaffID == staffid).ToList();

            return View(works);
            
        }
        public IActionResult Delete(int id)
        {
            var curwork = _context.Works.Find(id);
            if (curwork == null)
            {
                return NotFound(); 
            }

            _context.Works.Remove(curwork);
            _context.SaveChanges();

            return RedirectToAction(nameof(List));

        }
    }
}
