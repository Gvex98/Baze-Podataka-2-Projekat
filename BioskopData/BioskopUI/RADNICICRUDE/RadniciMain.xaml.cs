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
    /// Interaction logic for RadniciMain.xaml
    /// </summary>
    public partial class RadniciMain : Window
    {
        public RadniciMain()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            RadnikNew rn = new RadnikNew();
            rn.Show();
            
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Radnik rad = RadniciGrid.SelectedItem as Radnik;

            using (var db = new ADONETBioskopContainer())
            {
                if (Data.radnici.Contains(rad))
                {


                    var domari = db.Radniks.OfType<Domar>().Where(x => x.JMBG == rad.JMBG).ToList();
                    
                    var projektanti = db.Radniks.OfType<Projektant>().Where(x => x.JMBG == rad.JMBG).ToList();

                    var prodavci = db.Radniks.OfType<Prodavac>().Where(x => x.JMBG == rad.JMBG).ToList();


                    if(domari.Count>0)
                    {
                        var radn = domari[0];
                        var domarodrzava = db.Odrzavas.Where(x => x.DomarJMBG == rad.JMBG).ToList();
                        foreach(Odrzava o in domarodrzava)
                        {
                            db.Odrzavas.Attach(o);
                            db.Odrzavas.Remove(o);
                            
                            
                            Data.odrzavaju.Remove(o);
                        }
                        db.SaveChanges();
                        db.Radniks.Attach(radn);
                        db.Radniks.Remove(radn);
                        db.Entry(radn).State = System.Data.Entity.EntityState.Deleted;
                        db.SaveChanges();
                        Data.radnici.Remove(rad);
                    }
                    if (prodavci.Count > 0)
                    {
                        var radn = prodavci[0];
                        var prodprodao = db.Kartas.Where(x => x.Prodavac.JMBG == rad.JMBG).ToList();
                        foreach (Karta o in prodprodao)
                        {
                            db.Kartas.Attach(o);
                            db.Kartas.Remove(o);


                            Data.karte.Remove(o);
                        }
                        db.SaveChanges();
                        db.Radniks.Attach(radn);
                        db.Radniks.Remove(radn);
                        db.Entry(radn).State = System.Data.Entity.EntityState.Deleted;
                        db.SaveChanges();
                        Data.radnici.Remove(rad);
                    }
                    if (projektanti.Count > 0)
                    {
                        var radn = projektanti[0];
                        var projektuju = db.Osposobljens.Where(x => x.Projektant.JMBG == rad.JMBG).ToList();
                        foreach (Osposobljen o in projektuju)
                        {
                            db.Osposobljens.Attach(o);
                            db.Osposobljens.Remove(o);


                            Data.osposobljeni.Remove(o);
                        }
                        db.SaveChanges();
                        db.Radniks.Attach(radn);
                        db.Radniks.Remove(radn);
                        db.Entry(radn).State = System.Data.Entity.EntityState.Deleted;
                        db.SaveChanges();
                        Data.radnici.Remove(rad);
                    }






                }
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Radnik rad = RadniciGrid.SelectedItem as Radnik;

            RadniciEdit re = new RadniciEdit();
            re.Ime.Text = rad.Ime;
            re.Prezime.Text = rad.Prezime;
            re.Plata.Text = rad.Plata.ToString();
            re.Id.Content = rad.JMBG;
            re.Show();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
