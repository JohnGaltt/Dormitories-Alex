using Dormitories.Core.BusinessLogic.ViewModels;
using Dormitories.Core.DataAccess;
using Dormitories.Core.DataAccess.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Dormitories.Core.BusinessLogic.Managers
{
    public interface IUserManager
    {
        Task<CreateUserViewModel> Create(CreateUserViewModel student);
        Task<List<AccountViewModel>> Get();
        Task<UserViewModel> GetById(int id);
        Task<ApplicationUser> GetEntityById(int id);
        Task<UpdateUserViewModel> Update(UpdateUserViewModel newStudent);
        Task Delete(int id);
    }
}
