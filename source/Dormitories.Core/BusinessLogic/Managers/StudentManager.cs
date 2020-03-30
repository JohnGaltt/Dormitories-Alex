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
        
        public async Task<Student> Create(Student student)
        {
            if(await _dbContext.Students.AnyAsync(x => x.Id == student.Id))
            {
                throw new NotImplementedException();
            }
            await _dbContext.AddAsync(student);
            await _dbContext.SaveChangesAsync();
            return student;
        }

        public async Task<List<Student>> Get()
        {
            var students = await _dbContext.Students.Include(x=>x.Dormitory).Include(x=>x.Room).ToListAsync();
            return students;
        }
        public async Task<Student> GetById(int id)
        {
            var student = await _dbContext.Students.FirstOrDefaultAsync(x => x.Id == id) ?? throw new NotImplementedException();
            return student;
        }
        public async Task<Student> Update(Student newStudent)
        {
            var oldStudent = await _dbContext.Students.FirstOrDefaultAsync(x => x.Id == newStudent.Id) ?? throw new NotImplementedException();
            oldStudent.Name = newStudent.Name;
            oldStudent.Email = newStudent.Email;
            await _dbContext.SaveChangesAsync();
            return newStudent;
        }
        public async Task Delete(int id)
        {
            var student = await _dbContext.Students.FirstOrDefaultAsync(x => x.Id == id) ?? throw new NotImplementedException();
            _dbContext.Students.Remove(student);
        }
    }
}
