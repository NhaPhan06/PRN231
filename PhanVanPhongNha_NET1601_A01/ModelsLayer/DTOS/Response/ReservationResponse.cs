using ModelsLayer.BusinessObjects;

namespace ModelsLayer.DTOS.Response;

public class ReservationResponse
{
    public int BookingReservationId { get; set; }
    public DateTime? BookingDate { get; set; }
    public decimal? TotalPrice { get; set; }
    public List<BookingDetail> BookingDetails { get; set; }
}


