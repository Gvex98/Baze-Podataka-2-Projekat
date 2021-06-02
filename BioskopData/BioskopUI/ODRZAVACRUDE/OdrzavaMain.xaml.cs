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
    /// Interaction logic for OdrzavaMain.xaml
    /// </summary>
    public partial class OdrzavaMain : Window
    {
        public OdrzavaMain()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            OdrzavaNew on = new OdrzavaNew();
            on.Show();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Odrzava odrzava = OdrzavaGrid.SelectedItem as Odrzava;

            using (var db = new ADONETBioskopContainer())
            {
                if (Data.odrzavaju.Contains(odrzava))
                {
                    db.Odrzavas.Attach(odrzava);
                    db.Odrzavas.Remove(odrzava);
                    db.SaveChanges();
                    Data.odrzavaju.Remove(odrzava);
                }
            }
        }
    }
}
