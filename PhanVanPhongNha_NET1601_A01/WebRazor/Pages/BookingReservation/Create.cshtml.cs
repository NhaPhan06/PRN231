using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using DataAccess;
using ModelsLayer.BusinessObjects;

namespace WebRazor.Pages.BookingReservation
{
    public class CreateModel : PageModel
    {
        private readonly DataAccess.FUMiniHotelManagementContext _context;

        public CreateModel(DataAccess.FUMiniHotelManagementContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["CustomerId"] = new SelectList(_context.Customers, "CustomerId", "EmailAddress");
            return Page();
        }

        [BindProperty]
        public ModelsLayer.BusinessObjects.BookingReservation BookingReservation { get; set; } = default!;
        

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
