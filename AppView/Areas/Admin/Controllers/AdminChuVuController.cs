using AppData.Models;
using AppData.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace AppView.Areas.Admin.Controllers
{
    public class AdminChuVuController : Controller
    {
        private readonly HttpClient _httpClient;
        public AdminChuVuController()
        {
            _httpClient= new HttpClient();
        }
     /*   [Area("Admin")]*/
        [HttpGet]
        public async Task< IActionResult> ListChucVu()
        {
            var apiUrl = $"https://localhost:7284/api/ChucVu/GetAll";
            var response = await _httpClient.GetAsync(apiUrl);
            if (response.IsSuccessStatusCode)
            {
                var responeseData = await response.Content.ReadAsStringAsync();
                var data = JsonConvert.DeserializeObject<List<ChucVu>>(responeseData);
                return View(data);
            }
            else
            {
                return NotFound();
            }
        }
    }
}
