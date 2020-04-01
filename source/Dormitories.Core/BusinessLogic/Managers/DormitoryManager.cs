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

        public DormitoryManager(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Dormitory> Create(Dormitory newDormitory)
        {
            var oldDormitory = await GetByName(newDormitory.Name);
            if(oldDormitory != null)
            {
                //Conflict
                throw new NotImplementedException();
            }
            await _dbContext.AddAsync(newDormitory);
            await _dbContext.SaveChangesAsync();

            return newDormitory;
        }

        public Task Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        public async Task<List<Dormitory>> Get()
        {
            return await _dbContext.Dormitories.ToListAsync();
        }

        public async Task<Dormitory> GetById(int id)
        {
            return await _dbContext.Dormitories.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Dormitory> GetByName(string name)
        {
            return await _dbContext.Dormitories.FirstOrDefaultAsync(x => x.Name == name);
        }

        public Task<Dormitory> Update(Dormitory newStudent)
        {
            throw new System.NotImplementedException();
        }
    }
}
