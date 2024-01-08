using BussinessLogic.IService;
using DataAccess.IRepository;

namespace BussinessLogic.Service;

public class BookingReservationService : IBookingReservationService
{
    private readonly IBookingReservationRepository _bookingReservationRepository;

    public BookingReservationService(IBookingReservationRepository bookingReservationRepository)
    {
        _bookingReservationRepository = bookingReservationRepository;
    }
}