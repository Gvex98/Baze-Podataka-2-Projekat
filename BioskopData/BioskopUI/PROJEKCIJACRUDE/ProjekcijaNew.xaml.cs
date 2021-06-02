using BioskopData;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
    /// Interaction logic for ProjekcijaNew.xaml
    /// </summary>
    public partial class ProjekcijaNew : Window
    {
        public ProjekcijaNew()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int brSale;
            int FilmID;
            bool salaexists = false;
            bool filmexists = false;
            DateTime vreme;
            if (Broj_sale.Text.Equals(""))
            {
                error.Content = "Morate uneti broj sale!";
                error.Visibility = Visibility.Visible;
                return;
            } else
            {
                bool brsaleisnumber = Int32.TryParse(Broj_sale.Text, out brSale);
                if (!brsaleisnumber)
                {
                    error.Content = "Broj sale treba biti broj!";
                    error.Visibility = Visibility.Visible;
                    return;
                } else
                {
                    if (brSale < 0)
                    {
                        error.Content = "Broj sale treba biti pozitivan!";
                        error.Visibility = Visibility.Visible;
                        return;
                    } else
                    {
                        foreach (Sala s in Data.sale)
                        {
                            if (s.Broj == brSale)
                            {
                                salaexists = true;
                            }
                        }
                        if (!salaexists)
                        {
                            error.Content = "Sala sa tim brojem ne postoji!";
                            error.Visibility = Visibility.Visible;
                            return;
                        }
                    }

                }
            }


            if (IDfilma.Text.Equals(""))
            {
                error.Content = "Morate uneti ID filma!";
                error.Visibility = Visibility.Visible;
                return;
            }
            else
            {
                bool filmidisnumber = Int32.TryParse(IDfilma.Text, out FilmID);
                if (!filmidisnumber)
                {
                    error.Content = "ID filma mora biti broj!";
                    error.Visibility = Visibility.Visible;
                    return;
                }
                else
                {
                    if (FilmID < 0)
                    {
                        error.Content = "ID filma treba biti pozitivan!";
                        error.Visibility = Visibility.Visible;
                        return;
                    }
                    else
                    {
                        foreach (Film f in Data.filmovi)
                        {
                            if (f.Id == FilmID)
                            {
                                filmexists = true;
                            }
                        }
                        if (!filmexists)
                        {
                            error.Content = "Film sa tim IDjem ne postoji!";
                            error.Visibility = Visibility.Visible;
                            return;
                        }
                    }

                }
            }


            if (Pocetak.Text.Equals(""))
            {
                error.Content = "Morate uneti vreme pocetka!";
                error.Visibility = Visibility.Visible;
                return;
            } else
            {
                bool validstart = DateTime.TryParse(Pocetak.Text, out vreme);
                if(!validstart)
                {
                    error.Content = "Vreme pocetka nije validno";
                    error.Visibility = Visibility.Visible;
                    return;
                }
            }

            Projekcija p = new Projekcija();
            p.Id = FilmID;

            p.Pocetak = vreme.ToUniversalTime();
            
            p.SalaBroj = brSale;


            using (var db = new ADONETBioskopContainer())
            {
                var film = db.Films.Where(mov => mov.Id == FilmID).FirstOrDefault();
                var sala = db.Salas.Where(sal => sal.Broj == brSale).FirstOrDefault();

                p.Film = film;
                p.Sala = sala;
                p.Kraj = p.Pocetak.AddMinutes(p.Film.DuzinaTrajanja);
                db.Projekcijas.Add(p);
                Data.projekcije.Add(p);
                db.SaveChanges();
            }




            this.Close();
        }
    }
}
