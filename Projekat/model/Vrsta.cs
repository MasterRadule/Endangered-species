using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekat.model
{
    public class Vrsta
    {
        public string Oznaka { get; set; }
        public string Ime { get; set; }
        public string Opis { get; set; }
        public string Tip { get; set; }
        public StatusUgrozenosti StatusUgrozenosti { get; set; }
        public string Ikonica { get; set; }
        public bool Opasna { get; set; }
        public bool IUCN { get; set; }
        public bool ZiviUNaseljenomRegionu { get; set; }
        public TuristickiStatus TuristickiStatus { get; set; }
        public double GodisnjiPrihod { get; set; }
        public DateTime DatumOtkrivanja;
        List<Etiketa> Etikete { get; set; }
    }
}
