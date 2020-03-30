using Dormitories.Core.DataAccess;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Dormitories.Core.BusinessLogic.Managers
{
    public class RoomManager : IRoomManager
    {
        private readonly ApplicationDbContext _dbContext;

        public RoomManager(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task<Room> Create(Room student)
        {
            throw new System.NotImplementedException();
        }

        public Task Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<List<Room>> Get()
        {
            throw new System.NotImplementedException();
        }

        public Task<Room> GetById(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<Room> Update(Room newStudent)
        {
            throw new System.NotImplementedException();
        }
    }
}
