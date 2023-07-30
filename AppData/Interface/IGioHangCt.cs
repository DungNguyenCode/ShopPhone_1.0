using AppData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppData.Interface
{
    public interface IGioHangCt
    {
        public Task<List<GioHangCT>> GetAllGioHang();
        public Task<GioHangCT> GetById(Guid Id);
        public Task<bool> Add(GioHangCT gioHangCT);
        public Task<bool> Update( GioHangCT gioHangCT);
        public Task<bool> Delete(Guid Id);
    }
}
