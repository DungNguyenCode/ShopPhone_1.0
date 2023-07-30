using AppData.Interface;
using AppData.Models;
using AppData.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AppAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SanPhamController : ControllerBase
    {
        public ISanPham _sanPhamServics;
        public SanPhamController()
        {
            _sanPhamServics = new SanPhamServies();
        }
        // GET: api/<SanPhamController>
        [HttpGet("GetAll")]
        public async Task<IEnumerable<SanPham>> GetAll()
        {
            return await _sanPhamServics.GetAllSanPham();
        }

        // GET api/<SanPhamController>/5
        [HttpGet("GetById/{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var listSanPham = await _sanPhamServics.GetById(id);

            if (listSanPham == null)
            {
                return NotFound();
            }
            return Ok(listSanPham);
        }


        // POST api/<SanPhamController>
        [HttpPost("Post")]
        public async Task<IActionResult> Post(SanPham sp)
        {
            try
            {
                await _sanPhamServics.Add(sp);
                return Ok();
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }




        }
        // PUT api/<SanPhamController>/5
        [HttpPut("Put/{id}")]
        public async Task<IActionResult> Put(SanPham sp)
        {
            SanPham sanPham = await _sanPhamServics.GetById(sp.SanPhamId);
            sanPham.SoLuong = sp.SoLuong;
            sanPham.Img = sp.Img;
            sanPham.NhaCungCap = sp.NhaCungCap;
            sanPham.MauSac = sp.MauSac;
            sanPham.Gia = sp.Gia;
            sanPham.Mota = sp.Mota;
            sanPham.SoLuongTon = sp.SoLuongTon;
            sanPham.Ten = sp.Ten;
            sanPham.TrangThai = sp.TrangThai;
            await _sanPhamServics.Update(sp);
            if (!await _sanPhamServics.Update(sp))
            {
                return BadRequest();
            }
            return Ok();


        }
        // DELETE api/<SanPhamController>/5
        [HttpDelete("Delete/{id}")]
        public IActionResult Delete(Guid id)
        {

             _sanPhamServics.Delete(id);
            return Ok();



        }
    }
}
