using System.ComponentModel.DataAnnotations;

namespace AppView.ViewModels
{
    public class RegisterViewModel
    {
        [Required, MaxLength(50)]
        public string Username
        {
            get;
            set;
        }
        [Required(ErrorMessage =("Email là bắt buộc phải nhập!")), DataType(DataType.EmailAddress)]
        [Display(Name = "Địa chỉ Email")]
        public string Email
        {
            get;
            set;
        }
        [Required( ErrorMessage = "Mật khẩu là bắt buộc phải nhập!"), DataType(DataType.Password)]
        [Display(Name = "Mật khẩu")]
        public string Password
        {
            get;
            set;
        }
        [DataType(DataType.Password), Compare(nameof(Password))]
        [Display(Name = "Xác nhận mật khẩu")]
        [Required(ErrorMessage ="Vui lòng xác nhận mật khẩu!")]
        public string ConfirmPassword
        {
            get;
            set;
        }
    }
}
