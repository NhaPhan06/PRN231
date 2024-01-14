

using BussinessLogic.Configuration;
using BussinessLogic.IService;
using DataAccess.IRepository;
using Microsoft.Extensions.Options;
using ModelsLayer.DTOS.Request;

namespace BussinessLogic.Service;

public class AuthenticationService : IAuthenticationService
{
    private readonly AdminAccount _adminAccount;
    private readonly ICustomerRepository _customerRepository;

    public AuthenticationService(IOptions<AdminAccount> adminAccount, ICustomerRepository customerRepository)
    {
        _adminAccount = adminAccount.Value;
        _customerRepository = customerRepository;
    }
    
    public async Task<string> Login(LoginRequest request)
    {
        if (request.Email == _adminAccount.Email && request.Password == _adminAccount.Password)
        {
            return "Admin";
        }
        else if ( await _customerRepository.CheckLogin(request.Email,request.Password) == true)
        {
            return "Customer";
        }
        else
        {
            return null;
        }
    }
}