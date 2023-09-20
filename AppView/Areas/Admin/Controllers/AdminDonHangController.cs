using AppData.Interface;
using AppData.Models;
using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace AppView.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class AdminDonHangController : Controller
    {
        private readonly HttpClient _httpClient;
        private readonly INotyfService _notyf;
        public AdminDonHangController(INotyfService notyf)
        {
            _httpClient = new HttpClient();
            _notyf = notyf;
        }
        // GET: AdminDonHangController
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var apiUrl = "https://localhost:7284/api/DonHang/GetAll";
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

        // GET: AdminDonHangController/Details/5
        [HttpPost]
        public async Task<IActionResult> Create(DonHang donHang)
        {
            var apiUrl = "https://localhost:7284/api/DonHang/Post";
            var jsonData = JsonConvert.SerializeObject(donHang);

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

        // GET: AdminDonHangController/Create
        public ActionResult Create()
        {
            return View();
        }

        // GET: AdminDonHangController/Edit/5
        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            DonHang response = await _httpClient.GetFromJsonAsync<DonHang>($"https://localhost:7284/api/DonHang/GetById/{id}");
            if (response.DonHangId != Guid.Empty)
            {

                return View(response);
            }
            else
            {
                _notyf.Error("Lỗi!");
                return View();
            }

        }
        [HttpPost]
        public async Task<IActionResult> Edit(Guid id, DonHang donHang)
        {
            donHang.DonHangId = id; // Gán giá trị ChucVuId từ tham số id vào đối tượng cv
            var result = await _httpClient.PutAsJsonAsync<DonHang>($"https://localhost:7284/api/DonHang/Put/{donHang.DonHangId}", donHang);
            if (result.IsSuccessStatusCode)
            {
                _notyf.Success("Cập nhật đơn hàng thành công!");
                return RedirectToAction("Index");
            }
            else
            {
                _notyf.Error(result.StatusCode.ToString());
                return View();
            }
           

        }


        // GET: AdminDonHangController/Delete/5
        public async Task<IActionResult> Delete(Guid id, DonHang donHang)
        {
            donHang.DonHangId = id;
            var result = await _httpClient.DeleteAsync($"https://localhost:7284/api/DonHang/Delete/{donHang.DonHangId}");
            _notyf.Success("Xóa đơn hàng thành công!");
            return RedirectToAction("Index");
        }

    }
}
