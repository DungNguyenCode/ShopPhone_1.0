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
    public class SanPhamServies : ISanPham
    {
        public  AppDataConTextDB _dbContext;
        public SanPhamServies()
        {
            _dbContext = new AppDataConTextDB();
        }
        public async Task<bool> Add(SanPham sanPham)
        {
            if (sanPham != null)
            {
                await _dbContext.SanPhams.AddAsync(sanPham);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<bool> Delete(Guid Id)
        {
            var sp = await _dbContext.SanPhams.FirstOrDefaultAsync(c => c.SanPhamId == Id);
            if (sp != null)
            {
                _dbContext.SanPhams.Remove(sp);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<List<SanPham>> GetAllSanPham()
        {
            return await _dbContext.SanPhams.ToListAsync();
        }

        public async Task<SanPham> GetById(Guid Id)
        {

            return await _dbContext.SanPhams.FirstOrDefaultAsync(c => c.SanPhamId == Id);
        }

        public async Task<bool> Update(SanPham sanPham)
        {
            var sp = await _dbContext.SanPhams.FirstOrDefaultAsync(c => c.SanPhamId == sanPham.SanPhamId);
            if (sp != null)
            {
                sp.TrangThai = sanPham.TrangThai;
                sp.MauSac = sanPham.MauSac;
                sp.Ten = sanPham.Ten;
                sp.TrangThai = sanPham.TrangThai;
                sp.SoLuong = sanPham.SoLuong;
                sp.SoLuongTon = sanPham.SoLuongTon;
                sp.NhaCungCap = sanPham.NhaCungCap;
                sp.Img = sanPham.Img;
                sp.Mota = sanPham.Mota;
                _dbContext.SanPhams.Update(sp);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}

