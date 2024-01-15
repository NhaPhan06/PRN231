

using ModelsLayer.BusinessObjects;

namespace DataAccess.IRepository;

public interface IRoomTypeRepository
{
    Task<List<RoomType>> GetAll();
    Task<RoomType> Get(int id);
    Task<RoomType> Add(RoomType roomType);
    Task<RoomType> Update(RoomType roomType);
    void Delete(int id);
}