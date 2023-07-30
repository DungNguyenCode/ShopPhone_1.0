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
    public class ChucVuServices : IChucVu
    {
        public AppDataConTextDB _dbContext;
        public ChucVuServices()
        {
            _dbContext= new AppDataConTextDB();
        }
        public async Task<bool> Add(ChucVu chucVu)
        {
            if (chucVu != null)
            {
                await _dbContext.ChucVus.AddAsync(chucVu);
                await _dbContext.SaveChangesAsync();
                return true;
            }       
            return false;
        }

        public async Task<bool> Delete(Guid Id)
        {
            var cv = await _dbContext.ChucVus.FirstOrDefaultAsync(c => c.ChucVuId == Id);
            if (cv!=null)
            {
                _dbContext.Remove(cv);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<List<ChucVu>> GetAllChucVu()
        {
            return await _dbContext.ChucVus.ToListAsync();
        }

        public async Task<ChucVu> GetById(Guid Id)
        {
            return await _dbContext.ChucVus.FirstOrDefaultAsync(c => c.ChucVuId == Id);
        }

        public async Task<bool> Update(ChucVu chucVu)
        {
            var cv = await _dbContext.ChucVus.FirstOrDefaultAsync(c => c.ChucVuId == chucVu.ChucVuId);
            if (cv != null)
            {
                cv.TrangThai= chucVu.TrangThai;
                cv.MoTa = chucVu.MoTa;
                cv.TenRole = chucVu.TenRole;
                
                _dbContext.Update(cv);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}
