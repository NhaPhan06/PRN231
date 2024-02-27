namespace ModelsLayer.DTOS.Request;

public class CreateRoomRequest
{
    public string RoomNumber { get; set; } = null!;
    public string? RoomDetailDescription { get; set; }
    public int? RoomMaxCapacity { get; set; }
    public int RoomTypeId { get; set; }
    public decimal? RoomPricePerDay { get; set; }
}