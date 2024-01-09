using BusinessObjects.Entities;

namespace DataAccess.IRepository;

public interface IRoomTypeRepository
{
    Task<IEnumerable<RoomType>> GetAll();
    Task<RoomType> Get(int id);
    void Add(RoomType roomType);
    void Update(RoomType roomType);
    void Delete(int id);
}