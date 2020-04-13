using Dormitories.Core.BusinessLogic.Managers;
using Dormitories.Core.DataAccess;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Dormitories.Api.Controllers
{
    [Authorize]
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

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody]Room room) => Ok(await _roomManager.Create(room));
            
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id) => Ok(await _roomManager.GetById(id));
        
        [HttpGet("availablerooms/{dormitoryId}")]
        public async Task<IActionResult> GetByDormitoryIdId(int dormitoryId) => Ok(await _roomManager.GetByDormitoryId(dormitoryId));

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _roomManager.Delete(id);
            return Ok();
        }
    }
}
