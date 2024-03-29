using System.ComponentModel.DataAnnotations;
using Microsoft.Practices.EnterpriseLibrary.Validation.Validators;

namespace ModelsLayer.DTOS.Request;

public class BookingRequest
{
    public DateTime? BookingDate { get; set; }
    public int CustomerId { get; set; }
    public int RoomType { get; set; }
    public int Quantity { get; set; }
    public DateTime StartDate { get; set;}
    public DateTime EndDate { get; set;}
    
}