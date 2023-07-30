using AppData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppData.Interface
{
    public interface IKhachHang
    {
        public Task<List<KhachHang>> GetAllKhachHang();
        public Task<KhachHang> GetById(Guid Id);
        public Task<bool> Add(KhachHang khachHang);
        public Task<bool> Update(KhachHang khachHang);
        public Task<bool> Delete(Guid Id);
    }
}
