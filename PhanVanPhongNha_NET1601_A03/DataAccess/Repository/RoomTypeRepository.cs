

using DataAccess.IRepository;
using Microsoft.EntityFrameworkCore;
using ModelsLayer.BusinessObjects;

namespace DataAccess.Repository;

public class RoomTypeRepository : IRoomTypeRepository
{
    private readonly FUMiniHotelManagementContext _context;

    public RoomTypeRepository()
    {
        _context = new FUMiniHotelManagementContext();
    }

    public async Task<List<RoomType>> GetAll()
    {
        return await _context.RoomTypes.ToListAsync();
    }

    public async Task<RoomType> Get(int id)
    {
        return await _context.RoomTypes.FirstOrDefaultAsync(rt => rt.RoomTypeId == id);
    }

    public async Task<RoomType> Add(RoomType roomType)
    {
        _context.RoomTypes.Add(roomType);
        await _context.SaveChangesAsync();
        return await _context.RoomTypes.LastAsync();
    }

    public async Task<RoomType> Update(RoomType roomType)
    {
        _context.Entry(roomType).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return await _context.RoomTypes.LastAsync();
    }

    public void Delete(int id)
    {
        var roomType = _context.RoomTypes.Find(id);
        _context.RoomTypes.Remove(roomType);
        _context.SaveChanges();
    }
}