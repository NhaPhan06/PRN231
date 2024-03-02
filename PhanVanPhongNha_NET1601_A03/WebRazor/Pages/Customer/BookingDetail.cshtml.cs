using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
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
    public class BookingDetailModel : PageModel
    {
        private readonly HttpClient _client = new HttpClient();
        public ReservationResponse BookingReservation { get; set; } = default!; 

        public async Task OnGetAsync(int id)
        {
            var accessToken = HttpContext.Session.GetString("account");
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            var reservation = await _client.GetAsync($"https://localhost:7098/api/BookingReservation/GetBookingReservation/{id}");
            if (reservation.IsSuccessStatusCode)
            {
                var jsonString = await reservation.Content.ReadAsStringAsync();

                BookingReservation = JsonConvert.DeserializeObject<ReservationResponse>(jsonString);
            }
        }
    }
}
