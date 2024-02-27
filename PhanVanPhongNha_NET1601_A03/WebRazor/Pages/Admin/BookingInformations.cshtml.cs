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

namespace WebRazor.Pages.Admin
{
    public class BookingInformationsModel : PageModel
    {
        private readonly HttpClient _client = new HttpClient();
        public IList<ReservationResponse> BookingReservation { get;set; } = default!;

        public async Task OnGetAsync()
        {

            var response = await _client.GetAsync("https://localhost:7098/api/BookingReservation/GetBookingReservations");

            if (response.IsSuccessStatusCode)
            {
                var jsonString = await response.Content.ReadAsStringAsync();

                BookingReservation = JsonConvert.DeserializeObject<List<ReservationResponse>>(jsonString);
            }
        }
    }
}
