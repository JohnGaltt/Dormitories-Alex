using Dormitories.Api.ViewModels;
using Dormitories.Core.BusinessLogic.Managers;
using Dormitories.Core.DataAccess;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Dormitories.Api.Controllers
{
    [Authorize(Roles = "Staff, Student")]
    [Route("dormitories")]
    public class DormitoriesController : ControllerBase
    {
        private readonly IDormitoryManager _dormitoryManager;
        public DormitoriesController(IDormitoryManager dormitoryManager)
        {
            _dormitoryManager = dormitoryManager;
        }

        [Authorize(Roles = "Staff, Student")]
        [HttpGet]
        public async Task<IActionResult> Get() => Ok(await _dormitoryManager.Get());

        [Authorize(Roles = "Staff")]
        [Route("create")]
        [HttpPost]
        public async Task<IActionResult> Create([FromBody]DormitoryViewModel dormitory)
        {
            var dormitorynew = await _dormitoryManager.Create(dormitory);
            return Ok(dormitory);
         }

        [Authorize(Roles = "Staff")]
        [Route("{id}")]
        [HttpGet]
        public async Task<IActionResult> GetById(int id)
        {
            var dormitory = await _dormitoryManager.GetById(id);
            return Ok(dormitory);
        }

        [Authorize(Roles = "Staff")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _dormitoryManager.Delete(id);
            return Ok();
        }


        [Authorize(Roles = "Staff")]
        [HttpPut("{id}")]
        public async Task<IActionResult> Edit([FromQuery]int id, [FromBody]DormitoryViewModel dormitory)
        {
            await _dormitoryManager.Update(dormitory);
            return Ok();
        }
    }
}