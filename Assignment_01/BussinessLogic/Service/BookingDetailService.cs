using BussinessLogic.IService;
using DataAccess.IRepository;

namespace BussinessLogic.Service;

public class BookingDetailService : IBookingDetailService
{
    private readonly IBookingDetailRepository _bookingDetailRepository;

    public BookingDetailService(IBookingDetailRepository bookingDetailRepository)
    {
        _bookingDetailRepository = bookingDetailRepository;
    }
}