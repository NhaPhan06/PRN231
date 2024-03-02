
using System.IdentityModel.Tokens.Jwt;
using System.Net.Http.Headers;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using JsonSerializer = System.Text.Json.JsonSerializer;
namespace WebRazor.Pages.Customer
{
    public class CustomerInformationModel : PageModel
    {
        private readonly HttpClient _client = new HttpClient();
        private readonly IConfiguration _configuration;
        
        public CustomerInformationModel(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [BindProperty]
        public ModelsLayer.BusinessObjects.Customer Customer { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync()
        {
                        
            var accessToken = HttpContext.Session.GetString("account");
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            var id = GetIdFromJwt(accessToken);
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
        
        public async Task<IActionResult> OnPostAsync()
        {
            var accessToken = HttpContext.Session.GetString("account");
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            if (!ModelState.IsValid)
            {
                return Page();
            }
            
            try
            {
                var json = JsonSerializer.Serialize(Customer);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var response = _client.PutAsync("https://localhost:7098/api/Customer/UpdateCustomer", content).Result;
                if (response.IsSuccessStatusCode)
                {
                    return Page();
                }
            }
            catch (Exception e)
            {
                ViewData["notification"] = e.Message;
            }
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
