﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Siniflar
{
    public class Personel
    {
        [Key]
        public int PersonelID { get; set; }
        [Column(TypeName = "varchar")]
        [StringLength(30)]
        public string PersonelAd { get; set; }
        [Column(TypeName = "varchar")]
        [StringLength(30)]  
        public string PersonelSoyad { get; set; }
        [Column(TypeName = "varchar")]
        [StringLength(300)]
        public string PersonelGorsel { get; set; }
        [Column(TypeName = "varchar")]
        [StringLength(300)]
        public string Adres { get; set; }
        [Column(TypeName = "varchar")]
        [StringLength(20)]
        public string Telefon { get; set; }
        [Column(TypeName = "varchar")]
        [StringLength(70)]
        public string mail { get; set; }
        [Column(TypeName = "varchar")]
        [StringLength(30)]
        public string PersonelSifre { get; set; }
        [Column(TypeName = "varchar")]
        [StringLength(500)]
        public string Hakkinda { get; set; }
        public ICollection<SatisHareket> SatisHarekets { get; set; }
        public int DepartmanId { get; set; }
        public bool PersonelDurum { get; set; }
        public virtual Departman Departman { get; set; }
    }
}