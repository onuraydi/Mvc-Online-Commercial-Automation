using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Siniflar
{
    public class Kategori
    {
        [Key]   // ID değerinin primary key olduğunu belirtmek için kullanıldı.
        public int KategoriID { get; set; }
        [Column(TypeName = "varchar")]
        [StringLength(30)]
        public string KategoriAd { get; set; }
        public ICollection<Urun> Uruns {  get; set; }  // İlişki ayarlamak için kullanıldı 
        // bir kategoidebirden fazla ürün olabilir anlamında yazıldı
    }
}