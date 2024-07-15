﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Siniflar
{
    public class Faturalar
    {
        [Key]
        public int FaturaID { get; set; }
        [Column(TypeName = "char")]
        [StringLength(1)]
        public string FaturaSeriNo { get; set; }   //seri n tek harftir
        [Column(TypeName = "varchar")]
        [StringLength(6)]
        public string FaturaSıraNo { get; set; }
        public DateTime FaturaTarih { get; set; }
        [Column(TypeName = "varchar")]
        [StringLength(60)]
        public string VergiDairesi { get; set; }
        public DateTime Saat { get; set; }
        [Column(TypeName = "varchar")]
        [StringLength(30)]
        public string TeslimEden { get; set; }
        [Column(TypeName = "varchar")]
        [StringLength(30)]
        public string TeslimAlan { get; set; }
        // Bir faturanın birden fazla kalemi olabilir
        public ICollection<FaturaKalem> FaturaKalems { get; set; }
    }
}