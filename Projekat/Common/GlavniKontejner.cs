using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekat.Common
{
    [Serializable]
    public class GlavniKontejner
    {
        public List<Mapa> Mape { get; set; }

        public GlavniKontejner()
        {
            Mape = new List<Mapa>();

            for(var i = 0; i < 4; i++)
            {
                Mape.Add(new Mapa());
            }
        }
    }
}
