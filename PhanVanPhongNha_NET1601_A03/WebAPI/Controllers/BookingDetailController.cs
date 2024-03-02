using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using BussinessLogic.IService;
using DataAccess;
using Microsoft.AspNetCore.Authorization;
using ModelsLayer.BusinessObjects;

namespace WebAPI.Controllers
{
    [Authorize]
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
        
        // GET: api/BookingDetail
        [HttpGet("{id}")]
        public async Task<ActionResult<List<BookingDetail>>> GetBookingDetailsByReservationId(int id)
        {
            var result  = await _bookingDetail.GetBookingDetailsByReservationId(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
    }
}