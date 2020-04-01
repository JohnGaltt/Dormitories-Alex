using Dormitories.Core.BusinessLogic.Managers;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Dormitories.Api.Controllers
{
    [Route("rooms")]
    public class RoomsController : ControllerBase
    {
        private readonly IRoomManager _roomManager;
        public RoomsController(IRoomManager roomManager)
        {
            _roomManager = roomManager;
        }

        [HttpGet]
        public async Task<IActionResult> Get() => Ok(await _roomManager.Get());
    }
}
