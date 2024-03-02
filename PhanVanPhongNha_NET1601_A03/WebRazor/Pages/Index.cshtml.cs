using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ModelsLayer.DTOS.Request;
using ModelsLayer.DTOS.Response;
using Newtonsoft.Json;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace WebRazor.Pages;

public class IndexModel : PageModel {
        private readonly HttpClient _client = new HttpClient();
        
        [BindProperty]
        public LoginRequest  LoginRequest { get; set; }

        public void OnGet()
        {
                HttpContext.Session.Clear();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var json = JsonSerializer.Serialize(LoginRequest);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = _client.PostAsync("https://localhost:7098/api/Athentication/Login", content).Result;
            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadAsStringAsync();
                var token = JsonConvert.DeserializeObject<LoginRespone>(data);
                if (data == "Admin")
                {
                    HttpContext.Session.SetString("account", token.Data);
                    return RedirectToPage("./Admin/RoomInformations");
                }
                else
                {
                    HttpContext.Session.SetString("account", token.Data);
                    return RedirectToPage("./Customer/ListTypeRoom");
                } ;
            }
            return Page();
        }
    }