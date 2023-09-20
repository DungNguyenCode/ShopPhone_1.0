using AppData.Interface;
using AppData.Models;
using AppData.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AppAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GioHangCtController : ControllerBase
    {
        public IGioHangCt _gioHangCt;
        public GioHangCtController()
        {
            _gioHangCt = new GioHangCtServices();
        }
        [HttpGet("GetAll")]
        public async Task<IEnumerable<GioHangCT>> GetAll()
        {
            return await _gioHangCt.GetAllGioHang();
        }

        // GET api/<SanPhamController>/5
        [HttpGet("GetById/{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var listCv = await _gioHangCt.GetById(id);

            if (listCv == null)
            {
                return NotFound();
            }
            return Ok(listCv);
        }


        // POST api/<SanPhamController>
        [HttpPost("Post")]
        public async Task<IActionResult> Post(GioHangCT kh)
        {
            try
            {
                await _gioHangCt.Add(kh);
                return Ok(kh);
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }




        }
        // PUT api/<SanPhamController>/5
        [HttpPut("Put/{id}")]
        public async Task<IActionResult> Put(GioHangCT ghct)
        {
            GioHangCT gioHangct = await _gioHangCt.GetById(ghct.GioHangCtId);
            gioHangct.KhachHangId = ghct.KhachHangId;
            gioHangct.SanPhamid= ghct.SanPhamid;
            gioHangct.NgayTao= ghct.NgayTao;
            gioHangct.SoLuong = ghct.SoLuong;
            gioHangct.TongTien = ghct.TongTien;
            gioHangct.TrangThai = ghct.TrangThai;
            await _gioHangCt.Update(gioHangct);
            if (!await _gioHangCt.Update(gioHangct))
            {
                return BadRequest();
            }
            return Ok(ghct);


        }
        // DELETE api/<SanPhamController>/5
        [HttpDelete("Delete/{id}")]
        public IActionResult Delete(Guid id)
        {

            _gioHangCt.Delete(id);
            return Ok();



        }

    }
}
