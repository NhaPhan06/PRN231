using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DataAccess;
using ModelsLayer.BusinessObjects;
using ModelsLayer.DTOS.Response;
using Newtonsoft.Json;
using NuGet.Protocol;

namespace WebRazor.Pages.BookingReservation
{
    public class IndexModel : PageModel
    {
        private readonly HttpClient _client = new HttpClient();


        public IList<ReservationResponse> BookingReservation { get;set; } = default!;

        public async Task OnGetAsync()
        {

            var response = await _client.GetAsync("api/BookingReservation/GetBookingReservations");

            if (response.IsSuccessStatusCode)
            {
                var jsonString = await response.Content.ReadAsStringAsync();

                BookingReservation = JsonConvert.DeserializeObject<List<ReservationResponse>>(jsonString);
            }
            else
            {
                // Handle the case where the HTTP request was not successful
                // You might want to log an error or throw an exception
            }
        }
    }
}
