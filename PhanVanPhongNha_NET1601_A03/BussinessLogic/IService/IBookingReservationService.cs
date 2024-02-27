
using ModelsLayer.BusinessObjects;
using ModelsLayer.DTOS.Request;
using ModelsLayer.DTOS.Response;

namespace BussinessLogic.IService;

public interface IBookingReservationService
{
    public Task<List<ReservationResponse>> GetBookingReservations();
    public Task<ReservationResponse> GetBookingReservation(int id);
    public Task<List<ReservationResponse>> GetBookingReservationByCustomerId(int id);
    public Task<ReservationResponse> CreateBookingReservation(BookingRequest bookingRequest);
    public Task<ReservationResponse> UpdateBookingReservation(BookingReservation bookingReservation);
    public Task DeleteBookingReservation(int id);
}