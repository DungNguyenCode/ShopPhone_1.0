using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppData.Models
{
    public class SanPham
    {

        public Guid SanPhamId { get; set; }
        [Required  ( ErrorMessage ="Dien Ten")]
        [MaxLength(50)]
        public string ? Ten { get; set; }
        public string ?Img { get; set; }
        public decimal Gia { get; set; }
        public int TrangThai { get; set; }
        public string ?NhaCungCap { get; set; }
        public int SoLuong { get; set; }
        public string ?MauSac { get; set; }
        public string ?Mota { get; set; }
        public int SoLuongTon { get; set; }
        public virtual ICollection< DonHangCT>? DonHangCts { get; set; }
        public virtual  ICollection< GioHangCT>? GioHangCt { get; set; }

    }
}
