using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Shop.UI.ViewModels.Admin;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Shop.UI.Controllers
{
    [Route("[controller]")]
    [Authorize(Policy = "Admin")]
    public class UsersController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public UsersController(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        [HttpGet]
        public IActionResult ListUsers()
        {
            var users = _userManager.Users;
            return Ok(users);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetRoles(string id)
        {
            var roles = await _roleManager.FindByIdAsync(id); 
            return Ok(roles);
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] CreateUserViewModel vm)
        {

            var user = new IdentityUser(vm.Username);
            await _userManager.CreateAsync(user, vm.Password);

            var managerClaim = new Claim("Role", vm.Role);

            await _userManager.AddClaimAsync(user, managerClaim);

            return Ok();
        }

        [HttpPost("{id}")]
        public async Task<IActionResult> DeleteUser(string id)
        {
            var user = await _userManager.FindByIdAsync(id);

            if (user == null)
            {
                ViewBag.ErrorMessage = $"User with Id = {id} cannot be found";
                return Ok("NotFound");
            }
            else
            {
                var result = await _userManager.DeleteAsync(user);

                return View("ListUsers");
            }
        }

    }
}
