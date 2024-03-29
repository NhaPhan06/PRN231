
using DataAccess.IRepository;
using Microsoft.EntityFrameworkCore;
using ModelsLayer.BusinessObjects;

namespace DataAccess.Repository;

public class BookingDetailRepository : IBookingDetailRepository
{
    private readonly FUMiniHotelManagementContext _context;

    public BookingDetailRepository()
    {
        _context = new FUMiniHotelManagementContext();
    }

    public async Task<List<BookingDetail>> GetAll()
    {
        return await _context.BookingDetails.ToListAsync();
    }

    public async Task<List<BookingDetail>> GetByReservation(int id)
    {
        return await _context.BookingDetails.Where(detail => detail.BookingReservationId == id).ToListAsync();
    }

    public async Task<BookingDetail> Get(int id)
    {
        return await _context.BookingDetails.FindAsync(id);
    }

    public async Task<BookingDetail> Add(BookingDetail bookingDetail)
    {
        _context.BookingDetails.Add(bookingDetail);
        _context.SaveChanges();
        return bookingDetail;
    }

    public async Task<BookingDetail> Update(BookingDetail bookingDetail)
    {
        _context.SaveChanges();
        return bookingDetail;
    }

    public void Delete(int id)
    {
        var bookingDetail = _context.BookingDetails.Find(id);
        _context.BookingDetails.Remove(bookingDetail);
        _context.SaveChanges();
    }
}