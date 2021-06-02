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
    /// Interaction logic for ProjektorMain.xaml
    /// </summary>
    public partial class ProjektorMain : Window
    {
        public ProjektorMain()
        {
            InitializeComponent();
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ProjektorNew pn = new ProjektorNew();
            pn.Show();

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Projektor proj = ProjektorData.SelectedItem as Projektor;

            using (var db = new ADONETBioskopContainer())
            {
                if (Data.projektori.Contains(proj))
                {
                    db.Projektors.Attach(proj);

                    var projektor = db.Projektors.Where(eee => eee.Id == proj.Id).FirstOrDefault();
                    if (projektor != null)
                    {

                        Data.projektori.Remove(proj);

                        db.SaveChanges();
                    }




                    db.Projektors.Remove(proj);
                    db.SaveChanges();
                    
                }
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            Projektor proj = ProjektorData.SelectedItem as Projektor;
            ProjektorEdit pe = new ProjektorEdit();
            pe.Cena.Text = proj.Cena.ToString();
            pe.Model.Text = proj.Model.ToString();
            //proj.Sala_Broj
            if(proj.Sala!=null)
            {
                pe.Broj_sale.Text = proj.Sala.Broj.ToString();
            }else
            {
                pe.Broj_sale.Text = "";
            }
            
            pe.id.Content = proj.Id.ToString();
            pe.Show();

        }
    }
}
