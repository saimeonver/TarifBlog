using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TarifBlog.Models
{
    public class Etiket
    {
        [Key]
        public int EtiketID { get; set; }
        public string EtiketAdi { get; set; }
        public virtual ICollection<TarifEtiket> Tarif { get; set; }
        public virtual ICollection<Tarif> Tarifs { get; set; }
    }
}