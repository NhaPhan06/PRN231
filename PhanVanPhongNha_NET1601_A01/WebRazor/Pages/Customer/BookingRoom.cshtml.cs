using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using DataAccess;
using ModelsLayer.BusinessObjects;
using ModelsLayer.DTOS.Request;
using ModelsLayer.DTOS.Response;

namespace WebRazor.Pages.Customer
{
    public class BookingRoomModel : PageModel
    {

        public IActionResult OnGet(int id)
        {
        ViewData["CustomerId"] = new SelectList(_context.Customers, "CustomerId", "EmailAddress");
            return Page();
        }

        [BindProperty]
        public BookingRequest BookingRequest { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.BookingReservations == null || BookingReservation == null)
            {
                return Page();
            }

            _context.BookingReservations.Add(BookingReservation);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
