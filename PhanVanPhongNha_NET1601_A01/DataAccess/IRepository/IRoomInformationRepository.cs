

using ModelsLayer.BusinessObjects;

namespace DataAccess.IRepository;

public interface IRoomInformationRepository
{
    Task<List<RoomInformation>> GetRoomToBooking(int id, DateTime start, DateTime end);
    Task<List<RoomInformation>> GetAll();
    Task<RoomInformation> Get(int id);
    Task<RoomInformation> Add(RoomInformation roomInformation);
    Task<RoomInformation> Update(RoomInformation roomInformation);
    Task<int> Count();
    void Delete(int id);
}