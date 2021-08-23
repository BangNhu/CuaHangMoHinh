namespace CuaHangBanMoHinh.Models.EL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DONDATHANG")]
    public partial class DONDATHANG
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DONDATHANG()
        {
            CHITIETDATHANGs = new HashSet<CHITIETDATHANG>();
        }

        [Key]
        public int MaDonHang { get; set; }

        public bool? DaThanhToan { get; set; }

        public int? TinhTrangGiaoHang { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? NgayDat { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? NgayGiao { get; set; }

        public int? MaKH { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CHITIETDATHANG> CHITIETDATHANGs { get; set; }

        public virtual KHACHHANG KHACHHANG { get; set; }
    }
}
