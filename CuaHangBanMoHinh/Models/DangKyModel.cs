using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CuaHangBanMoHinh.Models
{
    public class DangKyModel
    {
        [Key]
        public int MaKH { get; set; }

        [Display(Name ="Họ và tên")]
        [Required(ErrorMessage = "Phải nhập họ và tên.")]
        public string HoTen { get; set; }


        [Display(Name = "Tên tài khoản")]
        [Required(ErrorMessage = "Phải nhập tên đăng nhập.")]
        public string TaiKhoan { get; set; }


        [Display(Name = "Mật khẩu")]
        [Required(ErrorMessage = "Phải nhập mật khẩu.")]
        [StringLength(20,MinimumLength = 6,ErrorMessage ="Độ dài mật khẩu tối thiểu 6")]
        public string MatKhau { get; set; }


        [Required(ErrorMessage = "Phải nhập mật khẩu.")]
        [Display(Name = "Xác nhận mật khẩu")]
        [Compare("MatKhau", ErrorMessage = "Xác nhận mật khẩu không đúng")]
        
        public string XacNhanMatKhau { get; set; }
        [Display(Name = "Email")]
        public string Email { get; set; }
        [Display(Name = "Địa chỉ")]
        public string DiaChi { get; set; }
        [Display(Name = "Điện thoại")]
        public string DienThoai { get; set; }
    }
}