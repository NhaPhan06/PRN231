using ModelsLayer.BusinessObjects;

namespace BussinessLogic.IService;

public interface IRoomTypeService
{
    public Task<RoomType> Create(RoomType roomType);
    public Task<List<RoomType>> Read();
    public Task<RoomType> Update(RoomType roomType);
    public Task Delete(int id);
}