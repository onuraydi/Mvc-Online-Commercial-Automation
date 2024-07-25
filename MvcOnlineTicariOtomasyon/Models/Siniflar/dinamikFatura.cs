using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcOnlineTicariOtomasyon.Models.Siniflar
{
    public class dinamikFatura
    {
        public IEnumerable<Faturalar> fatura { get; set; }
        public IEnumerable<FaturaKalem> faturaKalem { get; set; }
    }
}