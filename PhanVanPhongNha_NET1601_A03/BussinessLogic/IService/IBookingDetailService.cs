using ModelsLayer.BusinessObjects;

namespace BussinessLogic.IService;

public interface IBookingDetailService
{
    public Task<List<BookingDetail>> GetBookingDetails();
    public Task<List<BookingDetail>> GetBookingDetailsByReservationId(int id);
    public Task<BookingDetail> GetBookingDetail(int id);
    public Task UpdateBookingDetail(int id, BookingDetail bookingDetail);
    public Task<BookingDetail> CreateBookingDetail(BookingDetail bookingDetail);
}