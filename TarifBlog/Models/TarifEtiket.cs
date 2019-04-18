using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TarifBlog.Models
{
    public class TarifEtiket
    {
        [Key]
        public int TarifEtiketID { get; set; }
        public int TarifID { get; set; }
        public virtual Tarif Tarif { get; set; }
        public int EtiketID { get; set; }
        public virtual Etiket Etiket { get; set; }
    }
}