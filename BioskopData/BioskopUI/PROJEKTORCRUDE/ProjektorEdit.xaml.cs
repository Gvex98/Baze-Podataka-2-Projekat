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
    /// Interaction logic for ProjektorEdit.xaml
    /// </summary>
    public partial class ProjektorEdit : Window
    {
        public ProjektorEdit()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int idnumber = -1;
            int brojsale = -1;
            int cena;
            idnumber = Int32.Parse(id.Content.ToString());
            Projektor proj = new Projektor();

            Sala sala = new Sala();

            if (Model.Text.Equals(""))
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

            if (!Broj_sale.Text.Equals(""))
            {
                bool brojsaleisnumber = Int32.TryParse(Broj_sale.Text, out brojsale);
                if (!brojsaleisnumber)
                {
                    error.Content = "Broj sale treba biti broj!";
                    error.Visibility = Visibility.Visible;
                    return;
                }
                else if (brojsale < 0)
                {
                    error.Content = "Broj sale treba biti pozitivan!";
                    error.Visibility = Visibility.Visible;
                    return;
                }
                else
                {

                    bool salapostoji = false;


                    foreach (Sala s in Data.sale)
                    {
                        if (s.Broj == brojsale)
                        {
                            foreach (Projektor pr in Data.projektori)
                            {
                                //Sala_Broj
                                if(pr.Sala!=null)
                                {
                                    if (pr.Sala.Broj == brojsale && pr.Id != idnumber)
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
                                var entityproj=db.Projektors.FirstOrDefault(x => x.Id == idnumber);
                                var entity = db.Salas.FirstOrDefault(x => x.Broj == brojsale);

                                entityproj.Id = idnumber;
                                entityproj.Model = Model.Text;
                                entityproj.Cena = cena;
                                //entityproj.Sala_Broj = entity.Broj;
                                entityproj.Sala = entity;

                                //db.Projektors.Attach(proj.Sala);
                                //db.Projektors.Add(proj);
                                for(int i=0;i<Data.projektori.Count;i++)
                                {
                                    if(Data.projektori[i].Id==idnumber)
                                    {
                                        Data.projektori[i] = entityproj;
                                    }
                                }
                                db.SaveChanges();
                            }
                        }
                    }
                    if (!salapostoji)
                    {
                        error.Content = "Sala sa datim IDjem ne postoji!";
                        error.Visibility = Visibility.Visible;
                        return;
                    }
                    else
                    {

                    }


                }
            }
            else
            {
                
              
                using (var db = new ADONETBioskopContainer())
                {
                    //db.Salas.Attach(proj.Sala);

                    var entityproj = db.Projektors.FirstOrDefault(x => x.Id == idnumber);
                    

                    
                    entityproj.Model = Model.Text;
                    entityproj.Cena = cena;
                    
                    entityproj.Sala = null;

                   
                    for (int i = 0; i < Data.projektori.Count; i++)
                    {
                        if (Data.projektori[i].Id == idnumber)
                        {
                            Data.projektori[i] = entityproj;
                        }
                    }
                    db.SaveChanges();
                }


            }












            this.Close();
        }
    }
}
