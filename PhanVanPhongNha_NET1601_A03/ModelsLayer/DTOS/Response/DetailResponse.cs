namespace ModelsLayer.DTOS.Response;

public class DetailResponse
{
    public int RoomId { get; set; }
    public string RoomNumber { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public decimal? ActualPrice { get; set; }
}