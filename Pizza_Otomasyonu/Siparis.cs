using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaOtomasyonu
{
    internal class Siparis
    {
        public Pizza Pizza_ { get; set; }
        public int Adet { get; set; }
        public decimal ToplamTutar
        {
            get
            {
                decimal tutar;
                tutar = Adet * Pizza_.Tutar;
                return tutar;

            }
        }

        public override string ToString()
        {
            string malzemeler = "";
            foreach (var item in Pizza_.Malzemeler)
            {
                malzemeler += item.ToString() + ",";
            }
            return $"{Pizza_.Adi},{Pizza_.Ebati},{malzemeler}{Adet}x{Pizza_.Fiyati}={ToplamTutar} TL";
        }
    }
}
