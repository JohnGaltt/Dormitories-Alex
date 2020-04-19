using Dormitories.Core.BusinessLogic.Managers;
using Dormitories.Core.BusinessLogic.ViewModels;
using Dormitories.Core.DataAccess;
using Dormitories.Core.DataAccess.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Dormitories.Api.Controllers
{
    [Authorize(Roles = "Staff")]
    [Route("users")]
    public class UsersController : ControllerBase
    {
        private readonly IUserManager _userManager;
        private readonly UserManager<ApplicationUser> _userManagerApp;
        private readonly RoleManager<ApplicationRole> _roleManager;

        public UsersController(IUserManager studentManager, UserManager<ApplicationUser> userManagerApp, RoleManager<ApplicationRole> roleManager)
        {
            _userManagerApp = userManagerApp;
            _userManager = studentManager;
            _roleManager = roleManager;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var users = await _userManager.Get();
            return Ok(users);
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody]CreateUserViewModel user)
        {
            var newUser = new ApplicationUser(user.Name, user.DormitoryId, user.Email, user.RoomId);

            var userResult = await _userManagerApp.CreateAsync(newUser, "password");
            var role = await _roleManager.FindByIdAsync(user.RoleId.ToString());
            if (role != null)
            {
                var roleResult = await _userManagerApp.AddToRoleAsync(newUser, role.Name);
            }

            return Ok(newUser);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id) => Ok(await _userManager.GetById(id));

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromQuery] int id, [FromBody]UpdateUserViewModel updatedUser) {
            var idWorkAround = int.TryParse(updatedUser.Id, out int idResult) ? idResult : throw new NotImplementedException();
            var user = await _userManager.GetEntityById(idWorkAround);
            var roles = user.UserRoles.Select(x => x.Role.Name).ToList();
            await _userManagerApp.RemoveFromRolesAsync(user, roles);

            var role = await _roleManager.FindByIdAsync(updatedUser.RoleId.ToString());
            await _userManagerApp.AddToRoleAsync(user, role.Name);
            var result = await _userManager.Update(updatedUser);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var user = await _userManager.GetEntityById(id);
            var userRoles = user.UserRoles.Select(x => x.Role.Name).ToList();
            var result = await _userManagerApp.RemoveFromRolesAsync(user, userRoles);
            if (result.Succeeded)
            {
                await _userManager.Delete(id);
            }

            return Ok();
        }
    }
}
