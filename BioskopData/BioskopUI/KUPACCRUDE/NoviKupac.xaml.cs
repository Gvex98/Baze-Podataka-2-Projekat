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
    /// Interaction logic for NoviKupac.xaml
    /// </summary>
    public partial class NoviKupac : Window
    {
        public NoviKupac()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int id;
            bool isnumber = Int32.TryParse(Id.Text, out id);
            if (Id.Text.Equals(""))
            {
                error.Content = "Morate uneti ID!";
                error.Visibility = Visibility.Visible;
                return;
            }else
            {
               
                if (!isnumber)
                {
                    error.Content = "ID mora biti broj!";
                    error.Visibility = Visibility.Visible;
                    return;
                }else if(id<0)
                {
                    error.Content = "ID treba biti pozitivan!";
                    error.Visibility = Visibility.Visible;
                    return;
                }
                else
                {

                }
            }

            if(Ime.Text.Equals(""))
            {
                error.Content = "Morate uneti ime!";
                error.Visibility = Visibility.Visible;
                return;
            }else
            
            if(Prezime.Text.Equals(""))
            {
                error.Content = "Morate uneti prezime!";
                error.Visibility = Visibility.Visible;
                return;
            }

            foreach(Kupac ku in Data.kupci)
            {
                if(ku.Id==id)
                {
                    error.Content = "Kupac sa ovim ID-jem postoji!";
                    error.Visibility = Visibility.Visible;
                    return;
                }
            }


            Kupac k = new Kupac();
            k.Id = id;
            k.Ime = Ime.Text;
            k.Prezime = Prezime.Text;

            Data.kupci.Add(k);

            using (var db = new ADONETBioskopContainer())
            {
                db.Kupacs.Add(k);
                db.SaveChanges();
            }


            this.Close();
        }
    }
}
