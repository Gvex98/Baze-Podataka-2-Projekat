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
using System.Linq;
using System.Data.Entity;
namespace BioskopUI
{
    /// <summary>
    /// Interaction logic for SaleMain.xaml
    /// </summary>
    public partial class SaleMain : Window
    {
        public SaleMain()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Sala sala = SalaGrid.SelectedItem as Sala;

            using (var db = new ADONETBioskopContainer())
            {

                var projtodelete = db.Projekcijas.Where(s => s.SalaBroj == sala.Broj).ToList();

                foreach (Projekcija pr in projtodelete)
                {

                    db.Projekcijas.Remove(pr);
                    db.SaveChanges();
                    for (int i = 0; i < Data.projekcije.Count; i++)
                    {
                        if (Data.projekcije[i].Id == pr.Id)
                        {
                            Data.projekcije.RemoveAt(i);
                        }
                    }

                }




                if (Data.sale.Contains(sala))
                {
                    db.Salas.Attach(sala);
                    
                    var projektor = db.Projektors.Include(f => f.Sala).Where(eee => eee.Sala.Broj == sala.Broj).FirstOrDefault();
                    if(projektor!=null)
                    {
                        projektor.Sala = null;
                        //projektor.Sala_Broj
                        projektor.Sala= null;
                        foreach (Projektor pr in Data.projektori)
                        {
                            if (pr.Id == projektor.Id)
                            {
                                pr.Sala = null;
                                
                                //pr.Sala_Broj = null;
                            }
                        }
                        db.SaveChanges();
                    }
                    

                   

                    db.Salas.Remove(sala);
                    db.SaveChanges();
                    Data.sale.Remove(sala);
                }
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            SalaNew sn = new SalaNew();
            sn.Show();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Sala sala = SalaGrid.SelectedItem as Sala;
            SaleEdit se = new SaleEdit();
            se.oldbr.Content = sala.Broj;
            se.Broj_mesta.Text = sala.BrojMesta.ToString();
            se.Show();
            //this.Close();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
