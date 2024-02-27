

using DataAccess.IRepository;
using Microsoft.EntityFrameworkCore;
using ModelsLayer.BusinessObjects;

namespace DataAccess.Repository;

public class BookingReservationRepository : IBookingReservationRepository
{
    private readonly FUMiniHotelManagementContext _context;

    public BookingReservationRepository()
    {
        _context = new FUMiniHotelManagementContext();
    }

    public async Task<List<BookingReservation>> GetAll()
    {
        return await _context.BookingReservations.Include(br => br.BookingDetails).Include(br => br.Customer).ToListAsync();
    }

    public async Task<List<BookingReservation>> GetListByCustomerID(int id)
    {
        return await _context.BookingReservations.Include(detail => detail.BookingDetails).ThenInclude(room => room.Room)
            .Where(r => r.CustomerId == id).OrderByDescending(src => src.BookingDate).ToListAsync();
    }

    public async Task<int> Count()
    {
        return  await _context.BookingReservations.CountAsync();
    }

    public async Task<BookingReservation> Get(int id)
    {
        return await _context.BookingReservations.Include(br => br.BookingDetails).ThenInclude(room => room.Room).FirstOrDefaultAsync(br => br.BookingReservationId == id);
    }

    public async Task<BookingReservation> Add(BookingReservation bookingReservation)
    {
        _context.BookingReservations.Add(bookingReservation);
        _context.SaveChanges();
        return await _context.BookingReservations.Include(br => br.BookingDetails).FirstOrDefaultAsync(br => br.BookingReservationId == bookingReservation.BookingReservationId); ;
    }

    public async Task<BookingReservation> Update(BookingReservation bookingReservation)
    {
        var booking = await _context.BookingReservations.FindAsync(bookingReservation.BookingReservationId);
        booking = bookingReservation;
        _context.BookingReservations.Update(booking);
        _context.SaveChanges();
        return await _context.BookingReservations.Include(br => br.BookingDetails).FirstOrDefaultAsync(br => br.BookingReservationId == bookingReservation.BookingReservationId); ;
    }

    public async void Delete(int id)
    {
        var bookingReservation = _context.BookingReservations.Find(id);
        if (bookingReservation.BookingStatus == 0)
        {
            bookingReservation.BookingStatus = 1;
        }
        else
        {
            bookingReservation.BookingStatus = 0;
        }
        _context.BookingReservations.Update(bookingReservation);
        _context.SaveChanges();
    }
}