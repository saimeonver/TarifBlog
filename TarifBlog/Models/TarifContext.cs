using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace TarifBlog.Models
{
    public class TarifContext:DbContext
    {
        public DbSet<Etiket> Etiket { get; set; }
        public DbSet<Kategori> Kategori { get; set; }
        public DbSet<Tarif> Tarif { get; set; }
        public DbSet<TarifEtiket> TarifEtiket { get; set; }
        public DbSet<Uye> Uye { get; set; }
        public DbSet<Yetki> Yetki { get; set; }
        public DbSet<Yorum> Yorum { get; set; }
    }
}