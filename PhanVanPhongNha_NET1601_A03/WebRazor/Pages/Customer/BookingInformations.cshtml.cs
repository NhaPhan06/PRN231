using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DataAccess;
using Microsoft.IdentityModel.Tokens;
using ModelsLayer.BusinessObjects;
using ModelsLayer.DTOS.Response;
using Newtonsoft.Json;

namespace WebRazor.Pages.Customer
{
    public class BookingInformationsModel : PageModel
    {
        private readonly HttpClient _client = new HttpClient();
        private readonly IConfiguration _configuration;
        
        public BookingInformationsModel(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public IList<ReservationResponse> BookingReservation { get;set; } = default!;

        public async Task<IActionResult> OnGetAsync()
        {
            var accessToken = HttpContext.Session.GetString("account");
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            var id = GetIdFromJwt(accessToken);
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
            var accessToken = HttpContext.Session.GetString("account");
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            var change = await _client.DeleteAsync($"https://localhost:7098/api/BookingReservation/DeleteBookingReservation/{id}");
            await OnGetAsync();
            return Page();
        }
        
        public string GetIdFromJwt(string jwtToken)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configuration["AppConfiguration:JWTSecretKey"]);

            tokenHandler.ValidateToken(jwtToken, new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidateIssuer = false,
                ValidateAudience = false
            }, out SecurityToken validatedToken);

            var jwtTokenDecoded = (JwtSecurityToken)validatedToken;

            // Truy cập vào các thông tin trong payload
            string userId = jwtTokenDecoded.Claims.FirstOrDefault(x => x.Type == "Id")?.Value;

            return userId;
        }
    }
}
