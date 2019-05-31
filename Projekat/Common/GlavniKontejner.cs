using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projekat.Model;

namespace Projekat.Common
{
    [Serializable]
    public class GlavniKontejner
    {
        public List<Mapa> Mape { get; set; }
        public List<Vrsta> NeprikazaneVrste { get; set; }
        public List<Tip> NekorisceniTipovi { get; set; }
        public List<Etiketa> NekorisceneEtikete { get; set; }

        public GlavniKontejner()
        {
            Mape = new List<Mapa>();
            NeprikazaneVrste = new List<Vrsta>();
            NekorisceniTipovi = new List<Tip>();
            NekorisceneEtikete = new List<Etiketa>();

            for(var i = 0; i < 4; i++)
            {
                Mape.Add(new Mapa());
            }
        }
    }
}
