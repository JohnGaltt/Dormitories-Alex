using Dormitories.Core.BusinessLogic.Managers;
using Dormitories.Core.DataAccess;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Dormitories.Api.Controllers
{
    [Route("users")]
    public class UsersController : ControllerBase
    {
        private readonly IUserManager _userManager;
        public UsersController(IUserManager studentManager)
        {
            _userManager = studentManager;
        }

        [HttpGet]
        public async Task<IActionResult> Get() => Ok(await _userManager.Get());

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody]ApplicationUser student) => Ok(await _userManager.Create(student));

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id) => Ok(await _userManager.GetById(id));

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _userManager.Delete(id);
            return Ok();
        }
    }
}
