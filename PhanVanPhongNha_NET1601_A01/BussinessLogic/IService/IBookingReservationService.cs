using BusinessObjects.DTOS.Request;
using BusinessObjects.DTOS.Response;
using BusinessObjects.Entities;

namespace BussinessLogic.IService;

public interface IBookingReservationService
{
    public Task<List<BookingReservation>> GetBookingReservations();
    public Task<BookingReservation> GetBookingReservation(int id);
    public Task<List<ReservationResponse>> GetBookingReservationByCustomerId(int id);
    public Task<BookingReservation> CreateBookingReservation(BookingRequest bookingRequest);
    public Task<BookingReservation> UpdateBookingReservation(int id, BookingReservation bookingReservation);
}