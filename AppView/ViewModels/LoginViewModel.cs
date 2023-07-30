using System.ComponentModel.DataAnnotations;

namespace AppView.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage ="Email là bắt buộc phải nhập!")]
        [Display(Name ="Địa chỉ Email")]
        public string Email
        {
            get;
            set;
        }
        [Required(ErrorMessage ="Mật khẩu là bắt buộc phải nhập!"), DataType(DataType.Password)]
        [Display(Name ="Mật khẩu")]
        public string Password
        {
            get;
            set;
        }
        [Display(Name =("Ghi nhớ"))]
        public bool RememberMe
        {
            get;
            set;
        }
    }
}
