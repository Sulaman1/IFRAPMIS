using DAL.Models;
using IFRAPMIS.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace IFRAPMIS.Controllers
{
    [Authorize]
    public class UsersController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ApplicationDbContext _context;
        public UsersController(UserManager<ApplicationUser> userManager, ApplicationDbContext context)
        {
            _userManager = userManager;
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            //var currentUser = await _userManager.GetUserAsync(HttpContext.User);
            //var allUsersExceptCurrentUser = await _userManager.Users
            //    .Where(a => a.Id != currentUser.Id)
            //    .Select(user => new
            //    {
            //        id = user.Id,
            //        full_name = user.FirstName + " " + user.LastName,
            //        role = "user.Role", // Replace with actual role fetching logic
            //        username = user.UserName,
            //        email = user.Email,
            //        district = "user.CurrentPlan", // Replace with actual plan
            //        billing = "biling",
            //        status = 2, // Replace with actual status logic
            //        avatar = user.ProfilePicture
            //    }).ToListAsync();

            // Fetch current user
            var currentUser = await _userManager.GetUserAsync(HttpContext.User);

            // Fetch all users with their roles using a LEFT JOIN and group roles per user
            var allUsersWithRoles = await (
                from user in _userManager.Users
                where user.Id != currentUser.Id
                join userRole in _context.UserRoles on user.Id equals userRole.UserId into userRolesGroup
                from userRole in userRolesGroup.DefaultIfEmpty() // Perform LEFT JOIN on UserRoles
                join role in _context.Roles on userRole.RoleId equals role.Id into rolesGroup
                from role in rolesGroup.DefaultIfEmpty() // Perform LEFT JOIN on Roles
                group role by new
                {
                    user.Id,
                    FullName = user.FirstName + " " + user.LastName,
                    user.UserName,
                    user.Email,
                    user.DistrictName,
                    user.ProfilePicture
                } into userGroup
                select new
                {
                    id = userGroup.Key.Id,
                    full_name = userGroup.Key.FullName,
                    role = !userGroup.Any(r => r != null) ? "NoRole" : string.Join(", ", userGroup.Where(r => r != null).Select(r => r.Name)), // Handle no roles case
                    username = userGroup.Key.UserName,
                    email = userGroup.Key.Email,
                    district = userGroup.Key.DistrictName, // Replace with actual plan property
                    //billing = "billing", // Replace with actual billing logic
                    status = 2, // Replace with actual status logic
                    avatar = userGroup.Key.ProfilePicture
                }
            ).ToListAsync();

            //return allUsersWithRoles;



            // Check if the request is AJAX
            if (Request.Headers["X-Requested-With"] == "XMLHttpRequest")
            {
                return Json(new { data = allUsersWithRoles });
            }

            // Otherwise, return the view
            return View();            

        }
        public IActionResult List() => View();
        public IActionResult ViewAccount() => View();
        public IActionResult ViewBilling() => View();
        public IActionResult ViewConnections() => View();
        public IActionResult ViewNotifications() => View();
        public IActionResult ViewSecurity() => View();
    }
}
