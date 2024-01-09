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
    public class BookingReservationController : ControllerBase
    {
        private readonly FUMiniHotelManagementContext _context;

        public BookingReservationController(FUMiniHotelManagementContext context)
        {
            _context = context;
        }

        // GET: api/BookingReservation
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BookingReservation>>> GetBookingReservations()
        {
          if (_context.BookingReservations == null)
          {
              return NotFound();
          }
            return await _context.BookingReservations.ToListAsync();
        }

        // GET: api/BookingReservation/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BookingReservation>> GetBookingReservation(int id)
        {
          if (_context.BookingReservations == null)
          {
              return NotFound();
          }
            var bookingReservation = await _context.BookingReservations.FindAsync(id);

            if (bookingReservation == null)
            {
                return NotFound();
            }

            return bookingReservation;
        }

        // PUT: api/BookingReservation/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBookingReservation(int id, BookingReservation bookingReservation)
        {
            if (id != bookingReservation.BookingReservationId)
            {
                return BadRequest();
            }

            _context.Entry(bookingReservation).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BookingReservationExists(id))
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

        // POST: api/BookingReservation
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<BookingReservation>> PostBookingReservation(BookingReservation bookingReservation)
        {
          if (_context.BookingReservations == null)
          {
              return Problem("Entity set 'FUMiniHotelManagementContext.BookingReservations'  is null.");
          }
            _context.BookingReservations.Add(bookingReservation);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (BookingReservationExists(bookingReservation.BookingReservationId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetBookingReservation", new { id = bookingReservation.BookingReservationId }, bookingReservation);
        }

        // DELETE: api/BookingReservation/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBookingReservation(int id)
        {
            if (_context.BookingReservations == null)
            {
                return NotFound();
            }
            var bookingReservation = await _context.BookingReservations.FindAsync(id);
            if (bookingReservation == null)
            {
                return NotFound();
            }

            _context.BookingReservations.Remove(bookingReservation);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BookingReservationExists(int id)
        {
            return (_context.BookingReservations?.Any(e => e.BookingReservationId == id)).GetValueOrDefault();
        }
    }
}
