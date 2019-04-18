using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TarifBlog.Models
{
    public class Tarif
    {
        [Key]
        public int TarifID { get; set; }
        public string TarifAdi { get; set; }
        public string Malzemeler { get; set; }
        public string Yapilis { get; set; }
        public string Foto { get; set; }
        public DateTime Tarih { get; set; }
        public int? KategoriID { get; set; }
        public virtual Kategori Kategori { get; set; }
        public int? UyeID { get; set; }
        public virtual Uye Uye { get; set; }
        public int Okunma { get; set; }
        public virtual ICollection<Yorum> Yorum { get; set; }
        public virtual ICollection<TarifEtiket> Etiket { get; set; }
        public virtual ICollection<Etiket> Etikets { get; set; }
    }
}