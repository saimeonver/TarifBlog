using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TarifBlog.Models
{
    public class Yetki
    {
        [Key]
        public int YetkiID { get; set; }
        public string Yetkiler { get; set; }
        public virtual ICollection<Uye> Uye { get; set; }
    }
}