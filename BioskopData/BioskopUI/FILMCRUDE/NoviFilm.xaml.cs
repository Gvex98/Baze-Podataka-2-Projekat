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
using BioskopData;

namespace BioskopUI
{
    /// <summary>
    /// Interaction logic for NoviFilm.xaml
    /// </summary>
    public partial class NoviFilm : Window
    {
        public NoviFilm()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int idnumber;
            int trajanje;
            if (ID.Text.Equals(""))
            {
                error.Content = "Morate uneti ID filma!";
                error.Visibility = Visibility.Visible;
                return;
            }else
            {
                
               
                bool idisnumber=Int32.TryParse(ID.Text, out idnumber);
                if(!idisnumber)
                {
                   error.Content = "ID mora biti broj";
                    error.Visibility = Visibility.Visible;
                    return;

                }
                else if(idnumber<0)
                {
                    error.Content = "ID treba biti pozitivan broj!";
                    error.Visibility = Visibility.Visible;
                    return;
                }
                else
                {

                }
            }
            if(Naziv.Text.Equals(""))
            {
                error.Content = "Morate uneti naziv filma!";
                error.Visibility = Visibility.Visible;
                return;
            }
            if(Zanr.Text.Equals(""))
            {
                error.Content = "Morate uneti zanr filma!";
                error.Visibility = Visibility.Visible;
                return;
            }
            if (Trajanje.Text.Equals(""))
            {
                error.Content = "Morate uneti trajanje filma!";
                error.Visibility = Visibility.Visible;
                return;
            }
            else
            {

                
                bool trajanjeisnumber = Int32.TryParse(Trajanje.Text, out trajanje);
                if (!trajanjeisnumber)
                {
                    error.Content = "Duzina trajanja mora biti broj";
                    error.Visibility = Visibility.Visible;
                    return;
                }
                else if (trajanje < 0)
                {
                    error.Content = "Duzina trajanja treba biti pozitivan broj!";
                    error.Visibility = Visibility.Visible;
                    return;
                }
                else
                {

                }
            }

            foreach(Film f in Data.filmovi)
            {
                if(f.Id==idnumber)
                {
                    error.Content = "Film sa ovim ID vec postoji!";
                    error.Visibility = Visibility.Visible;
                    return;
                }
            }


            error.Visibility = Visibility.Hidden;
            Film movie = new Film();
            movie.Id = idnumber;
            movie.Naziv = Naziv.Text;
            movie.Zanr = Zanr.Text;
            movie.DuzinaTrajanja = trajanje;

            Data.filmovi.Add(movie);

            using (var db = new ADONETBioskopContainer())
            {
                
                db.Films.Add(movie);
                db.SaveChanges();
            }

            

            this.Close();
            

            Console.WriteLine("a");
        }
    }
}
