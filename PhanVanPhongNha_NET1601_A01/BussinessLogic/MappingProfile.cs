

using AutoMapper;
using ModelsLayer.BusinessObjects;
using ModelsLayer.DTOS.Request;
using ModelsLayer.DTOS.Response;

namespace BussinessLogic;

public class MappingProfile : Profile {
    
    public MappingProfile() {

        
        //Customer
        CreateMap<CreateCustomerRequest, Customer>()
            .ForMember(dest => dest.EmailAddress, opt => opt.MapFrom(src => src.EmailAddress))
            .ForMember(dest => dest.Password, opt => opt.MapFrom(src => src.Password))
            .ForMember(dest => dest.CustomerFullName, opt => opt.MapFrom(src => src.CustomerFullName))
            .ForMember(dest => dest.Telephone, opt => opt.MapFrom(src => src.Telephone))
            .ForMember(dest => dest.CustomerStatus, opt => opt.MapFrom(src => 1))
            .ForMember(dest => dest.CustomerBirthday, opt => opt.MapFrom(src => src.CustomerBirthday));

        
        //BookingReservation
        CreateMap<BookingRequest, BookingReservation>()
            .ForMember(dest => dest.CustomerId, opt => opt.MapFrom(src => src.CustomerId))
            .ForMember(dest => dest.BookingStatus, opt => opt.MapFrom(src => 1))
            .ForMember(dest => dest.BookingDate, opt => opt.MapFrom(src => DateTime.Now));

        CreateMap<BookingReservation, ReservationResponse>()
            .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.BookingStatus))
            .ForMember(dest => dest.TotalPrice, opt => opt.MapFrom(src => src.TotalPrice))
            .ForMember(dest => dest.BookingReservationId, opt => opt.MapFrom(src => src.BookingReservationId))
            .ForMember(dest => dest.CustomerId, opt => opt.MapFrom(src => src.CustomerId))
            .ForMember(dest => dest.BookingDate, opt => opt.MapFrom(src => src.BookingDate))
            .ForMember(dest => dest.DetailResponse, opt => opt.MapFrom(src => src.BookingDetails));
            
        CreateMap<BookingDetail, DetailResponse>()
            .ForMember(dest => dest.RoomNumber, opt => opt.MapFrom(src => src.Room.RoomNumber))
            .ForMember(dest => dest.RoomId, opt => opt.MapFrom(src => src.RoomId))
            .ForMember(dest => dest.ActualPrice, opt => opt.MapFrom(src => src.ActualPrice))
            .ForMember(dest => dest.StartDate, opt => opt.MapFrom(src => src.StartDate))
            .ForMember(dest => dest.EndDate, opt => opt.MapFrom(src => src.EndDate));

        
        //RoomInformation
        CreateMap<RoomInformation, RoomResponse>()
            .ForMember(dest => dest.RoomId, opt => opt.MapFrom(src => src.RoomId))
            .ForMember(dest => dest.RoomTypeId, opt => opt.MapFrom(src => src.RoomTypeId))
            .ForMember(dest => dest.RoomMaxCapacity, opt => opt.MapFrom(src => src.RoomMaxCapacity))
            .ForMember(dest => dest.RoomType, opt => opt.MapFrom(src => src.RoomType.RoomTypeName))
            .ForMember(dest => dest.RoomNumber, opt => opt.MapFrom(src => src.RoomNumber))
            .ForMember(dest => dest.RoomDetailDescription, opt => opt.MapFrom(src => src.RoomDetailDescription))
            .ForMember(dest => dest.RoomPricePerDay, opt => opt.MapFrom(src => src.RoomPricePerDay))
            .ForMember(dest => dest.RoomStatus, opt => opt.MapFrom(src => src.RoomStatus));

        CreateMap<CreateRoomRequest, RoomInformation>()
            .ForMember(dest => dest.RoomTypeId, opt => opt.MapFrom(src => src.RoomTypeId))
            .ForMember(dest => dest.RoomMaxCapacity, opt => opt.MapFrom(src => src.RoomMaxCapacity))
            .ForMember(dest => dest.RoomNumber, opt => opt.MapFrom(src => src.RoomNumber))
            .ForMember(dest => dest.RoomDetailDescription, opt => opt.MapFrom(src => src.RoomDetailDescription))
            .ForMember(dest => dest.RoomPricePerDay, opt => opt.MapFrom(src => src.RoomPricePerDay))
            .ForMember(dest => dest.RoomStatus, opt => opt.MapFrom(src => 1));
        
    }

}