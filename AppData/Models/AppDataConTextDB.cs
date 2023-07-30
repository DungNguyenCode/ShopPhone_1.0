using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AppData.Models
{
    public class AppDataConTextDB :DbContext

    {
        public AppDataConTextDB()
        {


        }

        public AppDataConTextDB(DbContextOptions options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=DUNGNGUYEN\SQLEXPRESS;Initial Catalog=Shopping_C5u;Integrated Security=True");
        }
        public DbSet<SanPham> SanPhams { get; set; }
        public DbSet<DonHang> DonHangs { get; set; }
        public DbSet<DonHangCT> DonHangCts { get; set; }
        public DbSet<GioHang> GioHangs { get; set; }
        public DbSet<GioHangCT> GioHangCts { get; set; }
        public DbSet<KhachHang> KhachHangs { get; set; }
        public DbSet<ChucVu>  ChucVus { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.
               GetExecutingAssembly());
        }
    }
}
