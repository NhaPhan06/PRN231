using BussinessLogic.IService;
using DataAccess.IRepository;
using ModelsLayer.BusinessObjects;

namespace BussinessLogic.Service;

public class RoomInformationService : IRoomInformationService
{
    private readonly IRoomInformationRepository _informationRepository;

    public RoomInformationService(IRoomInformationRepository roomInformationRepository)
    {
        _informationRepository = roomInformationRepository;
    }
    public async Task<List<RoomInformation>> GetRoomInformations()
    {
        return await _informationRepository.GetAll();
    }

    public async Task<RoomInformation> GetRoomInformation(int id)
    {
        return await _informationRepository.Get(id);
    }

    public async Task<RoomInformation> UpdateRoomInformation(RoomInformation roomInformation)
    {
        return await _informationRepository.Update(roomInformation);
    }

    public async Task<RoomInformation> CreateRoomInformation(RoomInformation roomInformation)
    {
        return await _informationRepository.Add(roomInformation);
    }

    public async Task Delete(int id)
    {
        _informationRepository.Delete(id);
    }
}