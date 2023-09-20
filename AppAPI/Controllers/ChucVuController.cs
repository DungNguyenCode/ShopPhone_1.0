using AppData.Interface;
using AppData.Models;
using AppData.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AppAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChucVuController : ControllerBase
    {
        public IChucVu _chucVuService;
        public ChucVuController()
        {
            _chucVuService = new ChucVuServices();
        }
        [HttpGet("GetAll")]
        public async Task<IEnumerable<ChucVu>> GetAll()
        {
            return await _chucVuService.GetAllChucVu();
        }

        // GET api/<SanPhamController>/5
        [HttpGet("GetById/{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var listCv = await _chucVuService.GetById(id);

            if (listCv == null)
            {
                return NotFound();
            }
            return Ok(listCv);
        }


        // POST api/<SanPhamController>
        [HttpPost("Post")]
        public async Task<IActionResult> Post( ChucVu chucVu)
        {
            try
            {
                await _chucVuService.Add(chucVu);
                return Ok(chucVu);
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }




        }
        // PUT api/<SanPhamController>/5
        [HttpPut("Put/{id}")]
        public async Task<IActionResult> Put(ChucVu chucVu)
        {
            ChucVu cv = await _chucVuService.GetById(chucVu.ChucVuId);
            cv.TenRole = chucVu.TenRole;
            cv.MoTa = chucVu.MoTa;
            cv.TrangThai = chucVu.TrangThai;

            if (!await _chucVuService.Update(cv))
            {
                return BadRequest();
            }
            return Ok(chucVu);

            //return await _chucVuService.Update(chucVu);

        }
        // DELETE api/<SanPhamController>/5
        [HttpDelete("Delete/{id}")]
        public IActionResult Delete(Guid id)
        {

            _chucVuService.Delete(id);
            return Ok();



        }
    }
}
