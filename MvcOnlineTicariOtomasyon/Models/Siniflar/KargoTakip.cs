using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Siniflar
{
    public class KargoTakip
    {
        [Key]
        public int KargoTakipID { get; set; }
        [Column(TypeName ="varchar")]
        [StringLength(10)]
        public string KargoTakipKodu { get; set; }
        [Column(TypeName = "varchar")]
        [StringLength(100)]
        public string Aciklama { get; set; }
        public DateTime Tarih { get; set; }
    }
}