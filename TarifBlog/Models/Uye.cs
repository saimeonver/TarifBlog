using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TarifBlog.Models
{
    public class Uye
    {
        [Key]
        public int UyeID { get; set; }
        public string KullaniciAdi { get; set; }
        public string Email { get; set; }
        public string Sifre { get; set; }
        public string AdSoyad { get; set; }

        public int? YetkiID { get; set; }
        public virtual Yetki Yetki { get; set; }
        public virtual ICollection<Yorum> Yorum { get; set; }
    }
}