using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFramework.Context
{
    public class NorthwindContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=Kütüphane;Trusted_Connection=true");

        }
        public DbSet<Ogrenci> Ogrenci { get; set; }
        public DbSet<OduncAl> OduncAl { get; set; }
        public DbSet<Kitaplar> Kitaplar { get; set; }
        public DbSet<Raf> Raf { get; set; }
        public DbSet<Yazar> Yazar{ get; set; }
        public DbSet<KitapYazar> Kitap_Yazar { get; set; }
        public DbSet<Rezervasyon> Rezervasyon { get; set; }
    }
}
