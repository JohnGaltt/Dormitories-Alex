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

        public RoomManager(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Room> Create(Room room)
        {
            var oldRoom = await _dbContext.Rooms.FirstOrDefaultAsync(x => x.Id == room.Id);
            if (oldRoom != null)
            {
                //conflict
                throw new NotImplementedException();
            }
            if (!await _dbContext.Dormitories.AnyAsync(x => x.Id == room.DormitoryId))
            {
                throw new NotImplementedException();
            }
            await _dbContext.Rooms.AddAsync(room);
            await _dbContext.SaveChangesAsync();

            return room;
        }

        public async Task Delete(int id)
        {
            var room = await _dbContext.Rooms.FirstOrDefaultAsync(x => x.Id == id)
                ?? throw new InvalidOperationException("Not Found");
            _dbContext.Rooms.Remove(room);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<Room>> Get()
        {
            try
            {
                var rooms = await _dbContext.Rooms.Include(x => x.Dormitory).ToListAsync();
                return rooms;
            }
            catch (Exception e)
            {

            }
            return null;
        }

        public async Task<List<Room>> GetByDormitoryId(int dormitoryId)
        {
            var rooms = await _dbContext.Rooms.Include(x => x.Dormitory).Where(x => x.DormitoryId == dormitoryId).ToListAsync();
            return rooms;
        }

        public async Task<Room> GetById(int id)
        {
            return await _dbContext.Rooms.Include(x => x.Dormitory).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Room> Update(Room newRoom)
        {
            var oldRoom = await _dbContext.Rooms.FirstOrDefaultAsync(x => x.Id == newRoom.Id) ?? throw new NotImplementedException();
            oldRoom.Name = newRoom.Name;
            oldRoom.Floor = newRoom.Floor;
            oldRoom.DormitoryId = newRoom.DormitoryId;
            await _dbContext.SaveChangesAsync();
            return newRoom;
        }
    }
}
