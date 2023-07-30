using AppData.Models;
using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace AppView.Controllers
{
    public class SanPhamController : Controller
    {
        public HttpClient _httpClient;
        private readonly INotyfService _notyf;
        public SanPhamController(INotyfService notyf)
        {
            _notyf = notyf;
            _httpClient = new HttpClient();
        }
        // GET: SanPhamController
        [HttpGet]
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

        // GET: SanPhamController/Details/5
        [HttpGet]

        public async Task<IActionResult> Details(Guid id)
        {
            SanPham products = await _httpClient.GetFromJsonAsync<SanPham>($"https://localhost:7284/api/SanPham/GetById/{id}");

            return View(products);
        }

        // GET: SanPhamController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SanPhamController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: SanPhamController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: SanPhamController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: SanPhamController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: SanPhamController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
