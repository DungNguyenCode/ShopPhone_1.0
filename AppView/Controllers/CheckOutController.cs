using AppData.Interface;
using AppData.Models;
using AppView.Extensions;
using AppView.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;

namespace AppView.Controllers
{
    public class CheckOutController : Controller
    {
        private readonly HttpClient _httpClient;
        public CheckOutController()
        {
            _httpClient = new HttpClient();

        }

        [HttpPost]
        // hien thi don hang
        public async Task<IActionResult> ConfirmOrder(DonHangViewModel donHang)
        {
            var idKhachHang = User.FindFirstValue("UserId");
            if (idKhachHang == null)
            {
                return RedirectToAction("Index", "Home", new { area = "Admin" });
            }
            var gioHang = HttpContext.Session.GetObject<List<GioHangViewModel>>("GioHang");
            //Khoi tao don hang
             
            donHang.ngayTao = DateTime.Now;
            donHang.idDonHang = Guid.NewGuid();
            donHang.trangThai = 1;
            donHang.DiaChi = User.FindFirstValue("Address");
            donHang.ten = User.Identity.Name;
            donHang.tenDayDu = User.FindFirstValue("FullName");
            donHang.idKhacHang = Guid.Parse(User.FindFirstValue("UserId"));
            foreach (var item in gioHang)
            {
                donHang.idSanPham = item.IdSanPham;
                donHang.soLuong = item.SoLuong;
                donHang.thanhTien = item.TongTien;
            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            List<DonHang> products = await _httpClient.GetFromJsonAsync<List<DonHang>>("https://localhost:7284/api/DonHang/GetAll");

            return View(products);
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
                return RedirectToAction("Index");
            }
            else
            {
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
            if (response.DonHangId != null)
            {

                return View(response);
            }
            else
            {
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

                return RedirectToAction("Index");
            }
            else
            {

                return View();
            }


        }


        // GET: AdminDonHangController/Delete/5
        public async Task<IActionResult> Delete(Guid id, DonHang donHang)
        {
            donHang.DonHangId = id;
            var result = await _httpClient.DeleteAsync($"https://localhost:7284/api/DonHang/Delete/{donHang.DonHangId}");

            return RedirectToAction("Index");
        }

    }

}
