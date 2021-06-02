using BioskopData;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
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
    /// Interaction logic for ProjektorNew.xaml
    /// </summary>
    public partial class ProjektorNew : Window
    {
        public ProjektorNew()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int idnumber;
            int brojsale=-1;
            int cena;
            Projektor proj = new Projektor();

            Sala sala = new Sala();
            if (Id.Text.Equals(""))
            {
                error.Content = "Morate uneti ID projektora!";
                error.Visibility = Visibility.Visible;
                return;
            }else
            {
                bool projisnumber = Int32.TryParse(Id.Text, out idnumber);
                if(!projisnumber)
                {
                    error.Content = "ID projektora mora biti broj!";
                    error.Visibility = Visibility.Visible;
                    return;
                } else if(idnumber<0)
                {
                    error.Content = "ID projektora treba biti pozitivan!";
                    error.Visibility = Visibility.Visible;
                    return;
                }
                else
                {

                }
                
            }

            if(Model.Text.Equals(""))
            {
                error.Content = "Morate uneti model projektora!";
                error.Visibility = Visibility.Visible;
                return;
            }

            if (Cena.Text.Equals(""))
            {
                error.Content = "Morate uneti cenu projektora!";
                error.Visibility = Visibility.Visible;
                return;
            }
            else
            {
                bool cenaisbroj = Int32.TryParse(Cena.Text, out cena);
                if (!cenaisbroj)
                {
                    error.Content = "Cena projektora mora biti broj!";
                    error.Visibility = Visibility.Visible;
                    return;
                }
                else if (cena < 0)
                {
                    error.Content = "Cena projektora treba biti pozitivan!";
                    error.Visibility = Visibility.Visible;
                    return;
                }
                else
                {

                }

            }

            if(!Broj_sale.Text.Equals(""))
            {
                bool brojsaleisnumber = Int32.TryParse(Broj_sale.Text, out brojsale);
                if(!brojsaleisnumber)
                {
                    error.Content = "Broj sale treba biti broj!";
                    error.Visibility = Visibility.Visible;
                    return;
                }else if(brojsale<0)
                {
                    error.Content = "Broj sale treba biti pozitivan!";
                    error.Visibility = Visibility.Visible;
                    return;
                }else
                {

                    bool salapostoji = false;
                 

                    foreach(Sala s in Data.sale)
                    {
                        if(s.Broj==brojsale)
                        {
                            foreach (Projektor pr in Data.projektori)
                            {
                                if(pr.Sala!=null)
                                {
                                    if (pr.Sala.Broj == brojsale)
                                    {
                                        error.Content = "Zadata sala vec ima projektor!";
                                        error.Visibility = Visibility.Visible;
                                        return;
                                    }
                                }
                                
                            }
                            salapostoji = true;
                            sala = s;
                            using (var db = new ADONETBioskopContainer())
                            {
                                var entity = db.Salas.FirstOrDefault(x => x.Broj == brojsale);

                                proj.Id = idnumber;
                                proj.Model = Model.Text;
                                proj.Cena = cena;
                                //proj.Sala_Broj
                                proj.Sala = entity;
                                
                                
                                
                                db.Salas.Attach(proj.Sala);
                                db.Projektors.Add(proj);
                                Data.projektori.Add(proj);
                                db.SaveChanges();
                            }
                        }
                    }
                    if(!salapostoji)
                    {
                        error.Content = "Sala sa datim IDjem ne postoji!";
                        error.Visibility = Visibility.Visible;
                        return;
                    }else
                    {

                    }


                }
            }else
            {
                //PRAZAN STRING
                proj.Id = idnumber;
                proj.Model = Model.Text;
                proj.Cena = cena;
                //proj.Sala_Broj
                
                proj.Sala = null;
                using (var db = new ADONETBioskopContainer())
                {
                    //db.Salas.Attach(proj.Sala);
                    db.Projektors.Add(proj);
                    Data.projektori.Add(proj);
                    db.SaveChanges();
                }
                  
                
            }


            
            
            
          


            



            this.Close();


        }
    }
}
