

using ModelsLayer.BusinessObjects;
using ModelsLayer.DTOS.Request;
using ModelsLayer.DTOS.Response;

namespace BussinessLogic.IService;

public interface IRoomInformationService
{
    public Task<List<RoomResponse>> GetRoomInformations();
    public Task<RoomResponse> GetRoomInformation(int id);
    public Task<RoomResponse> UpdateRoomInformation(RoomInformation roomInformation);
    public Task<RoomResponse> CreateRoomInformation(CreateRoomRequest roomInformation);
    public Task Delete(int id);
    
}