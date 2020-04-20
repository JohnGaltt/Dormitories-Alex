using AutoMapper;
using Dormitories.Api.ViewModels;
using Dormitories.Core.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Dormitories.Core.BusinessLogic.Managers
{
    public class DormitoryManager : IDormitoryManager
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public DormitoryManager(ApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<DormitoryViewModel> Create(DormitoryViewModel newDormitoryDto)
        {
            var oldDormitory = await GetByName(newDormitoryDto.Name);
            if (oldDormitory != null)
            {
                //Conflict
                throw new InvalidOperationException("Conflict");
            }
            var newDormitory = _mapper.Map<Dormitory>(newDormitoryDto);
            await _dbContext.AddAsync(newDormitory);
            await _dbContext.SaveChangesAsync();

            newDormitoryDto.Id = newDormitory.Id;

            return newDormitoryDto;
        }

        public async Task Delete(int id)
        {
            var dormitory = await _dbContext.Dormitories.FirstOrDefaultAsync(x => x.Id == id)
                ?? throw new InvalidOperationException("Not Found");
            _dbContext.Dormitories.Remove(dormitory);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<DormitoryViewModel>> Get()
        {
            return _mapper.Map<List<DormitoryViewModel>>(await _dbContext.Dormitories.ToListAsync());
        }

        public async Task<DormitoryViewModel> GetById(int id)
        {
            var entity = await _dbContext.Dormitories.FirstOrDefaultAsync(x => x.Id == id);
            var model = _mapper.Map<DormitoryViewModel>(entity);
            return model;
        }

        public async Task<DormitoryViewModel> GetByName(string name)
        {
            var dormitory = await _dbContext.Dormitories.FirstOrDefaultAsync(x => x.Name == name);
            var viewModel = _mapper.Map<DormitoryViewModel>(dormitory);
            return viewModel;
        }

        public async Task<DormitoryViewModel> Update(DormitoryViewModel updatedDormitory)
        {
            var existingDormitory = await _dbContext.Dormitories.FirstOrDefaultAsync(x => x.Id == updatedDormitory.Id) ?? throw new NotImplementedException();
            _mapper.Map(updatedDormitory, existingDormitory);
            await _dbContext.SaveChangesAsync();
            return updatedDormitory;
        }
    }
}
