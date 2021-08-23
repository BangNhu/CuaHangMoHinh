using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CuaHangBanMoHinh.Models
{
    public class DangNhapModel
    {
        [Key]
        [Required(ErrorMessage ="Phải nhập tài khoản")]
        public string TaiKhoan { get; set; }
        [Required(ErrorMessage = "Phải nhập mật khẩu")]
        public string MatKhau { get; set; }
    }
}