using Dormitories.Api.ViewModels;
using Dormitories.Core.DataAccess;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Dormitories.Core.BusinessLogic.Managers
{
    public interface IDormitoryManager
    {
        Task<DormitoryViewModel> Create(DormitoryViewModel dormitory);
        Task<List<DormitoryViewModel>> Get();
        Task<DormitoryViewModel> GetById(int id);
        Task<DormitoryViewModel> Update(DormitoryViewModel newDormitory);
        Task Delete(int id);
    }
}
