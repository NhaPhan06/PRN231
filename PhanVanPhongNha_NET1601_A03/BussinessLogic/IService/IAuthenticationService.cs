using ModelsLayer.DTOS.Request;
using ModelsLayer.DTOS.Response;

namespace BussinessLogic.IService;

public interface IAuthenticationService
{
    Task<String> Login(LoginRequest request);
    Task<LoginRespone> Validate(LoginRequest accountLogin);
    Task<Boolean> Logout(Guid AccountId);
}