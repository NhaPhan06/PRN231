using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using BussinessLogic.IService;
using DataAccess;
using ModelsLayer.BusinessObjects;

namespace WebAPI.Controllers
{
    [Microsoft.AspNetCore.Mvc.Route("api/[controller]/[action]")]
    [ApiController]
    public class BookingDetailController : ControllerBase
    {
        private readonly IBookingDetailService _bookingDetail;

        public BookingDetailController(IBookingDetailService bookingDetail)
        {
            _bookingDetail = bookingDetail;
        }

        // GET: api/BookingDetail
        [Microsoft.AspNetCore.Mvc.HttpGet]
        public async Task<ActionResult<List<BookingDetail>>> GetBookingDetails()
        {
            var result  = await _bookingDetail.GetBookingDetails();
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        /*// GET: api/BookingDetail/5
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
        }*/
    }
}