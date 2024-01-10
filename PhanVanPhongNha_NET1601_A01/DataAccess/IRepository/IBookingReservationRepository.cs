using BusinessObjects.Entities;

namespace DataAccess.IRepository;

public interface IBookingReservationRepository
{
    Task<List<BookingReservation>> GetAll();
    Task<List<BookingReservation>> GetListByCustomerID(int id);
    Task<int> Count();
    Task<BookingReservation> Get(int id);
    void Add(BookingReservation bookingReservation);
    void Update(BookingReservation bookingReservation);
    void Delete(int id);
}