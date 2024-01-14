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
using ModelsLayer.DTOS.Request;

namespace WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BookingReservationController : ControllerBase
    {
        private readonly IBookingReservationService _bookingReservationService;

        public BookingReservationController(IBookingReservationService bookingReservationService)
        {
            _bookingReservationService = bookingReservationService;
        }

        // GET: api/BookingReservation
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BookingReservation>>> GetBookingReservations()
        {
            return Ok(await _bookingReservationService.GetBookingReservations());
        }
        
        // GET
        [HttpGet("{id}")]
        public async Task<ActionResult<List<BookingReservation>>> GetBookingReservationsByCustomer(int id)
        {
            return Ok(await _bookingReservationService.GetBookingReservationByCustomerId(id));
        }

        // GET: api/BookingReservation/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BookingReservation>> GetBookingReservation(int id)
        {
            var bookingReservation = await _bookingReservationService.GetBookingReservation(id);
            if (bookingReservation == null)
            {
                return NotFound();
            }
            return Ok(bookingReservation);
        }

        // PUT: api/BookingReservation/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<ActionResult<BookingReservation>> PutBookingReservation(BookingReservation bookingReservation)
        {
            return Ok(await _bookingReservationService.UpdateBookingReservation(bookingReservation));
        }

        // POST: api/BookingReservation
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<BookingReservation>> CreateBookingReservation(BookingRequest bookingRequest)
        {
            var result = _bookingReservationService.CreateBookingReservation(bookingRequest);
            return Ok(result);
        }

        // DELETE: api/BookingReservation/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBookingReservation(int id)
        {
            var bookingReservation = await _bookingReservationService.GetBookingReservation(id);
            if (bookingReservation == null)
            {
                return NotFound();
            }
            _bookingReservationService.DeleteBookingReservation(id);
            return NoContent();
        }
        
    }
}
