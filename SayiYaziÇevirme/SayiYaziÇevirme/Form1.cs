/****************************************************************************
** SAKARYA ÜNİVERSİTESİ
** BİLGİSAYAR VE BİLİŞİM BİLİMLERİ FAKÜLTESİ
** BİLGİSAYAR MÜHENDİSLİĞİ BÖLÜMÜ
** NESNEYE DAYALI PROGRAMLAMA DERSİ
** 2021-2022 BAHAR DÖNEMİ
**
** ÖDEV NUMARASI..........:2
** ÖĞRENCİ ADI............:MERT ESER MERAL
** ÖĞRENCİ NUMARASI.......:G211210047
** DERSİN ALINDIĞI GRUP...:2-B
****************************************************************************/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SayiYaziÇevirme
{



    public partial class Form1 : Form
    {


        public Form1()
        {
            InitializeComponent();
           
            Label lbl = new Label(); //label tasarim kodlari.
            lbl.Text = "Okunusu:";
            lbl.Location = new Point(100, 140);
            lbl.Name = "lblOkunus";
            lbl.Size = new Size(55, 23);
            this.Controls.Add(lbl);

            Label lbl2 = new Label(); //label tasarim kodlari.
            lbl2.Text = "Girilen Sayi:";
            lbl2.Name = "lblSayi";
            lbl2.Location = new Point(100, 85);
            lbl2.Size = new Size(65, 29);
            this.Controls.Add(lbl2);

            Label lbl3 = new Label(); //label tasarim kodlari.
            lbl3.BorderStyle = BorderStyle.Fixed3D;
            lbl3.Name = "lblYazi";
            lbl3.Location = new Point(217, 134);
            lbl3.Size = new Size(370, 29);
            this.Controls.Add(lbl3);

            TextBox txt = new TextBox(); //textbox tasarim kodlari
            txt.Location = new Point(217, 85);
            txt.Name = "txtSayi";
            txt.Size = new Size(370, 22);
            this.Controls.Add(txt);
            txt.KeyPress += Txt_KeyPress;

            Button btn = new Button(); //buton tasarim kodlari 
            btn.Name = "btnHesapla";
            btn.Text = "HESAPLA";
            btn.Size = new Size(97, 60);
            btn.Location = new Point(311, 192);
            this.Controls.Add(btn);
            btn.Click += new EventHandler(Yaziyacevir);


            void Yaziyacevir(object sender, EventArgs e) //girilen tutari yaziya ceviren fonksiyon.
            {
                string[] birler = { "", "BİR", "İKİ", "ÜÇ", "DÖRT", "BEŞ", "ALTI", "YEDİ", "SEKİZ", "DOKUZ" };
                string[] onlar = { "", "ON", "YİRMİ", "OTUZ", "KIRK", "ELLİ", "ALTMIŞ", "YETMİŞ", "SEKSEN", "DOKSAN" };
                string sayi = txt.Text.Replace(',', '.');
                char arama = '.';
                bool _bool = sayi.Contains(arama);
                int basamak = 0;
                if(sayi=="")//tutar girme uyarisi.
                MessageBox.Show("Lütfen bir tutar giriniz.");

                if (_bool == false&& sayi != "")//tutarda kurus yoksa girilen if blogu.
                {
                    
                    long sayi2 = Convert.ToInt64(sayi);
                    long bir = (sayi2 % 10);
                    long on = (sayi2 % 100) / 10;
                    long yüz = (sayi2 / 100) % 10;
                    long bin = (sayi2 / 1000) % 10;
                    long onbin = (sayi2 / 10000);
                    while (sayi2 > 0)//girilen tutarin basamagini hesaplama.
                    {
                        sayi2 /= 10;
                        basamak++;

                    }
                    if (basamak > 5 )//5 basamak siniri uyarisi.
                    MessageBox.Show("Gireceğiniz tutar en fazla 5 basamaklı olmalıdır!");
                    

                    if (basamak == 3) //3 basamakli tutarda girilen kisim.
                    {
                        if (yüz != 1)
                            lbl3.Text = birler[yüz] + "YÜZ" + onlar[on] + birler[bir] + "TL";
                        else
                            lbl3.Text = "YÜZ" + onlar[on] + birler[bir] + "TL"; //bir yüz yazmamasi için gereken kod.


                    }
                    else if (basamak == 4) //4 basamakli tutarda girilen kisim.
                    {
                        if (bin == 1) 
                        {
                            if (yüz == 0)
                                lbl3.Text = "BİN" + onlar[on] + birler[bir] + "TL";
                            else if (yüz == 1)
                                lbl3.Text = "BİN" + "YÜZ" + onlar[on] + birler[bir] + "TL";
                            else
                                lbl3.Text = "BİN" + birler[yüz] + "YÜZ" + onlar[on] + birler[bir] + "TL";







                        }
                        else //bir yüz ve sıfır oldugunda yüz yazmamasi icin gereken kisim.
                        {
                            if (yüz == 0)
                                lbl3.Text = birler[bin] + "BİN" + onlar[on] + birler[bir] + "TL";
                            else if (yüz == 1)
                                lbl3.Text = birler[bin] + "BİN" + "YÜZ" + onlar[on] + birler[bir] + "TL";
                            else
                                lbl3.Text = birler[bin] + "BİN" + birler[yüz] + "YÜZ" + onlar[on] + birler[bir] + "TL";

                        }


                    }
                    else if (basamak == 5)//5 basamakli.
                    {
                        if (yüz == 0)
                            lbl3.Text = onlar[onbin] + birler[bin] + "BİN" + onlar[on] + birler[bir] + "TL";
                        else if (yüz == 1)
                            lbl3.Text = onlar[onbin] + birler[bin] + "BİN" + "YÜZ" + onlar[on] + birler[bir] + "TL";
                        else
                            lbl3.Text = onlar[onbin] + birler[bin] + "BİN" + birler[yüz] + "YÜZ" + onlar[on] + birler[bir] + "TL";


                    }
                    else if(basamak<3) //1 ve 2 basamakli.
                        lbl3.Text = onlar[on] + birler[bir] + "TL";
                   

                }
                else if(_bool==true && sayi != "")//kuruşlu girilen tutarin girdigi if blogu.
                {
                    string sayi3 = string.Concat(sayi, "0");
                    string kurus = sayi3.Substring(sayi3.IndexOf('.') + 1, 2);
                    long sayi2 = Convert.ToInt64(sayi.Substring(0, sayi.IndexOf('.')));
                    int kurus2 = int.Parse(kurus);
                    int krsBir = (kurus2 % 10);
                    int krsOn = (kurus2 % 100) / 10;
                    long bir = (sayi2 % 10);
                    long on = (sayi2 % 100) / 10;
                    long yüz = (sayi2 / 100) % 10;
                    long bin = (sayi2 / 1000) % 10;
                    long onbin = (sayi2 / 10000);
                    if(sayi2==0)
                        lbl3.Text ="SIFIR"+"TL"+ onlar[krsOn] + birler[krsBir] + "KURUŞ";
                    while (sayi2 > 0) //basamak sayaci.
                    {
                        sayi2 /= 10;
                        basamak++;

                    }
                     if(basamak>5) //max 5 basamak uyarısı.
                        MessageBox.Show("Gireceğiniz tutar en fazla 5 basamaklı olmalıdır!");

                    if (basamak == 3) //3 basamakli tutar kismi.
                    {
                        if (yüz != 1)
                            lbl3.Text = birler[yüz] + "YÜZ" + onlar[on] + birler[bir] + "TL" + onlar[krsOn] + birler[krsBir] + "KURUŞ";
                        else
                            lbl3.Text = "YÜZ" + onlar[on] + birler[bir] + "TL" + onlar[krsOn] + birler[krsBir] + "KURUŞ";


                    }
                    else if (basamak == 4) //4 basamakli tutar kismi.
                    {
                        if (bin == 1)
                        {
                            if (yüz == 0)
                                lbl3.Text = "BİN" + onlar[on] + birler[bir] + "TL" + onlar[krsOn] + birler[krsBir] + "KURUŞ";
                            else if (yüz == 1)
                                lbl3.Text = "BİN" + "YÜZ" + onlar[on] + birler[bir] + "TL" + onlar[krsOn] + birler[krsBir] + "KURUŞ";
                            else
                                lbl3.Text = "BİN" + birler[yüz] + "YÜZ" + onlar[on] + birler[bir] + "TL" + onlar[krsOn] + birler[krsBir] + "KURUŞ";

                        }
                        else
                        {
                            if (yüz == 0)
                                lbl3.Text = birler[bin] + "BİN" + onlar[on] + birler[bir] + "TL" + onlar[krsOn] + birler[krsBir] + "KURUŞ";
                            else if (yüz == 1)
                                lbl3.Text = birler[bin] + "BİN" + "YÜZ" + onlar[on] + birler[bir] + "TL" + onlar[krsOn] + birler[krsBir] + "KURUŞ";
                            else
                                lbl3.Text = birler[bin] + "BİN" + birler[yüz] + "YÜZ" + onlar[on] + birler[bir] + "TL" + onlar[krsOn] + birler[krsBir] + "KURUŞ";

                        }


                    }
                    else if (basamak == 5) //5 basamaki tutar kismi.
                    {
                        if (yüz == 0)
                            lbl3.Text = onlar[onbin] + birler[bin] + "BİN" + onlar[on] + birler[bir] + "TL" + onlar[krsOn] + birler[krsBir] + "KURUŞ";
                        else if (yüz == 1)
                            lbl3.Text = onlar[onbin] + birler[bin] + "BİN" + "YÜZ" + onlar[on] + birler[bir] + "TL" + onlar[krsOn] + birler[krsBir] + "KURUŞ";
                        else
                            lbl3.Text = onlar[onbin] + birler[bin] + "BİN" + birler[yüz] + "YÜZ" + onlar[on] + birler[bir] + "TL" + onlar[krsOn] + birler[krsBir] + "KURUŞ";


                    }
                    else if(basamak <3&&basamak>0)
                        lbl3.Text = onlar[on] + birler[bir] + "TL" + onlar[krsOn] + birler[krsBir] + "KURUŞ";
                    


                }


            }

            
        }

        private void Txt_KeyPress(object sender, KeyPressEventArgs e)//textbox'a sadece rakam ve virgül girmemizi sağlayan kısım.
        {
            
            


            if ( (int)e.KeyChar<58 && (int)e.KeyChar>47)//sadece rakam girilebilir.
            {
                e.Handled = false;
            }
            else if((int)e.KeyChar==44 || (int)e.KeyChar==46||(int)e.KeyChar==8)//virgül ve nokta girilebilir ve yazılan silinebir.
                e.Handled = false;
            else
            {
                e.Handled = true;
            }



        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
            
        }




    }
    
}