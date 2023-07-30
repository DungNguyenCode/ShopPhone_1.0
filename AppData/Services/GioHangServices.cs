using AppData.Interface;
using AppData.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace AppData.Services
{
    public class GioHangServices : IGioHang
    {
        public AppDataConTextDB _dbContext;
        public GioHangServices()
        {
            _dbContext = new AppDataConTextDB();
        }

        public async Task<bool> Add(GioHang gioHang)
        {
            if (gioHang != null)
            {
                await _dbContext.AddAsync(gioHang);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<bool> Delete(Guid id)
        {
            GioHang gioHang = await _dbContext.GioHangs.FirstOrDefaultAsync(c => c.KhachHangId == id);
            if (gioHang != null)
            {

                _dbContext.Remove(gioHang);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<List<GioHang>> GetAllGioHang()
        {
            return await _dbContext.GioHangs.ToListAsync();
        }

        public async Task<GioHang> GetById(Guid Id)
        {
            return await _dbContext.GioHangs.FirstOrDefaultAsync(c => c.KhachHangId == Id);
        }

        public async Task<bool> Update(GioHang gioHang)
        {
            GioHang gh = await _dbContext.GioHangs.FirstOrDefaultAsync(c => c.KhachHangId == gioHang.KhachHangId);
            if (gh != null)
            {
                gh.KhachHangId = gioHang.KhachHangId;
                gh.MoTa = gh.MoTa;
                gh.TenKhachHang = gioHang.TenKhachHang;
                gh.DiaChi = gioHang.DiaChi;
                gh.Email = gioHang.Email;
                _dbContext.Update(gh);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}
