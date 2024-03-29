

using ModelsLayer.BusinessObjects;

namespace DataAccess.IRepository;

public interface IBookingDetailRepository
{
    Task<List<BookingDetail>> GetAll();
    Task<List<BookingDetail>> GetByReservation(int id);
    Task<BookingDetail> Get(int id);
    Task<BookingDetail> Add(BookingDetail bookingDetail);
    Task<BookingDetail> Update(BookingDetail bookingDetail);
    void Delete(int id);
}