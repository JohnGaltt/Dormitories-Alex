using Dormitories.Core.DataAccess;
using Dormitories.Core.DataAccess.ViewModels;
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

        public async Task<List<AccountViewModel>> Get()
        {

            var userList = await (from user in _dbContext.Users.Include(x=>x.Dormitory).Include(x=>x.Room).Include(x=>x.UserRoles).ThenInclude(x=>x.Role)
                                  select new
                                  {
                                      UserId = user.Id,
                                      Username = user.UserName,
                                      user.Email,
                                      user.EmailConfirmed,
                                      RoomName = user.Room.Name,
                                      user.Room.Floor,
                                      Roles = user.UserRoles.Select(x=>x.Role.Name),
                                      DormitoryName = user.Dormitory.Name,
                                      user.Dormitory.Address,
                                      user.DormitoryId,
                                      user.RoomId,
                                  }).ToListAsync();

            var userListVm = userList.Select(p => new AccountViewModel
            {
                UserId = p.UserId,
                UserName = p.Username,
                Email = p.Email,
                EmailConfirmed = p.EmailConfirmed.ToString(),
                DormitoryAddress = p.Address,
                DormitoryName = p.DormitoryName,
                RoomFloor = p.Floor,
                RoomName = p.RoomName,
                DormitoryId = p.DormitoryId,
                RoomId = p.RoomId,
                Roles = string.Join(',',p.Roles)
            }).ToList();

            return userListVm;
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
