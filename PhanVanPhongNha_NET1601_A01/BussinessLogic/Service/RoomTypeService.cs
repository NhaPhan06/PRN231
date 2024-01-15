using BussinessLogic.IService;
using DataAccess.IRepository;
using ModelsLayer.BusinessObjects;

namespace BussinessLogic.Service;

public class RoomTypeService : IRoomTypeService
{
    public readonly IRoomTypeRepository _roomTypeRepository;

    public RoomTypeService(IRoomTypeRepository roomTypeRepository)
    {
        _roomTypeRepository = roomTypeRepository;
    }

    public Task<RoomType> Create(RoomType roomType)
    {
        return _roomTypeRepository.Add(roomType);
    }

    public async Task<List<RoomType>> Read()
    {
        return await _roomTypeRepository.GetAll();
    }

    public async Task<RoomType> Update(RoomType roomType)
    {
        return await _roomTypeRepository.Update(roomType);
    }

    public async Task Delete(int id)
    {
       _roomTypeRepository.Delete(id);
    }
}