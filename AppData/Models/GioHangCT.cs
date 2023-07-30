using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppData.Models
{
    public class GioHangCT
    {
        public Guid KhachHangId { get; set; }
        public Guid GioHangCtId { get; set; }
        public Guid SanPhamid { get; set; }
        public int SoLuong { get; set; }
        public decimal TongTien { get; set; }
        public int TrangThai { get; set; }
        public DateTime NgayTao { get; set; }
        public virtual GioHang? GioHang { get; set; }
        public virtual SanPham? SanPham { get; set; }
    }
}
