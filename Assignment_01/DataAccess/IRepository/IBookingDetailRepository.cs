using BusinessObjects.Entities;

namespace DataAccess.IRepository;

public interface IBookingDetailRepository
{
    Task<IEnumerable<BookingDetail>> GetAll();
    Task<BookingDetail> Get(int id);
    void Add(BookingDetail bookingDetail);
    void Update(BookingDetail bookingDetail);
    void Delete(int id);
}