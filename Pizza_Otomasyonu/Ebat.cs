using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaOtomasyonu
{
    internal class Ebat
    {
        public string Adi { get; set; }
        public double Carpani { get; set; }

        public override string ToString()//önemli
        {
            return Adi;
        }
    }
}
