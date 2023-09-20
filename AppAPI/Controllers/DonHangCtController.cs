using AppData.Interface;
using AppData.Models;
using AppData.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AppAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DonHangCtController : ControllerBase
    {
        public IDonHangCt _donHangCtServices;
        public DonHangCtController()
        {
            _donHangCtServices = new DonHangCtServices();
        }
        [HttpGet("GetAll")]
        public async Task<IEnumerable<DonHangCT>> GetAll()
        {
            return await _donHangCtServices.GetAllDonHang();
        }

        // GET api/<SanPhamController>/5
        [HttpGet("GetById/{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var listCv = await _donHangCtServices.GetById(id);

            if (listCv == null)
            {
                return NotFound();
            }
            return Ok(listCv);
        }


        // POST api/<SanPhamController>
        [HttpPost("Post")]
        public async Task<IActionResult> Post(DonHangCT DonHangCT)
        {
            try
            {
                await _donHangCtServices.Add(DonHangCT);
                return Ok(DonHangCT);
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }




        }
        // PUT api/<SanPhamController>/5
        [HttpPut("Put/{id}")]
        public async Task<IActionResult> Put(DonHangCT dhct)
        {
            DonHangCT donHang = await _donHangCtServices.GetById(dhct.DonHangCtId);
            donHang.SoLuong = dhct.SoLuong;
            donHang.DonHangId = dhct.DonHangId;
            donHang.IdSanPham = dhct.IdSanPham;

            await _donHangCtServices.Update(donHang);
            if (!await _donHangCtServices.Update(donHang))
            {
                return BadRequest();
            }
            return Ok(dhct);


        }
        // DELETE api/<SanPhamController>/5
        [HttpDelete("Delete/{id}")]
        public IActionResult Delete(Guid id)
        {

            _donHangCtServices.Delete(id);
            return Ok();



        }
    }
}
