using Dormitories.Core.BusinessLogic;
using Dormitories.Core.DataAccess.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Dormitories.Api.Controllers
{
    [Authorize(Roles = "Staff, Student")]
    [Route("requests")]
    public class RequestsController : ControllerBase
    {
        private readonly IRequestManager _requestManager;

        public RequestsController(IRequestManager requestManager)
        {
            _requestManager = requestManager;
        }

        [Authorize(Roles = "Staff")]
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var requests = await _requestManager.Get();
            return Ok(requests);
        }

        [Authorize(Roles = "Staff, Student")]
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Request request) 
        {
            var requests = await _requestManager.Create(request);
            return Ok(requests);
        }
    }
}
