using Dormitories.Core.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dormitories.Core.BusinessLogic.Managers
{
    public class UserManager : IUserManager
    {
        private readonly ApplicationDbContext _dbContext;
        public UserManager(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<ApplicationUser> Create(ApplicationUser user)
        {
            if (await _dbContext.Users.AnyAsync(x => x.Id == user.Id))
            {
                throw new NotImplementedException();
            }
            await _dbContext.AddAsync(user);
            await _dbContext.SaveChangesAsync();
            return user;
        }

        public async Task<List<ApplicationUser>> Get()
        {
            var users = await _dbContext.Users.Include(x => x.Dormitory).Include(x => x.Room).ToListAsync();
            return users;
        }
        public async Task<ApplicationUser> GetById(int id)
        {
            var user = await _dbContext.Users.FirstOrDefaultAsync(x => x.Id == id) ?? throw new NotImplementedException();
            return user;
        }
        public async Task<ApplicationUser> Update(ApplicationUser newuser)
        {
            var olduser = await _dbContext.Users.FirstOrDefaultAsync(x => x.Id == newuser.Id) ?? throw new NotImplementedException();
            olduser.Name = newuser.Name;
            olduser.Email = newuser.Email;
            await _dbContext.SaveChangesAsync();
            return newuser;
        }
        public async Task Delete(int id)
        {
            var user = await _dbContext.Users.FirstOrDefaultAsync(x => x.Id == id) ?? throw new NotImplementedException();
            _dbContext.Users.Remove(user);
            await _dbContext.SaveChangesAsync();
        }
    }
}
