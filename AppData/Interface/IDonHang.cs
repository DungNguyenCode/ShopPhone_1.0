using AppData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppData.Interface
{
    public interface IDonHang
    {
        public Task<List<DonHang>> GetAllDonHang();
        public Task<DonHang> GetById(Guid Id);
        public Task<bool> Add(DonHang donHang);
        public Task<bool> Update(DonHang donHang);
        public Task<bool> Delete(Guid Id);
    }
}
