using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaOtomasyonu
{
    internal class Pizza
    {
        public string Adi { get; set; }
        public decimal Fiyati { get; set; }
        public Ebat Ebati { get; set; }
        public KenarTip KenarTipi { get; set; }
        public List<string> Malzemeler { get; set; } = new List<string>();

        public decimal Tutar
        {
            get
            {
                decimal tutar = 0;
                tutar = Fiyati * (decimal)Ebati.Carpani;
                tutar += KenarTipi.EkFiyat;
                return tutar;
            }
        }

        public override string ToString()
        {
            return Adi;
        }

    }
}
