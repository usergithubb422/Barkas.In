using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarKasinApp.model
{
    public class Stuff
    {
        public string Nama { get; set; }
        public string BanyakBarang { get; set; }
        public string Alamat { get; set; }
        public string Harga { get; set; }
        public string Alasan { get; set; }
        public object Gambar { get; set; }
        public string Kategori { get; set; }

        public Stuff(string nama, string banyakBarang, string alamat, string alasan, string harga)
        {
            Nama = nama;
            BanyakBarang = banyakBarang;
            Alamat = alamat;
            Harga = harga;
            Alasan = alasan;
        }

        
    }
}
