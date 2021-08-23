﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CuaHangBanMoHinh.Models.ViewModel
{
    public class ContactViewModel
    {
        public string Name { get; set; }
        [Display(Name = "Số điện thoại")]
        [RegularExpression(@"^(\d{4,15})$", ErrorMessage = "*{0} không hợp lệ")]
        public string Phone { get; set; }
        [Display(Name = "Email")]
        [EmailAddress(ErrorMessage = "*{0} không hợp lệ")]
        public string Email { get; set; }
        public string Content { get; set; }

    }
}