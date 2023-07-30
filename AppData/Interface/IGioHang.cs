using AppData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppData.Interface
{
    public interface IGioHang
    {
        public Task<List<GioHang>> GetAllGioHang();
        public Task<GioHang> GetById(Guid Id);
        public Task<bool> Add(GioHang gioHang);
        public Task<bool> Update(GioHang gioHang);
        public Task<bool> Delete(Guid id);

    }
}
