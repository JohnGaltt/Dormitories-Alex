using Dormitories.Core.BusinessLogic.Managers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Dormitories.Api.Controllers
{
    [Route("")]
    [AllowAnonymous]
    [ApiExplorerSettings(IgnoreApi = true)]
    public class HomeController : ControllerBase
    {
        private readonly IStudentManager _studentManager;
        public HomeController(IStudentManager studentManager)
        {
            _studentManager = studentManager;
        }
        [HttpGet]
        public async Task<IActionResult> Get() => Ok(await _studentManager.Get());
    }
}
