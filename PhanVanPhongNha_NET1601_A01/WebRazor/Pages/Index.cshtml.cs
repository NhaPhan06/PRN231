using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ModelsLayer.DTOS.Request;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace WebRazor.Pages;

public class IndexModel : PageModel {
        private readonly HttpClient _client = new HttpClient();
        
        [BindProperty]
        public LoginRequest  LoginRequest { get; set; }

        public void OnGet() {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var json = JsonSerializer.Serialize(LoginRequest);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = _client.PostAsync("https://localhost:7098/api/Athentication/Login", content).Result;
            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadAsStringAsync();
                if (data == "Admin")
                {
                    HttpContext.Session.SetString("account", data);
                    return RedirectToPage("./Admin/RoomInformations");
                }
                else
                {
                    HttpContext.Session.SetString("account", data);
                    return RedirectToPage("./Customer/CustomerInformation");
                } ;
            }
            return Page();
        }
    }