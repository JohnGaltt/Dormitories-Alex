using Dormitories.Core.DataAccess;
using Dormitories.Core.DataAccess.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Dormitories.Core.BusinessLogic.Managers
{
    public interface IUserManager
    {
        Task<ApplicationUser> Create(ApplicationUser student);
        Task<List<AccountViewModel>> Get();
        Task<ApplicationUser> GetById(int id);
        Task<ApplicationUser> Update(ApplicationUser newStudent);
        Task Delete(int id);
    }
}
