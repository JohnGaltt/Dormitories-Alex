using Dormitories.Core.DataAccess;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Dormitories.Core.BusinessLogic.Managers
{
    public interface IRoomManager
    {
        Task<Room> Create(Room student);
        Task<List<Room>> Get();
        Task<Room> GetById(int id);
        Task<Room> Update(Room newStudent);
        Task Delete(int id);
    }
}
