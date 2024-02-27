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
    public class RoomTypeController : ControllerBase
    {
        private readonly IRoomTypeService _roomTypeService;

        public RoomTypeController(IRoomTypeService roomTypeService)
        {
            _roomTypeService = roomTypeService;
        }

        // GET: api/RoomType
        [HttpGet]
        public async Task<ActionResult<List<RoomType>>> GetRoomTypes()
        {
            return await _roomTypeService.Read();
        }
        
        // GET: api/RoomType
        [HttpGet("{id}")]
        public async Task<ActionResult<RoomType>> GetRoomTypesByID(int id)
        {
            return await _roomTypeService.GetById(id);
        }
        
        // PUT: api/RoomType/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<ActionResult<RoomType>> PutRoomType(RoomType roomType)
        {
            var room = await _roomTypeService.Update(roomType);
            return Ok(room);
        }

        // POST: api/RoomType
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<RoomType>> PostRoomType(RoomType roomType)
        {
            var room = await _roomTypeService.Update(roomType);
            return Ok(room);
        }

        // DELETE: api/RoomType/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRoomType(int id)
        {
            _roomTypeService.Delete(id);
            return NoContent();
        }

    }
}
