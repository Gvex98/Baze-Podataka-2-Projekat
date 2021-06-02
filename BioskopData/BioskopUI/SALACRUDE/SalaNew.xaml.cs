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
    /// Interaction logic for SalaNew.xaml
    /// </summary>
    public partial class SalaNew : Window
    {
        public SalaNew()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int broj_sale_number;
            int broj_mesta;
            int id_projektora=-1;


            if(Broj.Text.Equals(""))
            {
                error.Content = "Morate uneti broj sale!";
                error.Visibility = Visibility.Visible;
                return;
            }else
            {
                bool isnumber = Int32.TryParse(Broj.Text, out broj_sale_number);
                if(!isnumber)
                {
                    error.Content = "Broj sale mora biti broj!";
                    error.Visibility = Visibility.Visible;
                    return;
                }
                else if(broj_sale_number<0)
                {
                    error.Content = "Broj sale treba biti pozitivan!";
                    error.Visibility = Visibility.Visible;
                    return;
                }
                else
                {

                }
                
            }

            if(Broj_mesta.Text.Equals(""))
            {
                error.Content = "Morate uneti broj mesta!";
                error.Visibility = Visibility.Visible;
                return;
            }else
            {
                bool isnumber2 = Int32.TryParse(Broj_mesta.Text, out broj_mesta);
                if(!isnumber2)
                {
                    error.Content = "Broj mesta mora biti broj!";
                    error.Visibility = Visibility.Visible;
                    return;
                }else if(broj_mesta<0)
                {
                    error.Content = "Broj mesta mora biti pozitivan!";
                    error.Visibility = Visibility.Visible;
                    return;
                }else
                {

                }
            }


            /*
            if(!IDProjektora.Text.Equals(""))
            {
                bool projnumber = Int32.TryParse(IDProjektora.Text, out id_projektora);
                if (!projnumber)
                {
                    error.Content = "ID projektora mora biti broj!";
                    error.Visibility = Visibility.Visible;
                    return;
                }
                else if (id_projektora < 0)
                {
                    error.Content = "ID projektora treba biti pozitivan!";
                    error.Visibility = Visibility.Visible;
                    return;
                }
                else
                {
                    /*
                    bool postoji = false;
                    foreach(Projektor p in Data.projektors)
                    {
                        if(p.Id==id_projektora)
                        {
                            postoji = true;
                        }
                    }
                    if(postoji==false)
                    {
                        error.Content = "Ne postoji projektor sa ovim IDjem!";
                        error.Visibility = Visibility;
                        return;
                    }
                    
                }
            }
            */
            
           
           

            foreach(Sala see in Data.sale)
            {
                if(see.Broj==broj_sale_number)
                {
                    error.Content = "Sala sa tim ID-jem vec postoji!";
                    error.Visibility = Visibility.Visible;
                    return;
                }
            }



            
           

            Sala s = new Sala();
            s.Broj = broj_sale_number;
            
            s.BrojMesta = broj_mesta;

            

            

            using (var db = new ADONETBioskopContainer())
            {
                db.Salas.Add(s);
                db.SaveChanges();
            }

            Data.sale.Add(s);


            this.Close();




        }
    }
}
