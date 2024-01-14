

using ModelsLayer.BusinessObjects;

namespace BussinessLogic.IService;

public interface IRoomInformationService
{
    public Task<List<RoomInformation>> GetRoomInformations();
    public Task<RoomInformation> GetRoomInformation(int id);
    public Task<RoomInformation> UpdateRoomInformation(RoomInformation roomInformation);
    public Task<RoomInformation> CreateRoomInformation(RoomInformation roomInformation);
    public Task Delete(int id);
    
}