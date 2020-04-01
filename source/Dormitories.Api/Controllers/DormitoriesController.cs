using Dormitories.Core.BusinessLogic.Managers;
using Dormitories.Core.DataAccess;
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
        public async Task<IActionResult> Create(Dormitory dormitory)
        {
            var dormitorynew = await _dormitoryManager.Create(dormitory);
            return Ok(dormitory);
         }
    }
}