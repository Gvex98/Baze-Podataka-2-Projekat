using BioskopData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace BioskopUI
{
    /// <summary>
    /// Interaction logic for KartaMain.xaml
    /// </summary>
    public partial class KartaMain : Window
    {
        public KartaMain()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            KartaNew kn = new KartaNew();
            kn.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Karta karta = KartaData.SelectedItem as Karta;

            using (var db = new ADONETBioskopContainer())
            {
                if(Data.karte.Contains(karta))
                {
                    db.Kartas.Attach(karta);
                    db.Kartas.Remove(karta);
                    db.SaveChanges();
                    Data.karte.Remove(karta);
                }
            }

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Karta karta = KartaData.SelectedItem as Karta;
            KartaEdit ke = new KartaEdit();
            ke.IDProj.Text = karta.ProjekcijaId.ToString();
            ke.JMBGKupca.Text = karta.KupacId.ToString();
            ke.Sediste.Text = karta.BrojSedista.ToString() ;
            ke.Cena.Text = karta.Cena.ToString();
            ke.oldticketid.Content = karta.Id.ToString();
            ke.JMBGProdavca.Text = karta.ProdavacJMBG.ToString();
            ke.Show();
        }
    }
}
