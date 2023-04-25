using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PizzaOtomasyonu
{
    public partial class Form1 : Form
    {
        //bir değer için iki farklı değer tutuluyorsa class kullanılır mesela ince kenar kalın kenar 
        //hem ismini hem de fiyatını tuttuğumuz için class oluşturmamız gerekiyor.
        public Form1()
        {
            InitializeComponent();
            btnHesapla.Enabled = false;
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            rbInceKenar.Checked = true;

            Ebat kucuk = new Ebat { Adi = "Küçük", Carpani = 1 };
            //cmbEbat.Text = kucuk;
            Ebat orta = new Ebat { Adi = "Orta", Carpani = 1.25 };
            Ebat buyuk = new Ebat { Adi = "Büyük", Carpani = 1.75 };
            Ebat maxi = new Ebat { Adi = "Maxi", Carpani = 2.00 };

            cmbEbat.Items.Add(kucuk);//.ToString override edildi.
            cmbEbat.SelectedIndex = 0;
            cmbEbat.Items.Add(orta);
            cmbEbat.Items.Add(buyuk);
            cmbEbat.Items.Add(maxi);

            KenarTip Ince = new KenarTip { Adi = "İnce Kenar", EkFiyat = 0 };
            rbInceKenar.Tag = Ince;
            KenarTip Kalin = new KenarTip { Adi = "Kalın Kenar", EkFiyat = 15 };
            rbKalinKenar.Tag = Kalin;

            Pizza Klasik = new Pizza { Adi = "Klasik", Fiyati = 80 };
            Pizza Karma = new Pizza { Adi = "Karma", Fiyati = 100 };
            Pizza Turkish = new Pizza { Adi = "Turkish", Fiyati = 200 };
            Pizza Tuna = new Pizza { Adi = "Tuna", Fiyati = 120 };
            Pizza Akdeniz = new Pizza { Adi = "Akdeniz", Fiyati = 100 };
            Pizza Karadeniz = new Pizza { Adi = "Karadeniz", Fiyati = 250 };

            listPizzalar.Items.Add(Klasik);
            listPizzalar.SelectedIndex = 0;
            listPizzalar.Items.Add(Karma);
            listPizzalar.Items.Add(Turkish);
            listPizzalar.Items.Add(Tuna);
            listPizzalar.Items.Add(Akdeniz);
            listPizzalar.Items.Add(Karadeniz);
        }

        private void btnHesapla_Click(object sender, EventArgs e)
        {
            Pizza p = listPizzalar.SelectedItem as Pizza;
            //yada
            //Pizza pz= (Pizza)listPizzalar.SelectedItem;
            p.Ebati = cmbEbat.SelectedItem as Ebat;//as daha iyi bir kullanım
            //p.Ebati = (Ebat)cmbEbat.SelectedItem;
            p.KenarTipi = rbInceKenar.Checked ? (KenarTip)rbInceKenar.Tag : (KenarTip)rbKalinKenar.Tag;
            p.Malzemeler = new List<string>();

            foreach (CheckBox item in groupBox1.Controls)
            {
                if (item.Checked)
                {
                    p.Malzemeler.Add(item.Text);
                }
            }

            decimal tutar = numAdet.Value * p.Tutar;
            txtTutar.Text = tutar.ToString();
            siparis = new Siparis();
            siparis.Pizza_ = p;
            siparis.Adet = (int)numAdet.Value;

        }
        Siparis siparis;
        private void btnSepeteEkle_Click(object sender, EventArgs e)
        {
            if (siparis != null)
                listSepet.Items.Add(siparis);
        }

        private void btnSiparisOnayla_Click(object sender, EventArgs e)
        {
            if(listSepet.Items.Count > 0)
            {
                decimal toplamtutar = 0;
                int adet = 0;
                foreach (Siparis spr in listSepet.Items)
                {
                    toplamtutar += spr.ToplamTutar;
                    adet++;
                }
                lblToplamTutar.Text = toplamtutar.ToString();
                MessageBox.Show($"Toplam Sipariş adediniz:{adet}\nToplam sipariş tutarınız:{toplamtutar}");
                listSepet.Items.Clear();
            }
            


        }

        private void numAdet_ValueChanged(object sender, EventArgs e)
        {
            if (int.Parse(numAdet.Value.ToString()) > 0)
                btnHesapla.Enabled = true;
            else
                btnHesapla.Enabled = false;
        }

        private void btnSepettenKaldir_Click(object sender, EventArgs e)
        {
            int secilen = listSepet.SelectedIndex;
            if (secilen > -1)
                listSepet.Items.RemoveAt(secilen);
        }
    }
}
