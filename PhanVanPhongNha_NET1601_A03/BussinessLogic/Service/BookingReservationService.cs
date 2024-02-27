

using AutoMapper;
using BussinessLogic.IService;
using DataAccess.IRepository;
using ModelsLayer.BusinessObjects;
using ModelsLayer.DTOS.Request;
using ModelsLayer.DTOS.Response;

namespace BussinessLogic.Service;

public class BookingReservationService : IBookingReservationService
{
    private readonly IBookingReservationRepository _reservationRepository;
    private readonly IRoomInformationRepository _roomInformationRepository;
    private readonly IMapper _mapper;

    public BookingReservationService(IBookingReservationRepository reservationRepository, IRoomInformationRepository roomInformationRepository, IMapper mapper)
    {
        _mapper = mapper;
        _roomInformationRepository = roomInformationRepository;
        _reservationRepository = reservationRepository;
    }
    public async Task<List<ReservationResponse>> GetBookingReservations()
    {
        return _mapper.Map<List<ReservationResponse>>( await _reservationRepository.GetAll());
    }

    public async Task<ReservationResponse> GetBookingReservation(int id)
    {
        return _mapper.Map<ReservationResponse>(await _reservationRepository.Get(id));
    }

    public async Task<List<ReservationResponse>> GetBookingReservationByCustomerId(int id)
    {
        var result = _mapper.Map<List<ReservationResponse>>(await _reservationRepository.GetListByCustomerID(id));
        return result;
    }

    public async Task<ReservationResponse> CreateBookingReservation(BookingRequest bookingRequest)
    {
        var listRoom = await _roomInformationRepository.GetRoomToBooking(bookingRequest.RoomType, bookingRequest.StartDate,
            bookingRequest.EndDate);
        if (listRoom.Count < bookingRequest.Quantity)
        {
            throw new Exception($" Just Have {listRoom.Count} Room");
        }
        
        //Create new Reservation
        var reservation = _mapper.Map<BookingReservation>(bookingRequest);
        decimal totalPrice = 0;
        reservation.BookingReservationId = await _reservationRepository.Count() + 1;
        
        //Create Detail
        
        for (int i = 0; i < bookingRequest.Quantity; i++)
        {
            var detail = new BookingDetail();
            detail.BookingReservationId = reservation.BookingReservationId;
            detail.RoomId = listRoom[i].RoomId;
            detail.StartDate = bookingRequest.StartDate;
            detail.EndDate = bookingRequest.EndDate;
            detail.ActualPrice = bookingRequest.EndDate.Subtract(bookingRequest.StartDate).Days * listRoom[i].RoomPricePerDay;
            totalPrice += detail.ActualPrice.Value;
            reservation.BookingDetails.Add(detail);
        }

        //Save
        reservation.TotalPrice = totalPrice;
        _reservationRepository.Add(reservation);

        return _mapper.Map<ReservationResponse>(reservation);
    }

    public async Task<ReservationResponse> UpdateBookingReservation(BookingReservation bookingReservation)
    {
        return _mapper.Map<ReservationResponse>(await _reservationRepository.Update(bookingReservation));
    }

    public async Task DeleteBookingReservation(int id)
    {
        _reservationRepository.Delete(id);
    }
}