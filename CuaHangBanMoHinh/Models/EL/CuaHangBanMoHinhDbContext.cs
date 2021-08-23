using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace CuaHangBanMoHinh.Models.EL
{
    public partial class CuaHangBanMoHinhDbContext : DbContext
    {
        public CuaHangBanMoHinhDbContext()
            : base("name=CuaHangBanMoHinhDbContext")
        {
        }

        public virtual DbSet<ADMIN> ADMINs { get; set; }
        public virtual DbSet<BINHLUAN> BINHLUANs { get; set; }
        public virtual DbSet<CHITIETDATHANG> CHITIETDATHANGs { get; set; }
        public virtual DbSet<DONDATHANG> DONDATHANGs { get; set; }
        public virtual DbSet<KHACHHANG> KHACHHANGs { get; set; }
        public virtual DbSet<LOAIMOHINH> LOAIMOHINHs { get; set; }
        public virtual DbSet<LOAIPHIM> LOAIPHIMs { get; set; }
        public virtual DbSet<MOHINH> MOHINHs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ADMIN>()
                .Property(e => e.DienThoai)
                .IsUnicode(false);

            modelBuilder.Entity<ADMIN>()
                .Property(e => e.TenDN)
                .IsUnicode(false);

            modelBuilder.Entity<ADMIN>()
                .Property(e => e.MatKhau)
                .IsUnicode(false);

            modelBuilder.Entity<CHITIETDATHANG>()
                .Property(e => e.DonGia)
                .HasPrecision(9, 2);

            modelBuilder.Entity<DONDATHANG>()
                .HasMany(e => e.CHITIETDATHANGs)
                .WithRequired(e => e.DONDATHANG)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<KHACHHANG>()
                .Property(e => e.TaiKhoan)
                .IsUnicode(false);

            modelBuilder.Entity<KHACHHANG>()
                .Property(e => e.MatKhau)
                .IsUnicode(false);

            modelBuilder.Entity<KHACHHANG>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<KHACHHANG>()
                .Property(e => e.DienThoai)
                .IsUnicode(false);

            modelBuilder.Entity<MOHINH>()
                .Property(e => e.HinhLon)
                .IsUnicode(false);

            modelBuilder.Entity<MOHINH>()
                .Property(e => e.HinhNho)
                .IsUnicode(false);

            modelBuilder.Entity<MOHINH>()
                .Property(e => e.GiaBan)
                .HasPrecision(19, 4);

            modelBuilder.Entity<MOHINH>()
                .HasMany(e => e.CHITIETDATHANGs)
                .WithRequired(e => e.MOHINH)
                .WillCascadeOnDelete(false);
        }
    }
}
