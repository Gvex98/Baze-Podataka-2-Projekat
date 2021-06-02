using BioskopData;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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
    /// Interaction logic for EditFilm.xaml
    /// </summary>
    public partial class EditFilm : Window
    {
        public EditFilm()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int Oldid;
            int idnumber;
            int trajanje;
           
            if (Naziv.Text.Equals(""))
            {
                error.Content = "Morate uneti naziv filma!";
                error.Visibility = Visibility.Visible;
                return;
            }
            if (Zanr.Text.Equals(""))
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
            Oldid = Int32.Parse(oldid.Text);
            error.Visibility = Visibility.Hidden;




            


            Film movie = new Film();
            movie.Id = Oldid;
            movie.Naziv = Naziv.Text;
            movie.Zanr = Zanr.Text;
            movie.DuzinaTrajanja = trajanje;
            int poz;
            for(int i=0;i<Data.filmovi.Count;i++)
            {
                if(Data.filmovi[i].Id==Oldid)
                {
                    Data.filmovi[i] = movie;
                    poz = i;
                }
            }

            
            using (var db = new ADONETBioskopContainer())
            {
                var entity = db.Films.FirstOrDefault(x => x.Id == Oldid);
                
                entity.Naziv = movie.Naziv;
                entity.Zanr = movie.Zanr;
                entity.DuzinaTrajanja = movie.DuzinaTrajanja;

                
                db.SaveChanges();

                //var projections = db.Projekcijas.Where(x => x.FilmId == Oldid);
                for (int i= 0;i < Data.projekcije.Count;i++)
                {
                    if(Data.projekcije[i].FilmId==movie.Id)
                    {
                        Projekcija pro = Data.projekcije[i];

                        pro.Kraj = pro.Pocetak.AddMinutes(movie.DuzinaTrajanja);
                        Data.projekcije[i] = pro;
                    }
                    
                }
                db.SaveChanges();
            }



            

            this.Close();


            Console.WriteLine("a");
        }
    }
}
