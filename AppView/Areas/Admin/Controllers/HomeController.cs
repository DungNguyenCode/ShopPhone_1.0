using AppData.Models;
using AppView.Areas.Admin.Models;
using AppView.Areas.Admin.ViewModels;
using AppView.Extensions;
using AppView.ViewModels;
using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using NuGet.Protocol.Plugins;
using System.Security.Claims;
using Utility = AppView.Areas.Admin.Models.Utility;
using Microsoft.AspNetCore.Http;
namespace AppView.Areas.Admin.Controllers
{
    [Area("Admin")]

    [Authorize] // thêm cái này
    public class HomeController : Controller
    {
        private readonly HttpClient _httpClient;
        private INotyfService _notyfService;
        public HomeController(INotyfService notyfi)
        {

            _httpClient = new HttpClient();
            _notyfService = notyfi;
        }
        [AllowAnonymous]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [AllowAnonymous] // cho tất cả truy cập
        public async Task<IActionResult> Login(AdminLogin loginViewModel)
        {
            // Thực hiện kiểm tra thông tin đăng nhập thông qua API
            if (string.IsNullOrEmpty(loginViewModel.Email) || string.IsNullOrEmpty(loginViewModel.Password))
            {
                return RedirectToAction("Login", "Home");
            }
            //mã hóa sang md5
            var md5pass = Utility.GetMd5Hash(loginViewModel.Password);
            var apiUrl = "https://localhost:7284/api/KhachHang/GetAll";
            var response = await _httpClient.GetAsync(apiUrl);


            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var data = JsonConvert.DeserializeObject<List<KhachHang>>(jsonData);
                var kh = data.FirstOrDefault(c => c.Email == loginViewModel.Email && c.MatKhau == md5pass && c.TrangThai == 1);

                if (kh != null)

                {                  
                    // Đăng nhập thành công
                    // Tao identity chứa thông tin người dùng

                    var identity = new ClaimsIdentity(new[]
                    {
                        new Claim(ClaimTypes.Name,kh.Ten),
                        new Claim(ClaimTypes.Email,kh.Email),
                        new Claim("UserId",kh.KhachHangId.ToString()),
                        new Claim("UrlImg",kh.AnhDaiDien),
                        new Claim("Address",kh.DiaChi),
                        new Claim("FullName",kh.TenDayDu),
                        new Claim("PhoneNumber",kh.SoDienThoai)
                    }, "login");
                    if (kh.ChucVuId == Guid.Parse("9A1EF277-1E03-432F-329B-08DB7E087723"))
                    {
                        identity.AddClaim(new Claim(ClaimTypes.Role, "Admin"));
                    }
                    else
                    {
                        identity.AddClaim(new Claim(ClaimTypes.Role, "KhachHang"));
                        var principall = new ClaimsPrincipal(identity);
                        var loginn = HttpContext.SignInAsync(principall);
                        _notyfService.Success($"Đăng nhập thành công! ,Chào mừng{kh.Ten}");
                        return Redirect("~/Home/Index");
                    }
                    //tạo claim prinipal
                    var principal = new ClaimsPrincipal(identity);
                    var login = HttpContext.SignInAsync(principal);
                    _notyfService.Success($"Đăng nhập thành công! ,Chào mừng{kh.Ten}");
                    return Redirect("~/Admin/Home/Index");

                }
                else
                {
                    ViewBag.Error = "Đăng nhập không thành công!";
                    return View();
                }

            }
            return View();
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        [AllowAnonymous]
        public IActionResult LogOut()
        {
            var login = HttpContext.SignOutAsync();
            return RedirectToAction("Login");
        }
        public IActionResult Register()
        {
            return View();
        }

    }
}
