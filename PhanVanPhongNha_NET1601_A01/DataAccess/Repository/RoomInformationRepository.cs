

using DataAccess.IRepository;
using Microsoft.EntityFrameworkCore;
using ModelsLayer.BusinessObjects;

namespace DataAccess.Repository;

public class RoomInformationRepository : IRoomInformationRepository
{
    private readonly FUMiniHotelManagementContext _context;

    public RoomInformationRepository()
    {
        _context = new FUMiniHotelManagementContext();
    }

    public async Task<List<RoomInformation>> GetAll()
    {
        return await _context.RoomInformations.Include(ri => ri.BookingDetails).ToListAsync();
    }

    public async Task<RoomInformation> Get(int id)
    {
        return await _context.RoomInformations.Include(ri => ri.BookingDetails).FirstOrDefaultAsync(ri => ri.RoomId == id);
    }

    public async Task<List<RoomInformation>> GetRoomToBooking(int id, DateTime start, DateTime end)
    {
        return _context.RoomInformations.Where(r => r.RoomTypeId == id && !r.BookingDetails.Any(b => (b.StartDate <= end && b.EndDate >= start)))
            .ToList();
    }
    
    
    public async Task<RoomInformation> Add(RoomInformation roomInformation)
    {
        _context.RoomInformations.Add(roomInformation);
        _context.SaveChanges();
        return await _context.RoomInformations.FirstOrDefaultAsync(r => r.RoomId == roomInformation.RoomId);
    }

    public async Task<RoomInformation> Update(RoomInformation roomInformation)
    { 
        _context.RoomInformations.Update(roomInformation);
        _context.SaveChanges();
        return await _context.RoomInformations.FirstOrDefaultAsync(r => r.RoomId == roomInformation.RoomId);

    }

    public void Delete(int id)
    {
        var roomInformation = _context.RoomInformations.Find(id);
        _context.RoomInformations.Remove(roomInformation);
        _context.SaveChanges();
    }
}