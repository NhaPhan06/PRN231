using BusinessObjects.Entities;

namespace DataAccess.IRepository;

public interface IBookingReservationRepository
{
    Task<IEnumerable<BookingReservation>> GetAll();
    Task<BookingReservation> Get(int id);
    void Add(BookingReservation bookingReservation);
    void Update(BookingReservation bookingReservation);
    void Delete(int id);
}