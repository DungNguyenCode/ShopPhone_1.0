using AppData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppData.Interface
{
    public interface IDonHangCt
    {
        public Task<List<DonHangCT>> GetAllDonHang();
        public Task<DonHangCT> GetById(Guid Id);
        public Task<bool> Add(DonHangCT donHang);
        public Task<bool> Update(DonHangCT donHang);
        public Task<bool> Delete(Guid Id);
    }
}
