using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BilgeKahveEvi
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        string[] kahveler = { "Misto", "Americano", "Bianco", "Cappucino", "Macchiato", "Con Panna", "Mocha" };
        double[] kahveFiyatlari = { 4.5, 5.75, 6, 7.5, 6.75, 8, 7.75 };
        string[] sogukIcecekler = { "Kola", "Ice Tea", "Su" };
        double[] sogukFiyatlari = { 5.5, 5.5, 5.5 };
        string[] sicakIcecekler = { "Çay", "Hot Chocolate", "Chai Tea Latte" };
        double[] sicakFiyatlari = { 3, 4.5, 6.5 };
        double[] katsayilar = { 1, 1.25, 1.75 };
        double toplamFiyat;

        List<double> fiyatlar = new List<double>();

        private void Form1_Load(object sender, EventArgs e)
        {
            
            FillKahveler();
            FillSoguklar();
            FillSicaklar();
            FormClear();
        }

        public void FormClear()
        {
            cmbKahve.SelectedIndex = -1;
            cmbSicakİcecek.SelectedIndex = -1;
            cmbSogukIcecek.SelectedIndex = -1;
            numUpDownKahve.Value = 0;
            numUpDownSicak.Value = 0;

        }

        
        private void FillSicaklar()
        {
            cmbSicakİcecek.Items.Clear();
            for (int i = 0; i < sicakIcecekler.Length; i++)
            {
                cmbSicakİcecek.Items.Add(sicakIcecekler[i]);
            }
        }

        public void FillSoguklar()
        {
            cmbSogukIcecek.Items.Clear();
            for (int i = 0; i < sogukIcecekler.Length; i++)
            {
                cmbSogukIcecek.Items.Add(sogukIcecekler[i]);
            }
        }

        public void FillKahveler()
        {
            cmbKahve.Items.Clear();
            for (int i = 0; i < kahveler.Length; i++)
            {
                cmbKahve.Items.Add(kahveler[i]);
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                int kahveAdet = Convert.ToInt32(numUpDownKahve.Value);
                int sogukAdet = Convert.ToInt32(numUpDOwnSoguk.Value);
                int sicakAdet = Convert.ToInt32(numUpDownSicak.Value);
                string name = txtAdSoyad.Text;
                ulong telefon = Convert.ToUInt64(txtTelefon.Text);
                string adres = txtAdres.Text;
                if (telefon.ToString().Length != 10)
                {
                    MessageBox.Show("Hatalı telefon numarası girişi yaptınız. Lütfen başında 0 olmadan 10 hane olacak şekilde giriniz.");
                }
                if (cmbKahve.SelectedIndex == -1 && cmbSicakİcecek.SelectedIndex == -1 && cmbSogukIcecek.SelectedIndex == -1)
                {
                    MessageBox.Show("Lütfen bir ürün seçiniz.");
                    cmbKahve.Focus();
                    return;
                }
                for (int i = 0; i < cmbKahve.Items.Count; i++)
                {
                   
                    if (cmbKahve.SelectedIndex == i && kahveAdet > 0 && rbTall.Checked)
                    {

                        double kahveFiyati = Convert.ToDouble(numUpDownKahve.Value) * kahveFiyatlari[i]*katsayilar[0]+0.5;
                        string eklenecekUrunKahve = $"{kahveAdet} adet {kahveler[i]} + {kahveFiyati} TL";
                        listBox1.Items.Add(eklenecekUrunKahve);

                        fiyatlar.Add(kahveFiyati);
                        FormClear();

                    }
                    else if (cmbKahve.SelectedIndex == i && kahveAdet > 0 && rbGrande.Checked)
                    {
                        double kahveFiyati = Convert.ToDouble(numUpDownKahve.Value) * kahveFiyatlari[i] * katsayilar[1];
                        string eklenecekUrunKahve = $"{kahveAdet} adet {kahveler[i]} + {kahveFiyati} TL";
                        listBox1.Items.Add(eklenecekUrunKahve);

                        fiyatlar.Add(kahveFiyati);
                        FormClear();

                    }
                    else if (cmbKahve.SelectedIndex == i && kahveAdet > 0 && rbVenti.Checked)
                    {
                        double kahveFiyati = Convert.ToDouble(numUpDownKahve.Value) * kahveFiyatlari[i] * katsayilar[2];
                        string eklenecekUrunKahve = $"{kahveAdet} adet {kahveler[i]} + {kahveFiyati} TL";
                        listBox1.Items.Add(eklenecekUrunKahve);

                        fiyatlar.Add(kahveFiyati);
                        FormClear();

                    }

                }
                for (int i = 0; i < cmbSicakİcecek.Items.Count; i++)
                {
                  
                    if (cmbSicakİcecek.SelectedIndex == i && sicakAdet > 0)
                    {
                        double sicakFiyati = Convert.ToDouble(numUpDownSicak.Value) * sicakFiyatlari[i];
                        string eklenecekUrunSicak = $"{sicakAdet} adet {sicakIcecekler[i]} + {sicakFiyati} TL";
                        listBox1.Items.Add(eklenecekUrunSicak);
                        
                        fiyatlar.Add(sicakFiyati);
                        FormClear();


                    }
                }
                for (int i = 0; i < cmbSogukIcecek.Items.Count; i++)
                {
                    
                    if (cmbSogukIcecek.SelectedIndex==i &&sogukAdet>0)
                    {
                        double sogukfiyati = Convert.ToDouble(numUpDOwnSoguk.Value) * sogukFiyatlari[i];
                        string eklenecekUrunSoguk = $"{sogukAdet} adet {sogukIcecekler[i]} + {sogukfiyati} TL";
                        listBox1.Items.Add(eklenecekUrunSoguk);
                     
                        fiyatlar.Add(sogukfiyati);
                        FormClear();

                    }

                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
          


        }

        private void btnToplam_Click(object sender, EventArgs e)
        {

            for (int i = 0; i < fiyatlar.Count; i++)
            {
                toplamFiyat += fiyatlar[i];
                lblToplamTutar.Text = $"Toplam Sipariş Tutarı: {toplamFiyat} TL";
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show($"{lblToplamTutar.Text}");
        }

        private void btnYenile_Click(object sender, EventArgs e)
        {
            double tutar = Convert.ToDouble(lblToplamTutar.Text);
            tutar = 0;
        }







        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }


    }
}
