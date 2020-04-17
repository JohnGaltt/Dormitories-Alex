using Dormitories.Core.BusinessLogic.ViewModels;
using Dormitories.Core.DataAccess;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Dormitories.Core.BusinessLogic.Managers
{
    public interface IRoomManager
    {
        Task<RoomViewModel> Create(RoomViewModel student);
        Task<List<RoomViewModel>> Get();
        Task<RoomViewModel> GetById(int id);
        Task<List<RoomViewModel>> GetByDormitoryId(int dormitoryId);
        Task<RoomViewModel> Update(RoomViewModel newStudent);
        Task Delete(int id);
    }
}
