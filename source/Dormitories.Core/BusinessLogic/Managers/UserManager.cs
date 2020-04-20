using AutoMapper;
using Dormitories.Core.BusinessLogic.ViewModels;
using Dormitories.Core.DataAccess;
using Dormitories.Core.DataAccess.ViewModels;
using Microsoft.AspNetCore.Identity;
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
        private readonly IMapper _mapper;
        

        public UserManager(ApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<CreateUserViewModel> Create(CreateUserViewModel user)
        {
            if (await _dbContext.Users.AnyAsync(x => x.Name == user.Name))
            {
                throw new NotImplementedException();
            }
            var entity = _mapper.Map<ApplicationUser>(user);
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

        public async Task<UserViewModel> GetById(int id)
        {
            var user = await _dbContext.Users.Include(x=>x.UserRoles).ThenInclude(x=>x.Role).FirstOrDefaultAsync(x => x.Id == id) ?? throw new NotImplementedException();
            var userDto = _mapper.Map<UserViewModel>(user);

            userDto.RoleId = user.UserRoles.Select(x=>x.RoleId).FirstOrDefault();
            return userDto;
        }
        public async Task<UpdateUserViewModel> Update(UpdateUserViewModel newuser)
        {
            var olduser = await _dbContext.Users.FirstOrDefaultAsync(x => x.Name == newuser.Name) ?? throw new NotImplementedException();

            _mapper.Map(newuser, olduser);

            await _dbContext.SaveChangesAsync();
            return newuser;
        }

        public async Task Delete(int id)
        {
            var user = await _dbContext.Users.FirstOrDefaultAsync(x => x.Id == id) ?? throw new NotImplementedException();

            _dbContext.Users.Remove(user);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<ApplicationUser> GetEntityById(int id)
        {
            var user = await _dbContext.Users.Include(x => x.UserRoles).ThenInclude(x => x.Role).FirstOrDefaultAsync(x => x.Id == id) ?? throw new NotImplementedException();
            return user;
        }

        public async Task<UserViewModelWithNames> GetByIdWithNames(int id)
        {
            var user = await _dbContext.Users.Include(x=>x.Dormitory).Include(x=>x.Room).FirstOrDefaultAsync(x => x.Id == id) ?? throw new NotImplementedException();

            var userDto = new UserViewModelWithNames
            {
                Name = user.Name,
                DormitoryAddress = user.Dormitory.Address,
                DormitoryName = user.Dormitory.Name,
                Email = user.Email,
                RoomFloor = user.Room.Floor,
                RoomName = user.Room.Name,
                UserId = user.Id,
                ExpireAt = user.ExpireAt,
                RoomId = user.RoomId.HasValue ? user.RoomId.Value : 0,
                DormitoryId = user.DormitoryId,
            };

            return userDto;
        }

        public async Task<PartialUpdateUserViewModel> UpdatePayment(PartialUpdateUserViewModel partialUpdateUser)
        {
            var user = await _dbContext.Users.FirstOrDefaultAsync(x => x.Id == partialUpdateUser.Id) ?? throw new NotImplementedException();
            user.ExpireAt = DateTime.Now.AddMonths(1);
            await _dbContext.SaveChangesAsync();

            partialUpdateUser.ExpireAt = user.ExpireAt;
            return partialUpdateUser;
        }

        public async Task<List<RoommatesViewModel>> GetRoommates(int userId)
        {
            var user = await _dbContext.Users.FirstOrDefaultAsync(x => x.Id == userId);
            var roommates = await _dbContext.Users.Include(x => x.Dormitory).Include(x => x.Room).Where(x=>x.RoomId == user.RoomId).ToListAsync() ?? throw new NotImplementedException();
            var roommatesViewModel = _mapper.Map<List<RoommatesViewModel>>(roommates);


            return roommatesViewModel;
        }
    }
}
