using AppData.Models;
using AppView.Areas.Admin.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Data;
using System.Net.Http;
using System.Text;

namespace AppView.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class AdminChucVuController : Controller
    {
        public HttpClient _httpClient;

        public AdminChucVuController()
        {
            _httpClient = new HttpClient();

        }
        // GET: AdminChucVuController
        [HttpGet]
        public async Task<IActionResult> Index()
        {

            var apiUrl = "https://localhost:7284/api/ChucVu/GetAll";
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


        // GET: AdminChucVuController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: AdminChucVuController/Create

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ChucVu cv)
        {
            var apiUrl = "https://localhost:7284/api/ChucVu/Post";
            var jsonData = JsonConvert.SerializeObject(cv);

            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

            var responese = await _httpClient.PostAsync(apiUrl, content);
            if (responese.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return NotFound();
        }

        // GET: AdminChucVuController/Edit/5

        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            ChucVu response = await _httpClient.GetFromJsonAsync<ChucVu>($"https://localhost:7284/api/ChucVu/GetById/{id}");
            return View(response);
        }

        // POST: AdminChucVuController/Edit/5
        [HttpPost]
        public async Task<IActionResult> Edit(Guid id, ChucVu cv)
        {
            cv.ChucVuId = id; // Gán giá trị ChucVuId từ tham số id vào đối tượng cv
            var result = await _httpClient.PutAsJsonAsync<ChucVu>($"https://localhost:7284/api/ChucVu/Put/{cv.ChucVuId}", cv);
            if (result.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return BadRequest();

        }



        // GET: AdminChucVuController/Delete/5
        public async Task<IActionResult> Delete(Guid id, ChucVu cv)
        {
            cv.ChucVuId = id;
            var result = await _httpClient.DeleteAsync($"https://localhost:7284/api/ChucVu/Delete/{cv.ChucVuId}");
            return RedirectToAction("Index");
        }



    }
}
