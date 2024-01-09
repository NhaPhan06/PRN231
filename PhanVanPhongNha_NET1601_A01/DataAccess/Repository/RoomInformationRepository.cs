using BusinessObjects.Entities;
using DataAccess.IRepository;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repository;

public class RoomInformationRepository : IRoomInformationRepository
{
    private readonly FUMiniHotelManagementContext _context;

    public RoomInformationRepository()
    {
        _context = new FUMiniHotelManagementContext();
    }

    public async Task<IEnumerable<RoomInformation>> GetAll()
    {
        return await _context.RoomInformations.Include(ri => ri.BookingDetails).ToListAsync();
    }

    public async Task<RoomInformation> Get(int id)
    {
        return await _context.RoomInformations.Include(ri => ri.BookingDetails).FirstOrDefaultAsync(ri => ri.RoomId == id);
    }

    public void Add(RoomInformation roomInformation)
    {
        _context.RoomInformations.Add(roomInformation);
        _context.SaveChanges();
    }

    public void Update(RoomInformation roomInformation)
    {
        _context.Entry(roomInformation).State = EntityState.Modified;
        _context.SaveChanges();
    }

    public void Delete(int id)
    {
        var roomInformation = _context.RoomInformations.Find(id);
        _context.RoomInformations.Remove(roomInformation);
        _context.SaveChanges();
    }
}