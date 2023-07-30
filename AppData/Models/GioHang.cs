using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppData.Models
{
    public class GioHang
    {

        public Guid KhachHangId { get; set; }
        public string ? MoTa { get; set; }

        public string ?TenKhachHang { get; set; }
        public string ?Email { get; set; }
        public string ?DiaChi { get; set; }
        public virtual KhachHang ?KhachHangs { get; set;}
        public virtual ICollection<GioHangCT >? GioHangCTs { get; set; }




       
    }
}
