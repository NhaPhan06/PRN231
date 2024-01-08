using BusinessObjects.Entities;
using DataAccess.IRepository;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repository;

public class BookingReservationRepository : IBookingReservationRepository
{
    private readonly FUMiniHotelManagementContext _context;

    public BookingReservationRepository(FUMiniHotelManagementContext context)
    {
        _context = new FUMiniHotelManagementContext();
    }

    public async Task<IEnumerable<BookingReservation>> GetAll()
    {
        return await _context.BookingReservations.Include(br => br.BookingDetails).ToListAsync();
    }

    public async Task<BookingReservation> Get(int id)
    {
        return await _context.BookingReservations.Include(br => br.BookingDetails).FirstOrDefaultAsync(br => br.BookingReservationId == id);
    }

    public void Add(BookingReservation bookingReservation)
    {
        _context.BookingReservations.Add(bookingReservation);
        _context.SaveChanges();
    }

    public void Update(BookingReservation bookingReservation)
    {
        _context.Entry(bookingReservation).State = EntityState.Modified;
        _context.SaveChanges();
    }

    public void Delete(int id)
    {
        var bookingReservation = _context.BookingReservations.Find(id);
        _context.BookingReservations.Remove(bookingReservation);
        _context.SaveChanges();
    }
}