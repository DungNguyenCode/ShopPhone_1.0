using AppData.Models;

namespace AppView.ViewModels
{
    public class GioHangViewModel
    {
        public  SanPham sanPham { get; set; }
        public int SoLuong { get; set; }
        public Guid IdSanPham { get; set; }
        public decimal TongTien => SoLuong * sanPham.Gia;
    }
}
