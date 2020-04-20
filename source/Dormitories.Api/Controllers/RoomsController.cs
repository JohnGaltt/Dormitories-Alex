using Dormitories.Core.BusinessLogic.Managers;
using Dormitories.Core.BusinessLogic.ViewModels;
using Dormitories.Core.DataAccess;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Dormitories.Api.Controllers
{
    [Authorize(Roles = "Staff, Student")]
    [Route("rooms")]
    public class RoomsController : ControllerBase
    {
        private readonly IRoomManager _roomManager;
        public RoomsController(IRoomManager roomManager)
        {
            _roomManager = roomManager;
        }

        [Authorize(Roles = "Staff")]
        [HttpGet]
        public async Task<IActionResult> Get() => Ok(await _roomManager.Get());

        [Authorize(Roles = "Staff")]
        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody]RoomViewModel room) => Ok(await _roomManager.Create(room));

        [Authorize(Roles = "Staff")]
        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromQuery] int id, [FromBody]RoomViewModel room) => Ok(await _roomManager.Update(room));

        [Authorize(Roles = "Staff, Student")]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id) => Ok(await _roomManager.GetById(id));

        [Authorize(Roles = "Staff, Student")]
        [HttpGet("availablerooms/{dormitoryId}")]
        public async Task<IActionResult> GetByDormitoryId(int dormitoryId) => Ok(await _roomManager.GetByDormitoryId(dormitoryId));
        
        [Authorize(Roles = "Staff")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _roomManager.Delete(id);
            return Ok();
        }
    }
}
