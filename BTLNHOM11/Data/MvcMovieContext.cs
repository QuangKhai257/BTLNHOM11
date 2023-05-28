using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BTLNHOM11.Models;

namespace MvcMovie.Data
{
    public class MvcMovieContext : DbContext
    {
        public MvcMovieContext (DbContextOptions<MvcMovieContext> options)
            : base(options)
        {
        }

        public DbSet<BTLNHOM11.Models.chucvu> chucvu { get; set; } = default!;

        public DbSet<BTLNHOM11.Models.nhanvien> nhanvien { get; set; } = default!;

        public DbSet<BTLNHOM11.Models.nhacungcap> nhacungcap { get; set; } = default!;

        public DbSet<BTLNHOM11.Models.sanpham> sanpham { get; set; } = default!;

        public DbSet<BTLNHOM11.Models.nhaphang> nhaphang { get; set; } = default!;

        public DbSet<BTLNHOM11.Models.khachhang> khachhang { get; set; } = default!;

        public DbSet<BTLNHOM11.Models.hoadon> hoadon { get; set; } = default!;

       
    }
}
