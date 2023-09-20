using AppData.Models;
using AppView.Extensions;
using AppView.ViewModels;
using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;

namespace AppView.Controllers
{
    public class GioHangController : Controller
    {
        private readonly INotyfService _notyf;
        public readonly HttpClient _httpClient;
        public GioHangController(ILogger<HomeController> logger, INotyfService notyf)

        {

            _notyf = notyf;
            _httpClient = new HttpClient();
        }
        public void GetUser()
        {
            string cookieValue = Request.Cookies["CookieCuaDung"];// Lấy giá trị của cookie có tên "CookieCuaDung" 

            if (!string.IsNullOrEmpty(cookieValue)) // Kiểm tra xem cookieValue có rỗng hoặc null không ?
            {
                // Get the ClaimsPrincipal from the cookie
                var principal = HttpContext.User;//Lấy ClaimsPrincipal từ đối tượng HttpContext.User để truy cập thông tin người dùng đăng nhập.

                if (principal != null && principal.Identity.IsAuthenticated && principal.IsInRole("KhachHang"))
                {
                    ViewBag.UserId = Guid.Parse(principal.FindFirst("UserId").Value);
                    ViewBag.Name = principal.FindFirst("Name").Value;
                }
            }
        }

        public List<GioHangViewModel> GioHang
        {
            get
            {
                var gh = HttpContext.Session.GetObject<List<GioHangViewModel>>("GioHang");
                if (gh == default(List<GioHangViewModel>)) // giá trị mặc định == null
                {
                    gh = new List<GioHangViewModel>();
                }
                return gh;
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddToCart(Guid idSanPham, int? soLuong)
        {
            List<GioHangViewModel> gioHangs = GioHang; // lưu ý doạn này
            var item = gioHangs.SingleOrDefault(c => c.sanPham.SanPhamId == idSanPham);

            if (item != null)
            {
                // Sản phẩm đã có trong giỏ hàng, cộng dồn số lượng mới
                if (soLuong.HasValue && soLuong.Value > 0)
                {
                    item.SoLuong += soLuong.Value;
                }
            }
            else
            {
                var UrlApi = $"https://localhost:7284/api/SanPham/GetAll";
                var response = await _httpClient.GetAsync(UrlApi);

                if (response.IsSuccessStatusCode)
                {
                    var responeseData = await response.Content.ReadAsStringAsync();
                    var data = JsonConvert.DeserializeObject<List<SanPham>>(responeseData);
                    SanPham sp = data.SingleOrDefault(c => c.SanPhamId == idSanPham);
                    if (sp != null)
                    {
                        item = new GioHangViewModel
                        {
                            SoLuong = soLuong.HasValue ? soLuong.Value : 1,
                            IdSanPham = idSanPham,
                            sanPham = sp,
                            TenSp = sp.Ten,
                            Gia = sp.Gia,
                            
                        };
                        // thêm mới sản phẩm vào giỏ hàng vì sản phẩm chưa tồn tại trong danh sách
                        gioHangs.Add(item);
                    }
                }
            }

            HttpContext.Session.SetObject("GioHang", gioHangs); // lưu vào session

            return Json(new { succes = false });
        }




        public IActionResult Delete(Guid idSanPham) // cái này chạy được :))
        {
            List<GioHangViewModel> gioHangs = GioHang;
            var item = gioHangs.SingleOrDefault(c => c.sanPham.SanPhamId == idSanPham);

            if (item != null)
            {
                gioHangs.Remove(item); // Xóa phần tử khỏi danh sách
                HttpContext.Session.SetObject("GioHang", gioHangs); // Lưu lại danh sách vào Session
                _notyf.Success($"Đã xóa {item.sanPham.Ten} khỏi giỏ hàng");
            }

            return RedirectToAction("Index");
        }
        public IActionResult UpdateCart(Guid idSanPham, int? soLuong)
        {
            // lấy giỏ hàng ra để sử lý
            var gioHang = HttpContext.Session.GetObject<List<GioHangViewModel>>("GioHang");
            if (gioHang != null)
            {
                var item = gioHang.SingleOrDefault(c => c.sanPham.SanPhamId == idSanPham);
                if (item != null && soLuong.HasValue)
                {
                    item.SoLuong = soLuong.Value;
                }
                HttpContext.Session.SetObject("GioHang", gioHang);
            }
            return RedirectToAction("Index");
        }
        public IActionResult Index()
        {

            return View(GioHang);
        }
    }
}
