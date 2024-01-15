using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DataAccess;
using ModelsLayer.BusinessObjects;

namespace WebRazor.Pages.BookingReservation
{
    public class DetailsModel : PageModel
    {
        private readonly DataAccess.FUMiniHotelManagementContext _context;

        public DetailsModel(DataAccess.FUMiniHotelManagementContext context)
        {
            _context = context;
        }

      public ModelsLayer.BusinessObjects.BookingReservation BookingReservation { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.BookingReservations == null)
            {
                return NotFound();
            }

            var bookingreservation = await _context.BookingReservations.FirstOrDefaultAsync(m => m.BookingReservationId == id);
            if (bookingreservation == null)
            {
                return NotFound();
            }
            else 
            {
                BookingReservation = bookingreservation;
            }
            return Page();
        }
    }
}
