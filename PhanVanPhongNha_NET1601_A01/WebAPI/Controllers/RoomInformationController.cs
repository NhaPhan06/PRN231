using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BussinessLogic.IService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using DataAccess;
using ModelsLayer.BusinessObjects;

namespace WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class RoomInformationController : ControllerBase
    {
        private readonly IRoomInformationService _informationService;

        public RoomInformationController(IRoomInformationService informationService)
        {
            _informationService = informationService;
        }

        // GET: api/RoomInformation
        [HttpGet]
        public async Task<ActionResult<IList<RoomInformation>>> GetRoomInformations()
        {
            var result = await _informationService.GetRoomInformations();
          if (result == null)
          {
              return NotFound();
          }
            return result;
        }

         
         // GET: api/RoomInformation/5
         [HttpGet("{id}")]
         public async Task<ActionResult<RoomInformation>> GetRoomInformation(int id)
         {
             var roomInformation = await _informationService.GetRoomInformation(id);
             if (roomInformation == null)
             {
                 return NotFound();
             }

             return roomInformation;
         }
         
         // PUT: api/RoomInformation/5
         // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
         [HttpPut("{id}")]
         public async Task<IActionResult> UpdateRoomInformation(RoomInformation roomInformation)
         {
             return Ok(await _informationService.UpdateRoomInformation(roomInformation));
         }

         // POST: api/RoomInformation
         // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
         [HttpPost]
         public async Task<ActionResult<RoomInformation>> CreateRoomInformation(RoomInformation roomInformation)
         {
             return Ok(await _informationService.CreateRoomInformation(roomInformation));
         }

         // DELETE: api/RoomInformation/5
         [HttpDelete("{id}")]
         public async Task<IActionResult> DeleteRoomInformation(int id)
         {
             await _informationService.Delete(id);
             return NoContent();
         }
    }
}
