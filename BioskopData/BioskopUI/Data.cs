using BioskopData;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BioskopUI
{
    public static class Data
    {
        public static ObservableCollection<Film> filmovi { get; set; } = new ObservableCollection<Film>();

        public static ObservableCollection<Kupac> kupci { get; set; } = new ObservableCollection<Kupac>();


        public static ObservableCollection<Prodavac> prodavci { get; set; } = new ObservableCollection<Prodavac>();

        public static ObservableCollection<Sala> sale { get; set; } = new ObservableCollection<Sala>();

        public static ObservableCollection<Projektor> projektori { get; set; } = new ObservableCollection<Projektor>();


        public static ObservableCollection<Projekcija> projekcije { get; set; } = new ObservableCollection<Projekcija>();

        public static ObservableCollection<Radnik> radnici { get; set; } = new ObservableCollection<Radnik>();

        public static ObservableCollection<Karta> karte { get; set; } = new ObservableCollection<Karta>();

        public static ObservableCollection<Osposobljen> osposobljeni { get; set; } = new ObservableCollection<Osposobljen>();

        public static ObservableCollection<Odrzava> odrzavaju { get; set; } = new ObservableCollection<Odrzava>();



       

    }
}
