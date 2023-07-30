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
    public class DonHangServices : IDonHang
    {
        public AppDataConTextDB _dbContext;
        public DonHangServices()
        {
            _dbContext = new AppDataConTextDB();
        }
        public async Task<List<DonHang>> GetAllDonHang()
        {
            return await _dbContext.DonHangs.ToListAsync();
        }

        public async Task<DonHang> GetById(Guid Id)
        {
            return await _dbContext.DonHangs.FirstOrDefaultAsync(c => c.DonHangId == Id);
        }
        public async Task<bool> Add(DonHang donHang)
        {
            if (donHang != null)
            {
                await _dbContext.AddAsync(donHang);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            return false;
        }
        public async Task<bool> Update(DonHang donHang)
        {
            var dh = await _dbContext.DonHangs.FirstOrDefaultAsync(c => c.DonHangId == donHang.DonHangId);
            if (dh != null)
            {
                dh.TenKhachHang = donHang.TenKhachHang;
                dh.TrangThai = donHang.TrangThai;
                dh.NgayTao = donHang.NgayTao;
                dh.DiaChi = donHang.DiaChi;
                dh.KhachHangId = donHang.KhachHangId;
                dh.Ten = donHang.Ten;
                _dbContext.DonHangs.Update(dh);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            return false;
        }
        public async Task<bool> Delete(Guid id)
        {
            var dh = await _dbContext.DonHangs.FirstOrDefaultAsync(c => c.DonHangId == id);
            if (dh != null)
            {
                _dbContext.DonHangs.Remove(dh);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}
