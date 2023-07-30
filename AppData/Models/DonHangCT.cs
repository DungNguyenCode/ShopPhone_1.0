using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppData.Models
{
    public class DonHangCT
    {
        public Guid DonHangCtId { get; set; }
        public Guid DonHangId { get; set; }
        public Guid IdSanPham { get; set; }
        public int SoLuong { get; set; }
        public virtual DonHang ?DonHang { get; set; }
        public virtual SanPham? SanPham { get; set; }
    }
}
