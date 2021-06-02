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
    /// Interaction logic for RadnikNew.xaml
    /// </summary>
    public partial class RadnikNew : Window
    {
        public RadnikNew()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int plata;
            string role = "";

            if(Ime.Text.Equals(""))
            {
                error.Content = "Morate uneti ime radnika!";
                error.Visibility = Visibility.Visible;
                return;
            }
            if(Prezime.Text.Equals(""))
            {
                error.Content = "Morate uneti prezime radnika!";
                error.Visibility = Visibility.Visible;
                return;
            }
            if(Plata.Text.Equals(""))
            {
                error.Content = "Morate uneti platu radnika!";
                error.Visibility = Visibility.Visible;
                return;
            }else
            {
                bool plataisnumber = Int32.TryParse(Plata.Text, out plata);
                if(!plataisnumber)
                {
                    error.Content = "Plata treba biti broj!";
                    error.Visibility = Visibility.Visible;
                }else
                {
                    if(plata<0)
                    {
                        error.Content = "Plata treba biti pozitivan broj!";
                        error.Visibility = Visibility.Visible;
                        return;
                    }
                }
            }

            role = combbox.Text;
            if(role.Equals("Prodavac"))
            {
                Prodavac rad = new Prodavac();
                rad.Ime = Ime.Text;
                rad.Prezime = Prezime.Text;
                rad.Plata = plata;
               

                using (var db = new ADONETBioskopContainer())
                {
                    db.Radniks.Add(rad);

                    db.SaveChanges();
                    Data.radnici.Add(rad);

                }
                
            } else if(role.Equals("Projektant"))
            {
                Projektant projektant = new Projektant();
                projektant.Ime = Ime.Text;
                projektant.Prezime = Prezime.Text;
                projektant.Plata = plata;
               
                using (var db = new ADONETBioskopContainer())
                {
                    db.Radniks.Add(projektant);

                    db.SaveChanges();
                    Data.radnici.Add(projektant);

                }
            } else
            {
                Domar dom = new Domar();
                dom.Ime = Ime.Text;
                dom.Prezime = Prezime.Text;
                dom.Plata = plata;
                
                using (var db = new ADONETBioskopContainer())
                {
                    db.Radniks.Add(dom);

                    db.SaveChanges();
                    Data.radnici.Add(dom);

                }
            }


            this.Close();

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
