using DAL.Models;
using DAL.Models.Domain.UsersAndRoles;
using IFRAPMIS.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace IFRAPMIS.Controllers
{
    [Authorize(Roles = "SuperAdmin")]
    public class RolesController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ApplicationDbContext _context;

        public RolesController(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, ApplicationDbContext context)
        {
            _roleManager = roleManager;
            _userManager = userManager;
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var rolesWithUsers = new List<RoleViewModel>();
            // Fetch all roles
            var roles = _roleManager.Roles.ToList();

            foreach (var role in roles)
            {
                var usersInRole = await _userManager.GetUsersInRoleAsync(role.Name);
                var userViewModels = usersInRole.Select(u => new UserViewModel
                {
                    Name = $"{u.FirstName} {u.LastName}",
                    AvatarUrl = u.ProfilePicture != null
                                ? $"data:image/png;base64,{Convert.ToBase64String(u.ProfilePicture)}"
                                : "/img/front-pages/icons/user.png" // Use a default image if ProfilePicture is null                                                                      
                }).ToList();

                rolesWithUsers.Add(new RoleViewModel
                {
                    RoleName = role.Name,
                    UserCount = usersInRole.Count,
                    Users = userViewModels
                });
            }

            //var roless = await _roleManager.Roles.ToListAsync();

            var allRoles = await (
                    from role in _roleManager.Roles
                    select new
                    {
                        id = role.Id,
                        name = role.Name,
                    }
                ).ToListAsync();


            // Check if the request is AJAX
            if (Request.Headers["X-Requested-With"] == "XMLHttpRequest")
            {
                return Json(new { data = allRoles });
            }

            return View(rolesWithUsers);
        }
        [HttpPost]
        public async Task<IActionResult> AddRole(string roleName)
        {
            if (roleName != null)
            {
                await _roleManager.CreateAsync(new IdentityRole(roleName.Trim()));
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> DeleteRole(string roleId)
        {
            if (string.IsNullOrEmpty(roleId))
            {
                return BadRequest("Role ID cannot be null or empty.");
            }

            var role = await _roleManager.FindByIdAsync(roleId);
            if (role == null)
            {
                return NotFound("Role not found.");
            }

            var result = await _roleManager.DeleteAsync(role);
            if (result.Succeeded)
            {
                return RedirectToAction("Index");
            }

            return BadRequest("Error occurred while deleting the role.");
        }


    }
}
