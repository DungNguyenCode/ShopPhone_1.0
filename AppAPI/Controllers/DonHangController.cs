using AppData.Interface;
using AppData.Models;
using AppData.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AppAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DonHangController : ControllerBase
    {
        public IDonHang _donHangService;
        public DonHangController()
        {
            _donHangService = new DonHangServices();

        }
        [HttpGet("GetAll")]
        public async Task<IEnumerable<DonHang>> GetAll()
        {
            return await _donHangService.GetAllDonHang();
        }

        // GET api/<SanPhamController>/5
        [HttpGet("GetById/{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var listCv = await _donHangService.GetById(id);

            if (listCv == null)
            {
                return NotFound();
            }
            return Ok(listCv);
        }
        [HttpPost("Post")]
        public async Task<IActionResult> Post(DonHang donHang)
        {
            try
            {
                await _donHangService.Add(donHang);
                return Ok(donHang);
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }

        }
        [HttpPut("Put/{id}")]
        public async Task<IActionResult> Put(DonHang donHang)
        {
            try
            {
                DonHang dh = await _donHangService.GetById(donHang.DonHangId);
                dh.Ten = donHang.Ten;
                dh.DiaChi = donHang.DiaChi;
                dh.NgayTao = donHang.NgayTao;
                dh.TenKhachHang = donHang.TenKhachHang;
                dh.TrangThai = donHang.TrangThai;
                dh.KhachHangId = donHang.KhachHangId;
                await _donHangService.Update(dh);
                return Ok(dh);

            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }

        }
        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
;
                await _donHangService.Delete(id);
                return Ok();
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }
    }
}
