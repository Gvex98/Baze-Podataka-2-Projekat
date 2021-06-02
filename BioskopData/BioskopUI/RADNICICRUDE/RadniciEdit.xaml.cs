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
    /// Interaction logic for RadniciEdit.xaml
    /// </summary>
    public partial class RadniciEdit : Window
    {
        public RadniciEdit()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int plata;
            int id;

            id = Int32.Parse(Id.Content.ToString());

            if (Ime.Text.Equals(""))
            {
                error.Content = "Morate uneti ime radnika!";
                error.Visibility = Visibility.Visible;
                return;
            }
            if (Prezime.Text.Equals(""))
            {
                error.Content = "Morate uneti prezime radnika!";
                error.Visibility = Visibility.Visible;
                return;
            }
            if (Plata.Text.Equals(""))
            {
                error.Content = "Morate uneti platu radnika!";
                error.Visibility = Visibility.Visible;
                return;
            }
            else
            {
                bool plataisnumber = Int32.TryParse(Plata.Text, out plata);
                if (!plataisnumber)
                {
                    error.Content = "Plata treba biti broj!";
                    error.Visibility = Visibility.Visible;
                }
                else
                {
                    if (plata < 0)
                    {
                        error.Content = "Plata treba biti pozitivan broj!";
                        error.Visibility = Visibility.Visible;
                        return;
                    }
                }
            }


            using (var db = new ADONETBioskopContainer())
            {
                var entity = db.Radniks.FirstOrDefault(x => x.JMBG == id);

                entity.Ime = Ime.Text;
                entity.Prezime = Prezime.Text;
                entity.Plata = plata;



                db.SaveChanges();

                for(int i=0;i<Data.radnici.Count;i++)
                {
                    if (Data.radnici[i].JMBG==id)
                    {
                        Data.radnici[i] = entity;
                    }
                }
            }
            this.Close();



        }
    }
}
