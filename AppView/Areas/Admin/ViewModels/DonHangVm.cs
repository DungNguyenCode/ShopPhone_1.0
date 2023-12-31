﻿using AppData.Models;

namespace AppView.Areas.Admin.ViewModels
{
    public class Class
    {
        public Guid idDonHang { get; set; }
        public string ten { get; set; }
        public string tenDayDu { get; set; }
        
        public Guid idSanPham { get; set; }
        public DateTime ngayTao { get; set; }
        public int trangThai { get; set; }
        public decimal thanhTien { get; set; }
        public int soLuong { get; set; }
        public string DiaChi { get; set; }
        public List<SanPham> sanPhams { get; set; }
        public KhachHang khachHang { get; set; }
    }
}
