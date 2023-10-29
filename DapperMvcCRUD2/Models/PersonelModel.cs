using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DapperMvcCRUD2.Models
{
    public class PersonelModel
    {

        public int PersonelID { get; set; }
        public int BolumID { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public DateTime DoğumTarihi { get; set; }
        public string BolumAd { get; set; }
    }
}