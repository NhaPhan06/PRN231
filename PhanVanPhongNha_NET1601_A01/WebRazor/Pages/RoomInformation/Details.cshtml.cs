using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DataAccess;
using ModelsLayer.BusinessObjects;

namespace WebRazor.Pages.RoomInformation
{
    public class DetailsModel : PageModel
    {
        private readonly DataAccess.FUMiniHotelManagementContext _context;

        public DetailsModel(DataAccess.FUMiniHotelManagementContext context)
        {
            _context = context;
        }

      public ModelsLayer.BusinessObjects.RoomInformation RoomInformation { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.RoomInformations == null)
            {
                return NotFound();
            }

            var roominformation = await _context.RoomInformations.FirstOrDefaultAsync(m => m.RoomId == id);
            if (roominformation == null)
            {
                return NotFound();
            }
            else 
            {
                RoomInformation = roominformation;
            }
            return Page();
        }
    }
}
