namespace CuaHangBanMoHinh.Models.EL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("LOAIMOHINH")]
    public partial class LOAIMOHINH
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public LOAIMOHINH()
        {
            MOHINHs = new HashSet<MOHINH>();
        }

        [Key]
        public int MaLoaiMH { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name ="Tên mô hình")]
        public string TenMH { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MOHINH> MOHINHs { get; set; }
    }
}
