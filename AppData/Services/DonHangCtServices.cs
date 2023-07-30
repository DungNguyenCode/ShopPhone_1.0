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
    public class DonHangCtServices : IDonHangCt
    {
        public AppDataConTextDB _dbContext;
        public DonHangCtServices()
        {
            _dbContext = new AppDataConTextDB();
        }
        public async Task<bool> Add(DonHangCT donHang)
        {
            if (donHang != null)
            {
                await _dbContext.DonHangCts.AddAsync(donHang);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<bool> Delete(Guid Id)
        {
            var dh = await _dbContext.DonHangCts.FirstOrDefaultAsync(c => c.DonHangCtId == Id);
            if (dh != null)
            {
                _dbContext.DonHangCts.Remove(dh);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<List<DonHangCT>> GetAllDonHang()
        {
            return await _dbContext.DonHangCts.ToListAsync();

        }

        public async Task<DonHangCT> GetById(Guid Id)
        {
            return await _dbContext.DonHangCts.FirstOrDefaultAsync(c => c.DonHangCtId == Id);
        }

        public async Task<bool> Update(DonHangCT donHang)
        {
            var dh = await _dbContext.DonHangCts.FirstOrDefaultAsync(c => c.DonHangCtId == donHang.DonHangCtId);
            if (dh != null)
            {
                dh.DonHangId = donHang.DonHangId;
                
                _dbContext.DonHangCts.Remove(dh);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}
