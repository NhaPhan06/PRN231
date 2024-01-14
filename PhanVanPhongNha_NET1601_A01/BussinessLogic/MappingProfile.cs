

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
            .ForMember(dest => dest.TotalPrice, opt => opt.MapFrom(src => src.TotalPrice))
            .ForMember(dest => dest.BookingReservationId, opt => opt.MapFrom(src => src.BookingReservationId))
            .ForMember(dest => dest.BookingDetails, opt => opt.MapFrom(src => src.BookingDetails))
            .ForMember(dest => dest.BookingDate, opt => opt.MapFrom(src => src.BookingDate));
        
        
        
    }

}