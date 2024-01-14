using System.Text;
using BussinessLogic.IService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ModelsLayer.DTOS.Request;
using Newtonsoft.Json;
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
                    return RedirectToPage("Privacy");
                }
                else if (data == "Customer")
                {
                    return RedirectToPage("Error");
                } ;
            }
            return RedirectToPage("/CandidateProfile/Index");
        }
    }