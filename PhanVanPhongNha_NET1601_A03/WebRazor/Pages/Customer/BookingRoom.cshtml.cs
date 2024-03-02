using System.IdentityModel.Tokens.Jwt;
using System.Net.Http.Headers;
using System.Text;
using BussinessLogic.Middleware;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.IdentityModel.Tokens;
using ModelsLayer.BusinessObjects;
using ModelsLayer.DTOS.Request;
using ModelsLayer.DTOS.Response;
using Newtonsoft.Json;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace WebRazor.Pages.Customer
{
    public class BookingRoomModel : PageModel
    {
        private readonly HttpClient _client = new HttpClient();
        
        private readonly IConfiguration _configuration;
        
        public BookingRoomModel(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [BindProperty]
        public BookingRequest BookingRequest { get; set; } = default!;
        public RoomType typeRoom { get; set; }
        public async Task<IActionResult> OnGetAsync(int id)
        {
            var accessToken = HttpContext.Session.GetString("account");
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            var json = await _client.GetAsync($"https://localhost:7098/api/RoomType/GetRoomTypesByID/{id}");
            if (json.IsSuccessStatusCode)
            {
                typeRoom = JsonConvert.DeserializeObject<RoomType>(await json.Content.ReadAsStringAsync());
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int typeId)
        {
            var accessToken = HttpContext.Session.GetString("account");
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            BookingRequest.BookingDate = DateTime.Now;
            BookingRequest.CustomerId = int.Parse(GetIdFromJwt(accessToken));
            BookingRequest.RoomType = typeId;
            try
            {
                var json = JsonSerializer.Serialize(BookingRequest);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var response = _client.PostAsync("https://localhost:7098/api/BookingReservation/CreateBookingReservation", content).Result;
                if (response.IsSuccessStatusCode)
                {
                    return RedirectToPage("./ListTypeRoom");
                }
                else
                {
                    var result = JsonSerializer.Deserialize<ErrorResult>(await response.Content.ReadAsStringAsync());
                    throw new Exception(result.Exception);
                }
            }
            catch (Exception e)
            {
                ViewData["notification"] = e.Message;
            }
            await OnGetAsync(typeId);
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
