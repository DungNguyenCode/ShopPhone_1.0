using AppData.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using AspNetCoreHero.ToastNotification.Abstractions;
using AppView.Areas.Admin.Models;
using Microsoft.AspNetCore.Authorization;

namespace AppView.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class AdminKhachHangController : Controller
    {

        private readonly HttpClient _httpClient;
        private readonly INotyfService _notyf;

        public AdminKhachHangController(INotyfService notyf)
        {
            _notyf = notyf;
            _httpClient = new HttpClient();
        }

        // GET: KhachHangController

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var apiUrl = "https://localhost:7284/api/KhachHang/GetAll";
            var response = await _httpClient.GetAsync(apiUrl);

            if (response.IsSuccessStatusCode)
            {
                var responseData = await response.Content.ReadAsStringAsync();
                var khachHangList = JsonConvert.DeserializeObject<List<KhachHang>>(responseData);


                return View(khachHangList);
            }
            else
            {
                _notyf.Error("Lỗi không thể tải dữ liệu!");
                return View();
            }
        }
        [HttpGet]
        public  List<ChucVu> GetChucVu()
        {
            // code của anh Khoa khó hiểu vcl
            string requestURL =
             $"https://localhost:7284/api/ChucVu/GetAll";
            var httpClient = new HttpClient(); // Tại 1 httpClient để call API
            var response = httpClient.GetAsync(requestURL).Result; // Lấy kết quả                                                                 // Đọc ra string Json
            string apiData = response.Content.ReadAsStringAsync().Result;
            // Lấy kết quả thu được bằng cách bóc dữ liệu Json
            var result = JsonConvert.DeserializeObject<List<ChucVu>>(apiData);
            return result;

        }

        public async Task<string> AddImg(IFormFile imageFile)
        {
            if (imageFile != null && imageFile.Length > 0)
            {
                //Trỏ tới thư mục wwwroot để tí copy sang
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", imageFile.FileName);
                using (var stream = new FileStream(path, FileMode.Create))
                {
                    //Thực hiện copy ảnh sang thư mục mới wwwroot
                    await imageFile.CopyToAsync(stream);
                }
            }

            return imageFile.FileName;
        }
        public IActionResult Create()
        {
            ViewBag.Roles = GetChucVu();
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(KhachHang kh, IFormFile imageFile)

        {
            ViewBag.Roles = GetChucVu();
            kh.KhachHangId = Guid.NewGuid();
            // mã hóa mật khẩu sang md5

            if (imageFile != null && imageFile.Length > 0) // Không null và không trống
            {
                var md5pass = Utility.GetMd5Hash(kh.MatKhau);
                //Trỏ tới thư mục wwwroot để lát nữa thực hiện việc Copy sang
                kh.AnhDaiDien = await AddImg(imageFile);
                kh.MatKhau = md5pass;

            }

            var result = await _httpClient.PostAsJsonAsync<KhachHang>("https://localhost:7284/api/KhachHang/Post", kh);

            if (result.IsSuccessStatusCode)
            {
                _notyf.Success("Thêm tài khoàn thành công!");
                return RedirectToAction("Index");
            }
            _notyf.Error(result.StatusCode.ToString());
            return View();

        }


        // GET: KhachHangController/Details/5
        [HttpGet]
        public async Task<IActionResult> Details(Guid id)
        {
            KhachHang response = await _httpClient.GetFromJsonAsync<KhachHang>($"https://localhost:7284/api/KhachHang/GetById/{id}");
            return View(response);
        }



        // GET: KhachHangController/Edit/5
        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            ViewBag.Roles = GetChucVu();
            KhachHang response = await _httpClient.GetFromJsonAsync<KhachHang>($"https://localhost:7284/api/KhachHang/GetById/{id}");
            return View(response);
        }

        // POST: KhachHangController/Edit/5
        [HttpPost]

        public async Task<IActionResult> Edit(Guid id, KhachHang kh, IFormFile imageFile)
        {
            ViewBag.Roles = GetChucVu();
            kh.KhachHangId = id;
            string md5pass = Utility.GetMd5Hash(kh.MatKhau);
            if (imageFile != null && imageFile.Length > 0) // Không null và không trống
            {
                //Trỏ tới thư mục wwwroot để lát nữa thực hiện việc Copy sang
                kh.AnhDaiDien = await AddImg(imageFile);
                kh.MatKhau = md5pass;
            }

            var result = await _httpClient.PutAsJsonAsync<KhachHang>($"https://localhost:7284/api/KhachHang/Put/{kh.KhachHangId}", kh);
            if (result.IsSuccessStatusCode)
            {
                _notyf.Success("Sửa thành công!");
                return RedirectToAction("Index");
            }
            _notyf.Error(result.StatusCode.ToString());
            return View();

        }

        // GET: KhachHangController/Delete/5
        public async Task<IActionResult> Delete(Guid id, KhachHang kh)
        {
            kh.KhachHangId = id;
            var result = await _httpClient.DeleteAsync($"https://localhost:7284/api/KhachHang/Delete/{kh.KhachHangId}");
            if (result.IsSuccessStatusCode)
            {
                _notyf.Success("Xóa thành công!");
                return RedirectToAction("Index");
            }
            _notyf.Error(result.StatusCode.ToString());
            return View();
        }

    }
}
