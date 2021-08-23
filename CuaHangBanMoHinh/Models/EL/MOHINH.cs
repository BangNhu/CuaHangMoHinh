namespace CuaHangBanMoHinh.Models.EL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MOHINH")]
    public partial class MOHINH
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public MOHINH()
        {
            BINHLUANs = new HashSet<BINHLUAN>();
            CHITIETDATHANGs = new HashSet<CHITIETDATHANG>();
        }

        [Key]
        public int MaMH { get; set; }

        [Required]
        [StringLength(100)]
        public string TenMH { get; set; }

        [Column(TypeName = "ntext")]
        public string MoTa { get; set; }

        [StringLength(50)]
        public string HinhLon { get; set; }

        [StringLength(50)]
        public string HinhNho { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? NgayCapNhat { get; set; }

        public int? SoLuongBan { get; set; }

        [Column(TypeName = "money")]
        public decimal? GiaBan { get; set; }

        public int? MaLoaiMH { get; set; }

        public int? MaLoaiPhim { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BINHLUAN> BINHLUANs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CHITIETDATHANG> CHITIETDATHANGs { get; set; }

        public virtual LOAIMOHINH LOAIMOHINH { get; set; }

        public virtual LOAIPHIM LOAIPHIM { get; set; }
    }
}
