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
    }
}