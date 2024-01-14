

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

    public async Task<IEnumerable<RoomType>> GetAll()
    {
        return await _context.RoomTypes.Include(rt => rt.RoomInformations).ToListAsync();
    }

    public async Task<RoomType> Get(int id)
    {
        return await _context.RoomTypes.Include(rt => rt.RoomInformations).FirstOrDefaultAsync(rt => rt.RoomTypeId == id);
    }

    public void Add(RoomType roomType)
    {
        _context.RoomTypes.Add(roomType);
        _context.SaveChanges();
    }

    public void Update(RoomType roomType)
    {
        _context.Entry(roomType).State = EntityState.Modified;
        _context.SaveChanges();
    }

    public void Delete(int id)
    {
        var roomType = _context.RoomTypes.Find(id);
        _context.RoomTypes.Remove(roomType);
        _context.SaveChanges();
    }
}