﻿namespace ModelsLayer.DTOS.Response;

public class RoomResponse
{
    public int RoomId { get; set; }
    public string RoomNumber { get; set; } = null!;
    public string? RoomDetailDescription { get; set; }
    public int? RoomMaxCapacity { get; set; }
    public int RoomTypeId { get; set; }
    public String? RoomType { get; set; }
    public byte? RoomStatus { get; set; }
    public decimal? RoomPricePerDay { get; set; }
}