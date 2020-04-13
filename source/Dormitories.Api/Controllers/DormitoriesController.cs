using Dormitories.Core.BusinessLogic.Managers;
using Dormitories.Core.DataAccess;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Dormitories.Api.Controllers
{
    [Route("dormitories")]
    public class DormitoriesController : ControllerBase
    {
        private readonly IDormitoryManager _dormitoryManager;
        public DormitoriesController(IDormitoryManager dormitoryManager)
        {
            _dormitoryManager = dormitoryManager;
        }

        [HttpGet]
        public async Task<IActionResult> Get() => Ok(await _dormitoryManager.Get());

        [Route("create")]
        [HttpPost]
        public async Task<IActionResult> Create([FromBody]Dormitory dormitory)
        {
            var dormitorynew = await _dormitoryManager.Create(dormitory);
            return Ok(dormitory);
         }

        [Route("{id}")]
        [HttpGet]
        public async Task<IActionResult> GetById(int id)
        {
            var dormitory = await _dormitoryManager.GetById(id);
            return Ok(dormitory);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _dormitoryManager.Delete(id);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Edit([FromQuery]int id, [FromBody]Dormitory dormitory)
        {
            await _dormitoryManager.Update(dormitory);
            return Ok();
        }
    }
}