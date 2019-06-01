using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projekat.Model;
using System.Collections.ObjectModel;

namespace Projekat.Common
{
    [Serializable]
    public class GlavniKontejner
    {
        public ObservableCollection<Mapa> Mape { get; set; }
        public ObservableCollection<Vrsta> Vrste { get; set; }
        public ObservableCollection<Tip> Tipovi { get; set; }
        public ObservableCollection<Etiketa> Etikete { get; set; }

        public GlavniKontejner()
        {
            Mape = new ObservableCollection<Mapa>();
            Vrste = new ObservableCollection<Vrsta>();
            Tipovi = new ObservableCollection<Tip>();
            Etikete = new ObservableCollection<Etiketa>();

            for(var i = 0; i < 4; i++)
            {
                Mape.Add(new Mapa());
            }
        }
    }
}
