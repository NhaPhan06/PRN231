

using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using BussinessLogic.Configuration;
using BussinessLogic.IService;
using DataAccess.IRepository;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using ModelsLayer.BusinessObjects;
using ModelsLayer.DTOS.Request;
using ModelsLayer.DTOS.Response;

namespace BussinessLogic.Service;

public class AuthenticationService : IAuthenticationService
{
    private readonly AppConfiguration _appConfiguration;
    private readonly ICustomerRepository _customerRepository;

    public AuthenticationService(IOptions<AppConfiguration> appConfiguration, ICustomerRepository customerRepository)
    {
        _appConfiguration = appConfiguration.Value;
        _customerRepository = customerRepository;
    }
    
    public async Task<string> Login(LoginRequest request)
    {
        var customer = await _customerRepository.CheckLogin(request.Email, request.Password);
        if (request.Email == _appConfiguration.Email && request.Password == _appConfiguration.Password)
        {
            return "Admin";
        }
        if ( customer != null)
        {
            return customer.CustomerId.ToString();
        }
        return null;
    }

    public async Task<LoginRespone> Validate(LoginRequest accountLogin)
    {
        
        //check account has Exist or not
        var Account = await _customerRepository.CheckLogin(accountLogin.Email, accountLogin.Password);
        var response = new LoginRespone();
        if (Account == null)
        {
            response.Success = false;
            response.Messenger = "Username Not Exist";
            return response;
        }
        if (accountLogin.Email == _appConfiguration.Email && accountLogin.Password == _appConfiguration.Password)
        {
            response.Data = GenerateToken(Account, _appConfiguration.JWTSecretKey, "Admin");
            response.Success = true;
            response.Messenger = "Login Success";
            return response;
        }
        response.Data = GenerateToken(Account, _appConfiguration.JWTSecretKey, "Customer");
        response.Success = true;
        response.Messenger = "Login Success";
        return response;
    }
    
    public async Task<Boolean> Logout(Guid AccountId)
    {
        try
        {
            //_cacheManager.Remove(AccountId.ToString());
        }
        catch (Exception e)
        {
            throw e;
        }
        return true;
    }
    
    public string GenerateToken(Customer user, string secretKey, string role)
    {

        var jwtTokenHandler = new JwtSecurityTokenHandler();
        var secretKryByte = Encoding.UTF8.GetBytes(secretKey);
        SecurityTokenDescriptor tokenDescription;
        if (user is null)
        {
            tokenDescription = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.NameIdentifier, "Admin"),
                    new Claim(ClaimTypes.Role, role)
                }),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(secretKryByte), SecurityAlgorithms.HmacSha256)
            };
            var token1 = jwtTokenHandler.CreateToken(tokenDescription);
            return jwtTokenHandler.WriteToken(token1);
        }
        tokenDescription = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.CustomerFullName),
                new Claim("Id", user.CustomerId.ToString()),
                new Claim(ClaimTypes.Role, role)
            }),
            Expires = DateTime.UtcNow.AddHours(1),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(secretKryByte), SecurityAlgorithms.HmacSha256)
        };
        var token = jwtTokenHandler.CreateToken(tokenDescription);
        return jwtTokenHandler.WriteToken(token);
    }
}