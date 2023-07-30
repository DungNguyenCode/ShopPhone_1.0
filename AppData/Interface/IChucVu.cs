using AppData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppData.Interface
{
    public interface IChucVu
    {
        public Task<List<ChucVu>> GetAllChucVu();
        public Task<ChucVu> GetById(Guid Id);
        public Task<bool> Add(ChucVu chucVu );
        public Task<bool> Update( ChucVu chucVu);
        public Task<bool> Delete(Guid Id);
    }
}
