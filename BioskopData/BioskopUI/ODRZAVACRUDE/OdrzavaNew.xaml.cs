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
    /// Interaction logic for OdrzavaNew.xaml
    /// </summary>
    public partial class OdrzavaNew : Window
    {
        public OdrzavaNew()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int jmbgdomara;
            int brojsale;

            if (JMBGDomara.Text.Equals(""))
            {
                error.Content = "Morate uneti JMBG domara!";
                error.Visibility = Visibility.Visible;
                return;
            }
            else
            {
                bool jmbgisnumber = Int32.TryParse(JMBGDomara.Text, out jmbgdomara);
                if (!jmbgisnumber)
                {
                    error.Content = "JMBG mora biti broj!";
                    error.Visibility = Visibility.Visible;
                    return;
                }
                else
                {
                    if (jmbgdomara < 0)
                    {
                        error.Content = "JMBG treba biti pozitivan!";
                        error.Visibility = Visibility.Visible;
                        return;
                    }
                    else
                    {
                        using (var db = new ADONETBioskopContainer())
                        {
                            var domari = db.Radniks.OfType<Domar>().Where(x => x.JMBG == jmbgdomara).ToList();

                            if (domari.Count == 0)
                            {
                                error.Content = "Ne postoji domar sa tim JMBGom!";
                                error.Visibility = Visibility.Visible;
                                return;
                            }
                        }
                    }
                }
            }



            if (BROJSale.Text.Equals(""))
            {
                error.Content = "Morate uneti broj sale!";
                error.Visibility = Visibility.Visible;
                return;
            }
            else
            {
                bool brojsaleisnubmer = Int32.TryParse(BROJSale.Text, out brojsale);
                if (!brojsaleisnubmer)
                {
                    error.Content = "Broj sale mora biti broj!";
                    error.Visibility = Visibility.Visible;
                    return;
                }
                else
                {
                    if (brojsale < 0)
                    {
                        error.Content = "Broj sale treba biti pozitivan!";
                        error.Visibility = Visibility.Visible;
                        return;
                    }
                    else
                    {
                        using (var db = new ADONETBioskopContainer())
                        {
                            var sale = db.Salas.Where(x => x.Broj == brojsale).ToList();

                            if (sale.Count == 0)
                            {
                                error.Content = "Ne postoji sala sa tim brojem!";
                                error.Visibility = Visibility.Visible;
                                return;
                            }
                        }
                    }
                }
            }

            using (var db = new ADONETBioskopContainer())
            {
                var query = db.Odrzavas.Where(x => x.Domar.JMBG == jmbgdomara && x.Sala.Broj == brojsale).ToList();
                if (query.Count == 0)
                {
                    var sala = db.Salas.Where(x => x.Broj == brojsale).FirstOrDefault();
                    var domar = db.Radniks.OfType<Domar>().Where(x => x.JMBG == jmbgdomara).FirstOrDefault();

                    Odrzava o = new Odrzava();
                    o.Domar = domar;
                    o.DomarJMBG = jmbgdomara;
                    o.Sala = sala;
                    o.SalaBroj = brojsale;


                    db.Odrzavas.Add(o);
                    db.SaveChanges();
                    Data.odrzavaju.Add(o);




                }
                else
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
