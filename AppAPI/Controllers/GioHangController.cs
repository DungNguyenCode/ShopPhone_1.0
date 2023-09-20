using AppData.Interface;
using AppData.Models;
using AppData.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AppAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GioHangController : ControllerBase
    {
        public IGioHang _gioHangServie;
        public GioHangController()
        {
            _gioHangServie = new GioHangServices();
        }
        [HttpGet("GetAll")]
        public async Task<IEnumerable<GioHang>> GetAll()
        {
            return await _gioHangServie.GetAllGioHang();
        }

        // GET api/<SanPhamController>/5
        [HttpGet("GetById/{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var listCv = await _gioHangServie.GetById(id);

            if (listCv == null)
            {
                return NotFound();
            }
            return Ok(listCv);
        }
        // POST api/<SanPhamController>
        [HttpPost("Post")]
        public async Task<IActionResult> Post(GioHang kh)
        {
            try
            {
                await _gioHangServie.Add(kh);
                return Ok(kh);
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }




        }
        // PUT api/<SanPhamController>/5
        [HttpPut("Put/{id}")]
        public async Task<IActionResult> Put(GioHang giohang)
        {
            GioHang gh = await _gioHangServie.GetById(giohang.KhachHangId);
            gh.KhachHangId = giohang.KhachHangId;
            gh.MoTa = giohang.MoTa;
            gh.TenKhachHang = giohang.TenKhachHang;
            gh.DiaChi = giohang.DiaChi;
            gh.Email = giohang.Email;

            await _gioHangServie.Update(gh);
            if (!await _gioHangServie.Update(gh))
            {
                return BadRequest();
            }
            return Ok(giohang);


        }
        // DELETE api/<SanPhamController>/5
        [HttpDelete("Delete/{id}")]
        public IActionResult Delete(Guid id)
        {

            _gioHangServie.Delete(id);
            return Ok();



        }
    }
}
