using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppData.Models
{
    public class ChucVu
    {
        public Guid ChucVuId { get; set; }
        public string? TenRole { get; set; }
        public string? MoTa { get; set; }
        public int TrangThai { get; set; }
        public virtual ICollection<KhachHang>?KhachHangs { get; set; } 

    }
}
