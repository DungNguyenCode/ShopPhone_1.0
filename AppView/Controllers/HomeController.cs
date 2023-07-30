using AppData.Models;
using AppView.Models;
using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Net.Http;

namespace AppView.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly INotyfService _notyf;
        private readonly HttpClient _httpClient;
        public HomeController(ILogger<HomeController> logger,INotyfService notyf)

        {
            _logger = logger;
            _notyf = notyf; 
            _httpClient = new HttpClient();
        }

        public async Task<IActionResult> Index()
        {
            var apiUrl = "https://localhost:7284/api/SanPham/GetAll";
            var response = await _httpClient.GetAsync(apiUrl);


            if (response.IsSuccessStatusCode)
            {
                var responeseData = await response.Content.ReadAsStringAsync();
                var data = JsonConvert.DeserializeObject<List<SanPham>>(responeseData);
                return View(data);
            }
            else
            {
                _notyf.Error("Lỗi:((");
                return View();
            }
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}