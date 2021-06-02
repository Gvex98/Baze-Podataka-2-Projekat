using BioskopData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Linq;
using System.Data.Entity;

namespace BioskopUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            bindmovies();
            bindbuyers();
            bindsale();
            bindprojektors();
            bindprojekcije();
            bindworkers();
            bindtickets();
            bindosposobljeni();
            bindodrzavaju();
            Console.WriteLine("a");
        }

        private void Filmovi_Click(object sender, RoutedEventArgs e)
        {
            Filmovi filmscreen = new Filmovi();
            filmscreen.Show();
        }
        public static void bindmovies()
        {
            using (var db = new ADONETBioskopContainer())
            {

                var movies = db.Films;

                foreach (Film f in movies)
                {
                    Data.filmovi.Add(f);
                }
            }
        }
        public static void bindbuyers()
        {
            using(var db=new ADONETBioskopContainer())
            {
                var buyers = db.Kupacs;
                foreach(Kupac k in buyers)
                {
                    Data.kupci.Add(k);
                }
            }
        }

        private void Kupci_Click(object sender, RoutedEventArgs e)
        {
            KupciMain kup = new KupciMain();
            kup.Show();
        }

        public static void bindsale()
        {
            using (var db = new ADONETBioskopContainer())
            {
                var sale = db.Salas;
                foreach(Sala s in sale)
                {
                    Data.sale.Add(s);
                }
            }
        }

        private void Sale_Click(object sender, RoutedEventArgs e)
        {
            SaleMain sm = new SaleMain();
            sm.Show();
        }

        public static void bindprojektors()
        {

            using (var db = new ADONETBioskopContainer())
            {
                //var entity;
                //
                var projektori = db.Projektors.Include(f => f.Sala).ToList();
                
                for(int i=0;i<projektori.Count();i++)
                {
                    Projektor p = new Projektor();
                    p.Id = projektori[i].Id;
                    p.Model = projektori[i].Model;
                    p.Cena = projektori[i].Cena;
                    if(projektori[i].Sala!=null)
                    {
                        //p.Sala_Broj
                        p.Sala = projektori[i].Sala;
                    }
                    
                    p.Sala = projektori[i].Sala;
                    Console.WriteLine("");
                    Data.projektori.Add(p);
                }

                
            }
        }

        private void Projektori_Click(object sender, RoutedEventArgs e)
        {
            ProjektorMain pm = new ProjektorMain();

            
           
            pm.Show();
        }

        private static void bindprojekcije()
        {
            using (var db = new ADONETBioskopContainer())
            {
                var projekcije = db.Projekcijas.Include(f => f.Film).Include(f => f.Sala).ToList();
                for(int i=0;i<projekcije.Count;i++)
                {
                    Projekcija p = new Projekcija();
                    p.Id = projekcije[i].Id;
                    p.Pocetak = projekcije[i].Pocetak;
                    p.Kraj = projekcije[i].Kraj;
                    p.FilmId = projekcije[i].FilmId;
                    p.SalaBroj = projekcije[i].SalaBroj;
                    Data.projekcije.Add(p);
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ProjekcijeMain pm = new ProjekcijeMain();
            pm.Show();
        }

        public static void bindworkers()
        {
            using (var db = new ADONETBioskopContainer())
            {
                
                var radnici = db.Radniks.ToList();

                for (int i = 0; i < radnici.Count(); i++)
                {
                    Radnik r = new Radnik();
                    r.JMBG = radnici[i].JMBG;
                    r.Ime = radnici[i].Ime;
                    r.Prezime = radnici[i].Prezime;
                    r.Plata = radnici[i].Plata;
                   
                    
                    Data.radnici.Add(r);
                }


            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            RadniciMain rm = new RadniciMain();
            rm.Show();
        }

        
        public static void bindtickets()
        {
            using (var db = new ADONETBioskopContainer())
            {
                var karte = db.Kartas.Include(k => k.Kupac).Include(k=>k.Projekcija).Include(k=>k.Prodavac).ToList();
                for (int i = 0; i < karte.Count(); i++)
                {
                    Karta k = new Karta();
                    Projekcija p = new Projekcija();
                    Kupac kup = new Kupac();
                    Prodavac prod = new Prodavac();


                    k.Id = karte[i].Id;


                    k.BrojSedista = karte[i].BrojSedista;
                    k.Cena = karte[i].Cena;

                    k.Projekcija = karte[i].Projekcija;
                    k.Kupac = karte[i].Kupac;
                    k.Prodavac = karte[i].Prodavac;
                    k.ProjekcijaId = karte[i].Projekcija.Id;
                    if(karte[i].Prodavac!=null)
                    {
                        k.ProdavacJMBG = karte[i].Prodavac.JMBG;
                    }
                    
                    k.KupacId = karte[i].Kupac.Id;
                    
                    
                    
                    
                    Data.karte.Add(k);
                }
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            KartaMain km = new KartaMain();
            km.Show();
        }
        public static void bindprojectants()
        {
            using (var db = new ADONETBioskopContainer())
            {
                
            }
        }

        public static void bindosposobljeni()
        {
            using (var db = new ADONETBioskopContainer())
            {
                var osposobljeni = db.Osposobljens.Include(k => k.Projektor).Include(k => k.Projektant).ToList();
                for(int i=0;i<osposobljeni.Count;i++)
                {
                    Osposobljen o = new Osposobljen();
                    o.Projektant = osposobljeni[i].Projektant;
                    o.Projektor = osposobljeni[i].Projektor;
                    o.ProjektorId = osposobljeni[i].ProjektorId;
                    o.ProjektantJMBG = osposobljeni[i].ProjektantJMBG;
                    Data.osposobljeni.Add(o);
                }
            }
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            ProjektantRadiMain prm = new ProjektantRadiMain();
            prm.Show();
        }

        public static void bindodrzavaju()
        {
            using (var db = new ADONETBioskopContainer())
            {
                var odrazavaju = db.Odrzavas.Include(k => k.Domar).Include(k => k.Sala).ToList();
                for(int i=0;i<odrazavaju.Count;i++)
                {
                    Odrzava o = new Odrzava();
                    o.Domar = odrazavaju[i].Domar;
                    o.DomarJMBG = odrazavaju[i].DomarJMBG;
                    o.Sala = odrazavaju[i].Sala;
                    o.SalaBroj = odrazavaju[i].SalaBroj;

                    Data.odrzavaju.Add(o);
                }
            }
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            OdrzavaMain om = new OdrzavaMain();
            om.Show();
        }
    }

}
