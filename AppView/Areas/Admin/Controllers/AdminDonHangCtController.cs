using AppData.Interface;
using AppData.Models;
using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Data;
using System.Text;

namespace AppView.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class AdminDonHangCtController : Controller
    {
        private readonly HttpClient _httpClient;
        private readonly INotyfService _notyf;
        public AdminDonHangCtController(INotyfService notyf)
        {
            _httpClient = new HttpClient();
        }
        // GET: AdminDonHangCtController
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var apiUrl = "https://localhost:7284/api/DonHangCt/GetAll";
            var response = await _httpClient.GetAsync(apiUrl);
            if (response.IsSuccessStatusCode)
            {
                var responseData = await response.Content.ReadAsStringAsync();
                var donHangs = JsonConvert.DeserializeObject<List<DonHang>>(responseData);


                return View(donHangs);
            }
            else
            {
                _notyf.Error("Lỗi không thể tải dữ liệu!");
                return View();
            }
        }

        // GET: AdminDonHangCtController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: AdminDonHangCtController/Create
        [HttpPost]
        public async Task<IActionResult> Create(DonHangCT donHangCT)
        {
            var apiUrl = "https://localhost:7284/api/DonHangCt/Post";
            var jsonData = JsonConvert.SerializeObject(donHangCT);

            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

            var responese = await _httpClient.PostAsync(apiUrl, content);
            if (responese.IsSuccessStatusCode)
            {
                _notyf.Success("Thêm đơn hàng thành công");
                return RedirectToAction("Index");
            }
            else
            {
                _notyf.Error(responese.StatusCode.ToString());
                return View();
            }
        }

        // POST: AdminDonHangCtController/Create
        [HttpPost]


        // GET: AdminDonHangCtController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: AdminDonHangCtController/Edit/5
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

        // GET: AdminDonHangCtController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

      
    }
}
