using AutoMapper;
using BussinessLogic.IService;
using DataAccess.IRepository;
using ModelsLayer.BusinessObjects;
using ModelsLayer.DTOS.Request;
using ModelsLayer.DTOS.Response;

namespace BussinessLogic.Service;

public class RoomInformationService : IRoomInformationService
{
    private readonly IRoomInformationRepository _informationRepository;
    private readonly IMapper _mapper;

    public RoomInformationService(IRoomInformationRepository roomInformationRepository, IMapper mapper)
    {
        _mapper = mapper;
        _informationRepository = roomInformationRepository;
    }
    public async Task<List<RoomResponse>> GetRoomInformations()
    {
        return _mapper.Map<List<RoomResponse>>(await _informationRepository.GetAll());
    }

    public async Task<RoomResponse> GetRoomInformation(int id)
    {
        return _mapper.Map<RoomResponse>(await _informationRepository.Get(id));
    }

    public async Task<RoomResponse> UpdateRoomInformation(RoomResponse roomInformation)
    {
        var room = await _informationRepository.Get(roomInformation.RoomId);
        room.RoomTypeId = roomInformation.RoomTypeId;
        room.RoomNumber = roomInformation.RoomNumber;
        room.RoomMaxCapacity = roomInformation.RoomMaxCapacity;
        room.RoomDetailDescription = roomInformation.RoomDetailDescription;
        room.RoomPricePerDay = roomInformation.RoomPricePerDay;
        return _mapper.Map<RoomResponse>(await _informationRepository.Update(room));
    }

    public async Task<RoomResponse> CreateRoomInformation(CreateRoomRequest roomInformation)
    {
        var room = _mapper.Map<RoomInformation>(roomInformation);
        return _mapper.Map<RoomResponse>(await _informationRepository.Add(room));
    }

    public async Task Delete(int id)
    {
        _informationRepository.Delete(id);
    }
}