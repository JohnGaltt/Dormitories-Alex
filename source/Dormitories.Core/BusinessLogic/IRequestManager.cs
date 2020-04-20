using Dormitories.Core.BusinessLogic.ViewModels;
using Dormitories.Core.DataAccess.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Dormitories.Core.BusinessLogic
{
    public interface IRequestManager
    {
        Task<Request> Create(Request request);
        Task<List<RequestViewModel>> Get();
    }
}
