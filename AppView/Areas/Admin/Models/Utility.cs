using System.Runtime.InteropServices;
using System;
using System.Security.Cryptography;
using System.Security.Policy;
using System.Text;

namespace AppView.Areas.Admin.Models
{
    public class Utility
    {
        public static string GetMd5Hash(string input)
        {
            using (var md5 = MD5.Create())
            {
                byte[] inputBytes = Encoding.UTF8.GetBytes(input);
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                StringBuilder stringBuilder = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    stringBuilder.Append(hashBytes[i].ToString("x2"));
                }

                return stringBuilder.ToString();
            }
        }
//        Mã hóa MD5:

//Trong phương thức GetMd5Hash(string input), chúng ta nhận một chuỗi dữ liệu(input) là tên người dùng hoặc mật khẩu.
//Đầu tiên, chúng ta tạo một đối tượng MD5 bằng cách sử dụng lớp MD5 từ namespace System.Security.Cryptography.
//Sau đó, chúng ta chuyển đổi chuỗi dữ liệu(input) thành mảng byte bằng cách sử dụng mã hóa UTF-8.
//Tiếp theo, chúng ta tính toán giá trị băm(hash) của mảng byte đó bằng cách sử dụng phương thức ComputeHash() của đối tượng MD5.
//    Cuối cùng, chúng ta chuyển đổi mảng byte thành chuỗi hexa bằng cách lặp qua từng byte và sử dụng phương thức ToString("x2") để chuyển đổi byte thành chuỗi hexa 2 ký tự.
//Phương thức trả về chuỗi băm (hash) dưới dạng chuỗi hexa.
    }
}
