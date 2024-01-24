using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DataAccess;
using ModelsLayer.BusinessObjects;
using ModelsLayer.DTOS.Response;
using Newtonsoft.Json;

namespace WebRazor.Pages.Customer
{
    public class BookingInformationsModel : PageModel
    {
        private readonly HttpClient _client = new HttpClient();
        public IList<ReservationResponse> BookingReservation { get;set; } = default!;

        public async Task<IActionResult> OnGetAsync()
        {
            var id = HttpContext.Session.GetString("account");
            if (id == null)
            {
                return RedirectToPage("../Index");
            }
            var response = await _client.GetAsync($"https://localhost:7098/api/BookingReservation/GetBookingReservationsByCustomer/{id}");

            if (response.IsSuccessStatusCode)
            {
                var jsonString = await response.Content.ReadAsStringAsync();

                BookingReservation = JsonConvert.DeserializeObject<List<ReservationResponse>>(jsonString);
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            var change = await _client.DeleteAsync($"https://localhost:7098/api/BookingReservation/DeleteBookingReservation/{id}");
            await OnGetAsync();
            return Page();
        }
    }
}
