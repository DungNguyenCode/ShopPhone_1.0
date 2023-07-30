using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppData.Models
{
    public class KhachHang
    {
        public Guid KhachHangId { get; set; }
        public Guid ChucVuId { get; set; }
        public string? Ten { get; set; }
        public string? MatKhau { get; set; }
        public string? Email { get; set; }
        public string? TenDayDu { get; set; }
        public string? DiaChi { get; set; }
        public int TrangThai { get; set; }
        public string? SoDienThoai { get; set; }
        public string AnhDaiDien { get; set; }
        public int VaiTro { get; set; }
        
        public virtual ChucVu? ChucVu { get; set; }
        public virtual GioHang? GioHangs { get; set; }
        public virtual ICollection<DonHang>? DonHangs { get; set; }


    }
}
