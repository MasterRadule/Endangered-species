using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Projekat.Common
{
    [Serializable]
    public class Mapa
    {
        public ObservableCollection<Pin> Pinovi { get; set; }

        public Mapa()
        {
            Pinovi = new ObservableCollection<Pin>();
        }
    }
}
