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
    public class GioHangCtServices : IGioHangCt
    {
        public AppDataConTextDB _dbContext;
        public GioHangCtServices()
        {
            _dbContext = new AppDataConTextDB();
        }
        public async Task<bool> Add(GioHangCT gioHangCT)
        {
            if (gioHangCT != null)
            {
                await _dbContext.AddAsync(gioHangCT);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<bool> Delete(Guid Id)
        {
            var gh = await _dbContext.GioHangCts.FirstOrDefaultAsync(c => c.GioHangCtId == Id);
            if (gh != null)
            {
                _dbContext.Remove(gh);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<List<GioHangCT>> GetAllGioHang()
        {
           return await _dbContext.GioHangCts.ToListAsync();
        }

        public async Task<GioHangCT> GetById(Guid Id)
        {
            return await _dbContext.GioHangCts.FirstOrDefaultAsync(c => c.GioHangCtId == Id);
        }

        public async Task<bool> Update(GioHangCT gioHangCT)
        {
            var gh = await _dbContext.GioHangCts.FirstOrDefaultAsync(c => c.GioHangCtId == gioHangCT.GioHangCtId);
            if (gh != null)
            {
                gh.TrangThai = gioHangCT.TrangThai;
                gh.SanPhamid = gioHangCT.SanPhamid;
                gh.KhachHangId = gioHangCT.KhachHangId;
                gh.SoLuong = gioHangCT.SoLuong;
                gh.TongTien = gioHangCT.TongTien;
                gh.NgayTao = gioHangCT.NgayTao;
                    
                _dbContext.Update(gh);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}
