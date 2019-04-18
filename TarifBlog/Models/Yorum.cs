using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TarifBlog.Models
{
    public class Yorum
    {
        [Key]
        public int YorumID { get; set; }
        public string İcerik { get; set; }
        public int? UyeID { get; set; }
        public virtual Uye Uye { get; set; }
        public int? TarifID { get; set; }
        public virtual Tarif Tarif { get; set; }
        public DateTime YorumTarih { get; set; }
    }
}