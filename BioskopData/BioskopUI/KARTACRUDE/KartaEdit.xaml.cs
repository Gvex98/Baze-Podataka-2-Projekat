using BioskopData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
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
    /// Interaction logic for KartaEdit.xaml
    /// </summary>
    public partial class KartaEdit : Window
    {
        public KartaEdit()
        {
            InitializeComponent();
        }

        
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            int ticketid;
            int idproj;
            int jmbg;
            int cena;
            int sediste;
            int jmbgprodavaca;
            int? prodj;
            Kupac kup = new Kupac();
            Projekcija proj = new Projekcija();
            Prodavac prod = null;
            prodj = null;
            ticketid = Int32.Parse(oldticketid.Content.ToString());
            if (IDProj.Text.Equals(""))
            {
                error.Content = "Morate uneti ID projekcije!";
                error.Visibility = Visibility.Visible;
                return;
            }
            else
            {
                bool idprojisnumber = Int32.TryParse(IDProj.Text, out idproj);
                if (!idprojisnumber)
                {
                    error.Content = "IDProjekcije mora biti broj!";
                    error.Visibility = Visibility.Visible;
                    return;
                }
                else
                {
                    if (idproj < 0)
                    {
                        error.Content = "IDProjekcije treba biti pozitivan!";
                        error.Visibility = Visibility.Visible;
                        return;
                    }
                    else
                    {
                        bool projexists = false;
                        foreach (Projekcija p in Data.projekcije)
                        {
                            if (p.Id == idproj)
                            {
                                projexists = true;
                                proj = p;

                            }
                        }
                        if (!projexists)
                        {
                            error.Content = "Ne postoji projekcija sa tim IDjem!";
                            error.Visibility = Visibility.Visible;
                            return;
                        }
                    }
                }
            }


            if (JMBGKupca.Text.Equals(""))
            {
                error.Content = "Morate uneti ID kupca!";
                error.Visibility = Visibility.Visible;
                return;
            }
            else
            {
                bool jmbgkupcaisnumber = Int32.TryParse(JMBGKupca.Text, out jmbg);
                if (!jmbgkupcaisnumber)
                {
                    error.Content = "ID kupca mora biti broj!";
                    error.Visibility = Visibility.Visible;
                    return;
                }
                else
                {
                    if (jmbg < 0)
                    {
                        error.Content = "ID mora treba pozitivan!";
                        error.Visibility = Visibility.Visible;
                        return;
                    }
                    else
                    {
                        bool kupacexists = false;
                        foreach (Kupac k in Data.kupci)
                        {
                            if (k.Id == jmbg)
                            {
                                kupacexists = true;
                                kup = k;
                            }
                        }
                        if (!kupacexists)
                        {
                            error.Content = "Ne postoji kupac sa tim IDjem!";
                            error.Visibility = Visibility.Visible;
                            return;
                        }
                    }
                }
            }



            if (Cena.Text.Equals(""))
            {
                error.Content = "Morate uneti cenu karte!";
                error.Visibility = Visibility.Visible;
                return;
            }
            else
            {
                bool cenakarteisnumber = Int32.TryParse(Cena.Text, out cena);
                if (!cenakarteisnumber)
                {
                    error.Content = "Cena karte mora biti broj!";
                    error.Visibility = Visibility.Visible;
                    return;
                }
                else
                {
                    if (cena < 0)
                    {
                        error.Content = "Cena karte mora treba pozitivan!";
                        error.Visibility = Visibility.Visible;
                        return;
                    }
                }
            }

            if (Sediste.Text.Equals(""))
            {
                error.Content = "Morate uneti sediste karte!";
                error.Visibility = Visibility.Visible;
                return;
            }
            else
            {
                bool sedisteisnumber = Int32.TryParse(Sediste.Text, out sediste);
                if (!sedisteisnumber)
                {
                    error.Content = "Sediste mora biti broj!";
                    error.Visibility = Visibility.Visible;
                    return;
                }
                else
                {
                    if (sediste < 0)
                    {
                        error.Content = "Sediste karte mora treba pozitivan!";
                        error.Visibility = Visibility.Visible;
                        return;
                    }
                }
            }

            if (JMBGProdavca.Text.Equals(""))
            {

            }
            else
            {
                bool jmbgprodavacaisnumber = Int32.TryParse(JMBGProdavca.Text, out jmbgprodavaca);
                if (!jmbgprodavacaisnumber)
                {
                    error.Content = "JMBG prodavaca mora biti broj!";
                    error.Visibility = Visibility.Visible;
                    return;
                }
                else
                {
                    if (jmbgprodavaca < 0)
                    {
                        error.Content = "JMBG prodavaca treba biti pozitivan!";
                        error.Visibility = Visibility.Visible;
                        return;
                    }
                    else
                    {

                        using (var db = new ADONETBioskopContainer())
                        {
                            var x = db.Radniks.OfType<Prodavac>().Where(r => r.JMBG == jmbgprodavaca).ToList();


                            if (x.Count == 0)
                            {
                                error.Content = "Ne postoji prodavac tog JMBG-a!";
                                error.Visibility = Visibility.Visible;
                                return;
                            }
                            else
                            {
                                prod = x[0];
                                prodj = x[0].JMBG;
                            }



                        }

                    }
                }
            }


           

            using (var db = new ADONETBioskopContainer())
            {


                var entity = db.Kartas.FirstOrDefault(x => x.Id == ticketid);
                entity.Cena = cena;
                entity.BrojSedista = sediste;
                entity.Prodavac = prod;
                entity.Projekcija = proj;
                entity.Kupac = kup;
                entity.ProdavacJMBG = prodj;
                




                Karta ka = new Karta();
                
               
                
                
                
                db.Projekcijas.Attach(entity.Projekcija);
                db.Kupacs.Attach(entity.Kupac);
                if(entity.Prodavac!=null)
                {
                    db.Radniks.Attach(entity.Prodavac);
                }
                


                
                db.SaveChanges();
                for(int i=0;i<Data.karte.Count;i++)
                {
                    if(Data.karte[i].Id==ticketid)
                    {
                        Data.karte[i] = entity;
                    }
                }
            }


            this.Close();
        }
    }
}
