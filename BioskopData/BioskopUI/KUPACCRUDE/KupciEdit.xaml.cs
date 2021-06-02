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
    /// Interaction logic for KupciEdit.xaml
    /// </summary>
    public partial class KupciEdit : Window
    {
        public KupciEdit()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (Ime.Text.Equals(""))
            {
                error.Content = "Morate uneti ime!";
                error.Visibility = Visibility.Visible;
                return;
            }
          

            if (Prezime.Text.Equals(""))
            {
                error.Content = "Morate uneti prezime!";
                error.Visibility = Visibility.Visible;
                return;
            }
            int oldidx = Int32.Parse(oldid.Text);
            Kupac kupac = new Kupac();
            kupac.Id = oldidx;
            kupac.Ime = Ime.Text;
            kupac.Prezime = Prezime.Text;
            for (int i = 0; i < Data.kupci.Count; i++)
            {
                if (Data.kupci[i].Id == oldidx)
                {
                    Data.kupci[i] = kupac;
                    
                }
            }


            using (var db = new ADONETBioskopContainer())
            {
                var entity = db.Kupacs.FirstOrDefault(x => x.Id == oldidx);

                entity.Ime = kupac.Ime;
                entity.Prezime = kupac.Prezime;
                


                db.SaveChanges();
            }

            this.Close();
        }
    }
}
