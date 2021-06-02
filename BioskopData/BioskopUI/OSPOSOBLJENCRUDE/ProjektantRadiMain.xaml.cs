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
    /// Interaction logic for ProjektantRadiMain.xaml
    /// </summary>
    public partial class ProjektantRadiMain : Window
    {
        public ProjektantRadiMain()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ProjektantRadiNew prn = new ProjektantRadiNew();
            prn.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Osposobljen osposobljen = OsposobljeGrid.SelectedItem as Osposobljen;

            using (var db = new ADONETBioskopContainer())
            {
                if (Data.osposobljeni.Contains(osposobljen))
                {
                    db.Osposobljens.Attach(osposobljen);
                    db.Osposobljens.Remove(osposobljen);
                    db.SaveChanges();
                    Data.osposobljeni.Remove(osposobljen);
                }
            }

        }

      
    }
}
