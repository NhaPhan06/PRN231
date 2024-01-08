using BussinessLogic.IService;
using DataAccess.IRepository;

namespace BussinessLogic.Service;

public class RoomInformationService : IRoomInformationService
{
    private IRoomInformationRepository _roomInformationRepository;

    RoomInformationService(IRoomInformationRepository roomInformationRepository)
    {
        _roomInformationRepository = roomInformationRepository;
    }
}