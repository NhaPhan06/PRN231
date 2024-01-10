using BusinessObjects.DTOS.Request;

namespace BussinessLogic.IService;

public interface IAuthenticationService
{
    Task<String> Login(LoginRequest request);
}