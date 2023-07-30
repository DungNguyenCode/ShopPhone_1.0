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
    public class KhachHangServices : IKhachHang
    {
        public  AppDataConTextDB _dbContext;
        public  KhachHangServices()
        {
            _dbContext= new AppDataConTextDB();
        }
        public async Task<bool> Add(KhachHang khachHang)
        {
            if (khachHang != null)
            {
                await _dbContext.KhachHangs.AddAsync(khachHang);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<bool> Delete(Guid Id)
        {
            var kh = await _dbContext.KhachHangs.FirstOrDefaultAsync(c => c.KhachHangId == Id);
            if (kh!=null)
            {
                _dbContext.KhachHangs.Remove(kh);
                await _dbContext.SaveChangesAsync() ;
                return true;
            }
            return false;
        }

        public async Task<List<KhachHang>> GetAllKhachHang()
        {
           return await _dbContext.KhachHangs.ToListAsync();
        }

        public async Task<KhachHang> GetById(Guid Id)
        {
            return await _dbContext.KhachHangs.FirstOrDefaultAsync(c => c.KhachHangId == Id);
        }

        public async Task<bool> Update(KhachHang khachHang)
        {
            var kh = await _dbContext.KhachHangs.FirstOrDefaultAsync(c => c.KhachHangId == khachHang.KhachHangId);
            if (kh != null)
            {
                kh.TenDayDu = khachHang.TenDayDu;
                kh.AnhDaiDien = khachHang.AnhDaiDien;
                kh.Ten = khachHang.Ten;
                kh.Email =khachHang.Email;
                kh.DiaChi = khachHang.DiaChi;
                kh.TrangThai= khachHang.TrangThai;
                kh.MatKhau = khachHang.MatKhau;
                kh.SoDienThoai = khachHang.SoDienThoai;
                kh.VaiTro = khachHang.VaiTro;
                kh.ChucVuId= khachHang.ChucVuId;
                _dbContext.KhachHangs.Update(kh);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}
