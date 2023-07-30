using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppData.Models
{
    public class DonHang
    {
        public Guid DonHangId { get; set; }
        public string ?Ten { get; set; }
        public int TrangThai { get; set; }
        public DateTime NgayTao { get; set; }
        public Guid KhachHangId { get; set; }
        public string ?TenKhachHang { get; set; }
        public string ?DiaChi { get; set; }
        public virtual KhachHang ?KhachHangs { get; set; }
        public virtual ICollection<DonHangCT> ?DonHangCTs { get; set; }
    }
}
