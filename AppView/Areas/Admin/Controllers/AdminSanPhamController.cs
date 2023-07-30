using AppData.Models;
using AspNetCoreHero.ToastNotification.Abstractions;
using AspNetCoreHero.ToastNotification.Notyf;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AppView.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class AdminSanPhamController : Controller
    {
        public HttpClient _httpClient;
        private readonly INotyfService _notyf;
        public AdminSanPhamController(INotyfService notyf)
        {
            _notyf =notyf;
            _httpClient= new HttpClient();
        }
        // GET: AdminSanPhamController
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            List<SanPham> products = await _httpClient.GetFromJsonAsync<List<SanPham>>("https://localhost:7284/api/SanPham/GetAll");
            
            return View(products);
        }



        // GET: AdminSanPhamController/Create
 
        public async Task<string> AddImg(IFormFile imageFile)
        {
            if (imageFile != null && imageFile.Length > 0)
            {
                //Trỏ tới thư mục wwwroot để tí copy sang
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", "imgSanPhams", imageFile.FileName);
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
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(SanPham sp, IFormFile imageFile)
        {
            sp.SanPhamId = Guid.NewGuid();
            if (imageFile != null && imageFile.Length > 0) // Không null và không trống
            {
                //Trỏ tới thư mục wwwroot để lát nữa thực hiện việc Copy sang
                sp.Img = await AddImg(imageFile);

            }

            var result = await _httpClient.PostAsJsonAsync<SanPham>("https://localhost:7284/api/SanPham/Post", sp);

            if (result.IsSuccessStatusCode)
            {
                _notyf.Success("Thêm dữ liệu thành công!");
                return RedirectToAction("Index");
            }

            return BadRequest();
        }


        // GET: AdminSanPhamController/Edit/5
        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            SanPham products = await _httpClient.GetFromJsonAsync<SanPham>($"https://localhost:7284/api/SanPham/GetById/{id}");

            return View(products);
        }

        // POST: AdminSanPhamController/Edit/5
        [HttpPost]
        public async Task<IActionResult> Edit(Guid id , SanPham sp , IFormFile imageFile)
        {
            sp.SanPhamId = id;
            if (imageFile != null && imageFile.Length > 0) // Không null và không trống
            {
                //Trỏ tới thư mục wwwroot để lát nữa thực hiện việc Copy sang
                sp.Img = await AddImg(imageFile);

            }

            var result = await _httpClient.PutAsJsonAsync<SanPham>($"https://localhost:7284/api/SanPham/Put/{sp.SanPhamId}", sp);

            if (result.IsSuccessStatusCode)
            {
                _notyf.Success("Bạn đã cập nhật thành công!");
                return RedirectToAction("Index");
            }

            return BadRequest();
        }

        // GET: AdminSanPhamController/Delete/5
        public async Task<IActionResult> Delete(Guid id)
        {

          var x=   await _httpClient.DeleteAsync($"https://localhost:7284/api/SanPham/Delete/{id}");
            if (x.IsSuccessStatusCode)
            {
                _notyf.Success("Xóa thành công");
                return RedirectToAction(nameof(Index));
            }
            _notyf.Error("Lỗi có thể sản phẩm không tồn tại!");
            return View();
        }

        // POST: AdminSanPhamController/Delete/5

    }
}
