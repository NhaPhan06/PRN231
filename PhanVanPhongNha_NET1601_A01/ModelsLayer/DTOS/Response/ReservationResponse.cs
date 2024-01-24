using ModelsLayer.BusinessObjects;

namespace ModelsLayer.DTOS.Response;

public class ReservationResponse
{
    public int BookingReservationId { get; set; }
    public int CustomerId { get; set; }
    public DateTime? BookingDate { get; set; }
    public decimal? TotalPrice { get; set; }
    
    public int Status { get; set; }
    public List<DetailResponse> DetailResponse { get; set; }
}


