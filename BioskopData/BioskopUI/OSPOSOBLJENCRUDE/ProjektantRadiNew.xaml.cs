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
    /// Interaction logic for ProjektantRadiNew.xaml
    /// </summary>
    public partial class ProjektantRadiNew : Window
    {
        public ProjektantRadiNew()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int jmbgprojektanta;
            int idprojektora;
            if(JMBGProj.Text.Equals(""))
            {
                error.Content = "Morate uneti JMBG projektanta!";
                error.Visibility = Visibility.Visible;
                return;
            }else
            {
                bool jmbgisnumber = Int32.TryParse(JMBGProj.Text, out jmbgprojektanta);
                if(!jmbgisnumber)
                {
                    error.Content = "JMBG mora biti broj!";
                    error.Visibility = Visibility.Visible;
                    return;
                }else
                {
                    if(jmbgprojektanta<0)
                    {
                        error.Content = "JMBG treba biti pozitivan!";
                        error.Visibility = Visibility.Visible;
                        return;
                    }
                    else
                    {
                        using (var db=new ADONETBioskopContainer())
                        {
                            var prodavci = db.Radniks.OfType<Projektant>().Where(x => x.JMBG == jmbgprojektanta).ToList();

                            if(prodavci.Count==0)
                            {
                                error.Content = "Ne postoji projektant sa tim JMBGom!";
                                error.Visibility = Visibility.Visible;
                                return;
                            }
                        }
                    }
                }
            }

            if (IDProj.Text.Equals(""))
            {
                error.Content = "Morate uneti ID projektora!";
                error.Visibility = Visibility.Visible;
                return;
            }
            else
            {
                bool idprojisnumber = Int32.TryParse(IDProj.Text, out idprojektora);
                if (!idprojisnumber)
                {
                    error.Content = "ID projektora mora biti broj!";
                    error.Visibility = Visibility.Visible;
                    return;
                }
                else
                {
                    if (idprojektora < 0)
                    {
                        error.Content = "ID projektora treba biti pozitivan!";
                        error.Visibility = Visibility.Visible;
                        return;
                    }
                    else
                    {
                        using (var db = new ADONETBioskopContainer())
                        {
                            var projektori = db.Projektors.Where(x => x.Id == idprojektora).ToList();

                            if (projektori.Count == 0)
                            {
                                error.Content = "Ne postoji projektor sa tim IDjem!";
                                error.Visibility = Visibility.Visible;
                                return;
                            }
                        }
                    }
                }
            }


            using (var db = new ADONETBioskopContainer())
            {
                var query = db.Osposobljens.Where(x => x.Projektant.JMBG == jmbgprojektanta && x.Projektor.Id == idprojektora).ToList();
                if(query.Count==0)
                {
                    var projektor = db.Projektors.Where(x => x.Id == idprojektora).FirstOrDefault();
                    var projektant = db.Radniks.OfType<Projektant>().Where(x => x.JMBG == jmbgprojektanta).FirstOrDefault();

                    Osposobljen o = new Osposobljen();
                    o.Projektant = projektant;
                    o.ProjektantJMBG = jmbgprojektanta;
                    o.Projektor = projektor;
                    o.ProjektorId = idprojektora;


                    db.Osposobljens.Add(o);
                    db.SaveChanges();
                    Data.osposobljeni.Add(o);




                }else
                {
                    error.Content = "Kombinacija vec u tabeli!";
                    error.Visibility = Visibility.Visible;
                    return;
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
