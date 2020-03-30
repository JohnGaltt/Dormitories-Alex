using Dormitories.Core.DataAccess;
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

        public Task<Dormitory> Create(Dormitory student)
        {
            throw new System.NotImplementedException();
        }

        public Task Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<List<Dormitory>> Get()
        {
            throw new System.NotImplementedException();
        }

        public Task<Dormitory> GetById(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<Dormitory> Update(Dormitory newStudent)
        {
            throw new System.NotImplementedException();
        }
    }
}
