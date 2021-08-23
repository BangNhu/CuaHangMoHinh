namespace CuaHangBanMoHinh.Models.EL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("BINHLUAN")]
    public partial class BINHLUAN
    {
        [Key]
        public int MaBL { get; set; }

        public int? MaKH { get; set; }

        public int? MaMH { get; set; }

        [StringLength(100)]
        public string NoiDung { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? ThoiGianDang { get; set; }

        public int? DanhGia { get; set; }

        public virtual KHACHHANG KHACHHANG { get; set; }

        public virtual MOHINH MOHINH { get; set; }
    }
}
