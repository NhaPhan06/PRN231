using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DataAccess;
using ModelsLayer.BusinessObjects;
using Newtonsoft.Json;

namespace WebRazor.Pages.Customer
{
    public class CustomerInformationModel : PageModel
    {
        private readonly HttpClient _client = new HttpClient();

        [BindProperty]
        public ModelsLayer.BusinessObjects.Customer Customer { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync()
        {
            var id = HttpContext.Session.GetString("account");
            if (id == null)
            {
                return RedirectToPage("../Index");
            }
            var list = await _client.GetAsync($"https://localhost:7098/api/Customer/GetCustomer/{id}");
            if (list.IsSuccessStatusCode)
            {
                var json = await list.Content.ReadAsStringAsync();
                Customer = JsonConvert.DeserializeObject<ModelsLayer.BusinessObjects.Customer>(json);
            }
            return Page();
        }
        
        /*public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Customer).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CustomerExists(Customer.CustomerId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./");
        }*/
    }
}
