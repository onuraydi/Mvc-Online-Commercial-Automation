using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;


namespace MvcOnlineTicariOtomasyon.Models.Siniflar
{
    public class Context:DbContext
    {
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Cari> Caris { get; set; }  
        public DbSet<Departman> Departmans { get; set; }
        public DbSet<FaturaKalem> FaturaKalems { get; set; }
        public DbSet<Faturalar> Faturalars { get; set; }
        public DbSet<Gider> Giders { get; set; }
        public DbSet<Kategori> Kategoris { get; set; }
        public DbSet<Personel> Personels { get; set; }
        public DbSet<SatisHareket> SatisHarekets { get; set; }
        public DbSet<Urun> Uruns { get; set; }
        public DbSet<Detay> detays { get; set; }
        public DbSet<YapilacaklarListesi> yapilacaklarListesis { get; set; }
        public DbSet<KargoDetay> kargoDetays { get; set; }
        public DbSet<KargoTakip> kargoTakips { get; set; }
        public DbSet<Mesaj> mesajs { get; set; }

    }
}