

using ModelsLayer.BusinessObjects;

namespace DataAccess.IRepository;

public interface IBookingReservationRepository
{
    Task<List<BookingReservation>> GetAll();
    Task<List<BookingReservation>> GetListByCustomerID(int id);
    Task<int> Count();
    Task<BookingReservation> Get(int id);
    Task<BookingReservation> Add(BookingReservation bookingReservation);
    Task<BookingReservation> Update(BookingReservation bookingReservation);
    void Delete(int id);
}