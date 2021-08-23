namespace CuaHangBanMoHinh.Models.EL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ADMIN")]
    public partial class ADMIN
    {
        [Key]
        public int MaAd { get; set; }

        [StringLength(50)]
        public string HoTen { get; set; }

        [StringLength(10)]
        public string DienThoai { get; set; }

        [StringLength(15)]
        public string TenDN { get; set; }

        [StringLength(50)]
        public string MatKhau { get; set; }

        public int? Quyen { get; set; }
    }
}
