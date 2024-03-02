using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ModelsLayer.DTOS.Request;
using BussinessLogic.IService;
using BussinessLogic.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ModelsLayer.DTOS.Response;

namespace WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AthenticationController : ControllerBase
    {
        private readonly IAuthenticationService _authenticationService;

        public AthenticationController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }
        
        [HttpPost]
        public async Task<ActionResult<LoginRespone>> Login(LoginRequest request)
        {
            var result  = await _authenticationService.Validate(request);
            if (result.Data == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
        
        [HttpPost]
        public async Task<ActionResult<Boolean>> Logout(Guid AccountId)
        {
            var user = _authenticationService.Logout(AccountId);
            //cấp token
            return Ok(user);
        }
    }
}
