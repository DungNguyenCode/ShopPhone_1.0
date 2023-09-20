
using AppData.Interface;
using AppData.Models;
using AppData.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AppAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KhachHangController : ControllerBase
    {
        public IKhachHang _khServices;

        public KhachHangController()
        {
            _khServices = new KhachHangServices();
        }
        [HttpGet("GetAll")]
        public async Task<IEnumerable<KhachHang>> GetAll()
        {
            return await _khServices.GetAllKhachHang();
        }

        // GET api/<SanPhamController>/5
        [HttpGet("GetById/{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var listCv = await _khServices.GetById(id);

            if (listCv == null)
            {
                return NotFound();
            }
            return Ok(listCv);
        }


        // POST api/<SanPhamController>
        [HttpPost("Post")]
        public async Task<IActionResult> Post(KhachHang kh)
        {
            try
            {

                await _khServices.Add(kh);
                return Ok(kh);
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }




        }
        // PUT api/<SanPhamController>/5
        [HttpPut("Put/{id}")]
        public async Task<IActionResult> Put(KhachHang kh)
        {
           
            KhachHang khach = await _khServices.GetById(kh.KhachHangId);
            khach.TenDayDu = kh.TenDayDu;
            khach.Ten = kh.Ten;
            khach.AnhDaiDien = kh.AnhDaiDien;
            khach.DiaChi = kh.DiaChi;
            khach.MatKhau =kh.MatKhau;
            khach.Email = kh.Email;
            khach.TrangThai = kh.TrangThai;
            khach.VaiTro = kh.VaiTro;
            khach.SoDienThoai = kh.SoDienThoai;
            khach.ChucVuId = kh.ChucVuId;
            await _khServices.Update(khach);
            if (!await _khServices.Update(khach))
            {
                return BadRequest();
            }
            return Ok(kh);


        }
        // DELETE api/<SanPhamController>/5
        [HttpDelete("Delete/{id}")]
        public IActionResult Delete(Guid id)
        {

            _khServices.Delete(id);
            return Ok();



        }
    }
}
