using AutoMapper;
using Dormitories.Core.BusinessLogic.ViewModels;
using Dormitories.Core.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dormitories.Core.BusinessLogic.Managers
{
    public class RoomManager : IRoomManager
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public RoomManager(ApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<RoomViewModel> Create(RoomViewModel roomDto)
        {
            var oldRoom = await _dbContext.Rooms.FirstOrDefaultAsync(x => x.Id == roomDto.Id);
            if (oldRoom != null)
            {
                //conflict
                throw new NotImplementedException();
            }
            if (!await _dbContext.Dormitories.AnyAsync(x => x.Id == roomDto.DormitoryId))
            {
                //no dormitory assigned
                throw new NotImplementedException();
            }
            var room = _mapper.Map<Room>(roomDto);
            await _dbContext.Rooms.AddAsync(room);
            await _dbContext.SaveChangesAsync();

            return roomDto;
        }

        public async Task Delete(int id)
        {
            var room = await _dbContext.Rooms.FirstOrDefaultAsync(x => x.Id == id)
                ?? throw new InvalidOperationException("Not Found");
            _dbContext.Rooms.Remove(room);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<RoomViewModel>> Get()
        {
            var rooms = await _dbContext.Rooms.Include(x => x.Dormitory).ToListAsync();
            var roomsDto = _mapper.Map<List<RoomViewModel>>(rooms);
            return roomsDto;
        }

        public async Task<List<RoomViewModel>> GetByDormitoryId(int dormitoryId)
        {
            var rooms = await _dbContext.Rooms.Include(x => x.Dormitory).Where(x => x.DormitoryId == dormitoryId).ToListAsync();
            var roomsDto = _mapper.Map<List<RoomViewModel>>(rooms);
            return roomsDto;
        }

        public async Task<RoomViewModel> GetById(int id)
        {
            var room = await _dbContext.Rooms.Include(x => x.Dormitory).FirstOrDefaultAsync(x => x.Id == id);
            var roomDto = _mapper.Map<RoomViewModel>(room);
            return roomDto;
        }

        public async Task<RoomViewModel> Update(RoomViewModel newRoom)
        {
            var oldRoom = await _dbContext.Rooms.FirstOrDefaultAsync(x => x.Id == newRoom.Id) ?? throw new NotImplementedException();
            _mapper.Map(oldRoom, newRoom);
            await _dbContext.SaveChangesAsync();
            return newRoom;
        }
    }
}
