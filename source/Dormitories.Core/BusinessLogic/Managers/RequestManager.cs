using AutoMapper;
using Dormitories.Core.BusinessLogic.ViewModels;
using Dormitories.Core.DataAccess;
using Dormitories.Core.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Dormitories.Core.BusinessLogic.Managers
{
    public class RequestManager : IRequestManager
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public RequestManager(ApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<Request> Create(Request request)
        {
            await _dbContext.Requests.AddAsync(request);
            await _dbContext.SaveChangesAsync();

            return request;
        }

        public async Task<List<RequestViewModel>> Get()
        {
            var requests = await _dbContext.Requests.Include(x=>x.User).ToListAsync();
            var requestsDto = _mapper.Map<List<RequestViewModel>>(requests);
            return requestsDto;
        }
    }
}
