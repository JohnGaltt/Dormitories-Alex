using Dormitories.Core.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dormitories.Core.BusinessLogic.Managers
{
    public class StudentManager : IStudentManager
    {
        private readonly ApplicationDbContext _dbContext;
        public StudentManager(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<List<Student>> Get()
        {
            var students = await _dbContext.Students.ToListAsync();
            return students;
        }
    }
}
