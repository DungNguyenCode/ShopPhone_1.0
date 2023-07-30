using AppData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppData.Interface
{
    public interface ISanPham
    {
        public  Task<List<SanPham>> GetAllSanPham();
        public Task<SanPham> GetById(Guid Id);
        public Task<bool> Add (SanPham sanPham);
        public Task<bool> Update(SanPham sanPham);
        public Task<bool> Delete(Guid Id);

    }
}
