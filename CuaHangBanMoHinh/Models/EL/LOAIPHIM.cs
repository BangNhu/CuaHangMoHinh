namespace CuaHangBanMoHinh.Models.EL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("LOAIPHIM")]
    public partial class LOAIPHIM
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public LOAIPHIM()
        {
            MOHINHs = new HashSet<MOHINH>();
        }

        [Key]
        public int MaLoaiPhim { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name ="Tên phim")]
        public string TenPhim { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MOHINH> MOHINHs { get; set; }
    }
}
