using BusinessObjects.Entities;

namespace BussinessLogic.IService;

public interface IBookingDetailService
{
    public Task<List<BookingDetail>> GetBookingDetails();
    public Task<BookingDetail> GetBookingDetail(int id);
    public Task UpdateBookingDetail(int id, BookingDetail bookingDetail);
    public Task<BookingDetail> CreateBookingDetail(BookingDetail bookingDetail);
}