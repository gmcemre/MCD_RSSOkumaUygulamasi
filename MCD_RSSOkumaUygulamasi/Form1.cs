using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace MCD_RSSOkumaUygulamasi
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btn_getir_Click(object sender, EventArgs e)
        {
            List<Haber> Kayitlar = XMLCevir();
            lst_baslik.DataSource = Kayitlar;
        }

        private List<Haber> XMLCevir()
        {
            List<Haber> HaberKayitlari = new List<Haber>();

            XDocument XML_Kaynak = XDocument.Load(txt_rssurl.Text);
            List<XElement> Rows = XML_Kaynak.Descendants("item").ToList();

            foreach (XElement item in Rows)
            {
                Haber temp = new Haber();
                temp.Baslik = item.Element("title").Value;
                temp.Link = item.Element("link").Value;
                temp.Aciklama = item.Element("description").Value;
                HaberKayitlari.Add(temp);
            }
            return HaberKayitlari;
        }

        private void lst_baslik_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListBox SecilenDeger = (ListBox)sender;
            Haber SecilenHaber = (Haber)SecilenDeger.SelectedItem;
            web_browser.DocumentText = SecilenHaber.Aciklama;
        }
    }
}
