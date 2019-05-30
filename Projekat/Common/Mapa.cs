using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Projekat.Common
{
    [Serializable]
    public class Mapa
    {
        public List<Pin> Pinovi { get; set; }

        public Mapa()
        {
            Pinovi = new List<Pin>();
        }
    }
}
