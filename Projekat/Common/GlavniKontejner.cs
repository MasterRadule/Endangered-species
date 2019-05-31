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
        public List<Mapa> Mape { get; set; }
        public List<Vrsta> NeprikazaneVrste { get; set; }
        public ObservableCollection<Tip> NekorisceniTipovi { get; set; }
        public ObservableCollection<Etiketa> NekorisceneEtikete { get; set; }

        public GlavniKontejner()
        {
            Mape = new List<Mapa>();
            NeprikazaneVrste = new List<Vrsta>();
            NekorisceniTipovi = new ObservableCollection<Tip>();
            NekorisceneEtikete = new ObservableCollection<Etiketa>();

            for(var i = 0; i < 4; i++)
            {
                Mape.Add(new Mapa());
            }
        }
    }
}
