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
    public class BookingDetailController : ControllerBase
    {
        private readonly FUMiniHotelManagementContext _context;

        public BookingDetailController(FUMiniHotelManagementContext context)
        {
            _context = context;
        }

        // GET: api/BookingDetail
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BookingDetail>>> GetBookingDetails()
        {
          if (_context.BookingDetails == null)
          {
              return NotFound();
          }
            return await _context.BookingDetails.ToListAsync();
        }

        // GET: api/BookingDetail/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BookingDetail>> GetBookingDetail(int id)
        {
          if (_context.BookingDetails == null)
          {
              return NotFound();
          }
            var bookingDetail = await _context.BookingDetails.FindAsync(id);

            if (bookingDetail == null)
            {
                return NotFound();
            }

            return bookingDetail;
        }

        // PUT: api/BookingDetail/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBookingDetail(int id, BookingDetail bookingDetail)
        {
            if (id != bookingDetail.BookingReservationId)
            {
                return BadRequest();
            }

            _context.Entry(bookingDetail).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BookingDetailExists(id))
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

        // POST: api/BookingDetail
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<BookingDetail>> PostBookingDetail(BookingDetail bookingDetail)
        {
          if (_context.BookingDetails == null)
          {
              return Problem("Entity set 'FUMiniHotelManagementContext.BookingDetails'  is null.");
          }
            _context.BookingDetails.Add(bookingDetail);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (BookingDetailExists(bookingDetail.BookingReservationId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetBookingDetail", new { id = bookingDetail.BookingReservationId }, bookingDetail);
        }

        // DELETE: api/BookingDetail/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBookingDetail(int id)
        {
            if (_context.BookingDetails == null)
            {
                return NotFound();
            }
            var bookingDetail = await _context.BookingDetails.FindAsync(id);
            if (bookingDetail == null)
            {
                return NotFound();
            }

            _context.BookingDetails.Remove(bookingDetail);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BookingDetailExists(int id)
        {
            return (_context.BookingDetails?.Any(e => e.BookingReservationId == id)).GetValueOrDefault();
        }
    }
}