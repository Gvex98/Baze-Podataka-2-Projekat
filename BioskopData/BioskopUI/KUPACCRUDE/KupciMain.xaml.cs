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
    /// Interaction logic for KupciMain.xaml
    /// </summary>
    public partial class KupciMain : Window
    {
        public KupciMain()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NoviKupac nk = new NoviKupac();
            nk.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Kupac kup = BuyersGrid.SelectedItem as Kupac;

            KupciEdit kupedit = new KupciEdit();
            kupedit.Ime.Text = kup.Ime;
            kupedit.Prezime.Text = kup.Prezime;
            kupedit.oldid.Text = kup.Id.ToString();
            kupedit.Show();


        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Kupac kup = BuyersGrid.SelectedItem as Kupac;

            using (var db = new ADONETBioskopContainer())
            {
                if (Data.kupci.Contains(kup))
                {
                    db.Kupacs.Attach(kup);
                    db.Kupacs.Remove(kup);
                    db.SaveChanges();
                    Data.kupci.Remove(kup);
                }
            }
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
