using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ModelsLayer.DTOS.Request;
using BussinessLogic.IService;
using BussinessLogic.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
        public async Task<ActionResult<String>> Login(LoginRequest request)
        {
            var result  = await _authenticationService.Login(request);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
    }
}
