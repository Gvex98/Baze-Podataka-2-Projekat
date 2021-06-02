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
    /// Interaction logic for ProjekcijeMain.xaml
    /// </summary>
    public partial class ProjekcijeMain : Window
    {
        public ProjekcijeMain()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ProjekcijaNew pn = new ProjekcijaNew();
            pn.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Projekcija proj = ProjekcijaData.SelectedItem as Projekcija;

            using (var db = new ADONETBioskopContainer())
            {
                if (Data.projekcije.Contains(proj))
                {
                    db.Projekcijas.Attach(proj);

                    var projekcija = db.Projekcijas.Where(eee => eee.Id == proj.Id).FirstOrDefault();
                    if (projekcija != null)
                    {

                        Data.projekcije.Remove(proj);

                        db.SaveChanges();
                    }




                    db.Projekcijas.Remove(proj);
                    db.SaveChanges();

                }
            }
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            Projekcija proj = ProjekcijaData.SelectedItem as Projekcija;



            ProjekcijaEdit pe = new ProjekcijaEdit();
            pe.ID.Content = proj.Id.ToString();

            pe.Pocetak.Text = proj.Pocetak.ToString();
            pe.IDfilma.Text = proj.FilmId.ToString();
            pe.Broj_sale.Text = proj.SalaBroj.ToString();

            pe.Show();
        }
    }
}
