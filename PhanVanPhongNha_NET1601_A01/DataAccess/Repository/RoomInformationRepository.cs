

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
        return await _context.RoomInformations.Include(ri => ri.RoomType).ToListAsync();
    }

    public async Task<RoomInformation> Get(int id)
    {
        return await _context.RoomInformations.Include(ri => ri.RoomType).FirstOrDefaultAsync(ri => ri.RoomId == id);
    }

    public async Task<List<RoomInformation>> GetRoomToBooking(int id, DateTime start, DateTime end)
    {
        return _context.RoomInformations.Include(ri => ri.RoomType).Where(r => r.RoomStatus == 1 && r.RoomTypeId == id && !r.BookingDetails.Any(b => (b.StartDate <= end && b.EndDate >= start)))
            .ToList();
    }
    
    
    public async Task<RoomInformation> Add(RoomInformation roomInformation)
    {
        _context.RoomInformations.Add(roomInformation);
        _context.SaveChanges();
        return await _context.RoomInformations.Include(ri => ri.RoomType).OrderBy(src => src.RoomTypeId).LastAsync();;
    }

    public async Task<RoomInformation> Update(RoomInformation roomInformation)
    { 
        _context.RoomInformations.Update(roomInformation);
        _context.SaveChanges();
        return await _context.RoomInformations.Include(ri => ri.RoomType).OrderBy(src => src.RoomTypeId).LastAsync();

    }

    public async Task<int> Count()
    {
        return await _context.RoomInformations.CountAsync();
    }

    public void Delete(int id)
    {
        var roomInformation = _context.RoomInformations.Find(id);
        if (roomInformation.RoomStatus == 0)
        {
            roomInformation.RoomStatus = 1;
        }
        else
        {
            roomInformation.RoomStatus = 0;
        }
        _context.RoomInformations.Update(roomInformation);
        _context.SaveChanges();
    }
}