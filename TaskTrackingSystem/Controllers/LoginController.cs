using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaskTrackingSystem.Data;

namespace TaskTrackingSystem.Controllers
{
    public class LoginController : Controller
    {
        private readonly TaskContext _context;
        public LoginController(TaskContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(string email, string password)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            var admin = await _context.Admins.FirstOrDefaultAsync(a=>a.Email == email);
            var staff = await _context.Staffs.FirstOrDefaultAsync(s => s.Email == email);

            if (admin != null && admin.Password == password)
            {

                HttpContext.Session.SetInt32("adminid", admin.ID);
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, admin.Name),
                    new Claim(ClaimTypes.Role, "Admin")
                };

                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var principal = new ClaimsPrincipal(identity);

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

                return RedirectToAction("Index", "Admin");
            }
            else if (staff != null && staff.Password == password)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, staff.Name),
                    new Claim(ClaimTypes.Role, "Staff")
                };

                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var principal = new ClaimsPrincipal(identity);

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

                return RedirectToAction("Index", "Staff");
            }
            else
            {
                ModelState.AddModelError("", "Invalid login attempt.");
            }

            return View();
        }

        public async Task<IActionResult> Logout()
        {

            HttpContext.Session.Clear();
            await HttpContext.SignOutAsync();
            return RedirectToAction("Index", "Login");
        }
    }
}
