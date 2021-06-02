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
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Linq;
using System.Data.Entity;

namespace BioskopUI
{
    /// <summary>
    /// Interaction logic for Filmovi.xaml
    /// </summary>
    public partial class Filmovi : Window
    {
        public Filmovi()
        {
            InitializeComponent();
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NoviFilm novifile = new NoviFilm();
            novifile.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Film film = MovieGrid.SelectedItem as Film;
            
            using (var db = new ADONETBioskopContainer())
            {
                var projtodelete = db.Projekcijas.Where(s => s.FilmId == film.Id).ToList();

                foreach(Projekcija pr in projtodelete)
                {
                    
                    db.Projekcijas.Remove(pr);
                    db.SaveChanges();
                    for (int i = 0; i < Data.projekcije.Count; i++)
                    {
                        if (Data.projekcije[i].Id == pr.Id)
                        {
                            Data.projekcije.RemoveAt(i);
                        }
                }

                }
                
                

                if (Data.filmovi.Contains(film))
                {
                    db.Films.Attach(film);
                    db.Films.Remove(film);
                    db.SaveChanges();
                    
                    Data.filmovi.Remove(film);
                }
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            int oldid;
            Film film = MovieGrid.SelectedItem as Film;
            oldid = film.Id;
            EditFilm ef = new EditFilm();
            //ef.ID.Text = film.Id.ToString();
            ef.Naziv.Text = film.Naziv;
            ef.Zanr.Text = film.Zanr;
            ef.Trajanje.Text = film.DuzinaTrajanja.ToString();
            ef.oldid.Text = oldid.ToString();
            ef.Show();

        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
