using Dormitories.Core.DataAccess;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Dormitories.Core.BusinessLogic.Managers
{
    public interface IDormitoryManager
    {
        Task<Dormitory> Create(Dormitory dormitory);
        Task<List<Dormitory>> Get();
        Task<Dormitory> GetById(int id);
        Task<Dormitory> Update(Dormitory newDormitory);
        Task Delete(int id);
    }
}
