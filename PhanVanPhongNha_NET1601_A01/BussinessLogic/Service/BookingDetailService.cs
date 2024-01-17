

using BussinessLogic.IService;
using DataAccess.IRepository;
using ModelsLayer.BusinessObjects;

namespace BussinessLogic.Service;

public class BookingDetailService : IBookingDetailService
{
    private readonly IBookingDetailRepository _bookingDetailRepository;

    public BookingDetailService(IBookingDetailRepository bookingDetailRepository)
    {
        _bookingDetailRepository = bookingDetailRepository;
    }


    public Task<List<BookingDetail>> GetBookingDetails()
    {
        return _bookingDetailRepository.GetAll();
    }

    public Task<List<BookingDetail>> GetBookingDetailsByReservationId(int id)
    {
        return _bookingDetailRepository.GetByReservation(id);
    }

    public Task<BookingDetail> GetBookingDetail(int id)
    {
        return _bookingDetailRepository.Get(id);
    }

    public async Task UpdateBookingDetail(int id, BookingDetail bookingDetail)
    {
         _bookingDetailRepository.Update(bookingDetail);
    }

    public Task<BookingDetail> CreateBookingDetail(BookingDetail bookingDetail)
    {
        return _bookingDetailRepository.Add(bookingDetail);
    }
}