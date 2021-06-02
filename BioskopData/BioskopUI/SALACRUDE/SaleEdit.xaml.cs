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
    /// Interaction logic for SaleEdit.xaml
    /// </summary>
    public partial class SaleEdit : Window
    {
        public SaleEdit()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int broj_mesta;
            if (Broj_mesta.Text.Equals(""))
            {
                error.Content = "Morate uneti broj mesta!";
                error.Visibility = Visibility.Visible;
                return;
            }
            else
            {
                bool isnumber2 = Int32.TryParse(Broj_mesta.Text, out broj_mesta);
                if (!isnumber2)
                {
                    error.Content = "Broj mesta mora biti broj!";
                    error.Visibility = Visibility.Visible;
                    return;
                }
                else if (broj_mesta < 0)
                {
                    error.Content = "Broj mesta mora biti pozitivan!";
                    error.Visibility = Visibility.Visible;
                    return;
                }
                else
                {

                }
            }
            int poz = -1;
            int oldbroj = Int32.Parse(oldbr.Content.ToString());
            using (var db = new ADONETBioskopContainer())
            {
                var entity = db.Salas.FirstOrDefault(x => x.Broj == oldbroj);

                entity.BrojMesta = broj_mesta;
                Sala sx = new Sala();
                sx.Broj = oldbroj;
                sx.BrojMesta = broj_mesta;
                for(int i=0;i<Data.sale.Count;i++)
                {
                    if(Data.sale[i].Broj==oldbroj)
                    {
                        Data.sale[i] = sx;
                    }
                }

                
               

                db.SaveChanges();
            }



            this.Close();


        }
    }
}
