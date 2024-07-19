using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Siniflar
{
    public class YapilacaklarListesi
    {
        [Key]
        public int YapilacakID { get; set; }

        [Column(TypeName ="varchar")]
        [StringLength(50)]
        public string yapilacakGorev { get; set; }
        [Column(TypeName = "bit")]
        public bool Durum { get; set; }
    }
}