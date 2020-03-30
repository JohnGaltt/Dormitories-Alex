using Dormitories.Core.DataAccess;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Dormitories.Core.BusinessLogic.Managers
{
    public interface IStudentManager
    {
        Task<Student> Create(Student student);
        Task<List<Student>> Get();
        Task<Student> GetById(int id);
        Task<Student> Update(Student newStudent);
        Task Delete(int id);
    }
}
