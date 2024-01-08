using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BusinessObjects.Entities;
using DataAccess;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomInformationController : ControllerBase
    {
        private readonly FUMiniHotelManagementContext _context;

        public RoomInformationController(FUMiniHotelManagementContext context)
        {
            _context = context;
        }

        // GET: api/RoomInformation
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RoomInformation>>> GetRoomInformations()
        {
          if (_context.RoomInformations == null)
          {
              return NotFound();
          }
            return await _context.RoomInformations.ToListAsync();
        }

        // GET: api/RoomInformation/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RoomInformation>> GetRoomInformation(int id)
        {
          if (_context.RoomInformations == null)
          {
              return NotFound();
          }
            var roomInformation = await _context.RoomInformations.FindAsync(id);

            if (roomInformation == null)
            {
                return NotFound();
            }

            return roomInformation;
        }

        // PUT: api/RoomInformation/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRoomInformation(int id, RoomInformation roomInformation)
        {
            if (id != roomInformation.RoomId)
            {
                return BadRequest();
            }

            _context.Entry(roomInformation).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RoomInformationExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/RoomInformation
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<RoomInformation>> PostRoomInformation(RoomInformation roomInformation)
        {
          if (_context.RoomInformations == null)
          {
              return Problem("Entity set 'FUMiniHotelManagementContext.RoomInformations'  is null.");
          }
            _context.RoomInformations.Add(roomInformation);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRoomInformation", new { id = roomInformation.RoomId }, roomInformation);
        }

        // DELETE: api/RoomInformation/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRoomInformation(int id)
        {
            if (_context.RoomInformations == null)
            {
                return NotFound();
            }
            var roomInformation = await _context.RoomInformations.FindAsync(id);
            if (roomInformation == null)
            {
                return NotFound();
            }

            _context.RoomInformations.Remove(roomInformation);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RoomInformationExists(int id)
        {
            return (_context.RoomInformations?.Any(e => e.RoomId == id)).GetValueOrDefault();
        }
    }
}
