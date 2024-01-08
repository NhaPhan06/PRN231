using BusinessObjects.Entities;

namespace DataAccess.IRepository;

public interface IRoomInformationRepository
{
    Task<IEnumerable<RoomInformation>> GetAll();
    Task<RoomInformation> Get(int id);
    void Add(RoomInformation roomInformation);
    void Update(RoomInformation roomInformation);
    void Delete(int id);
}