using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projekat.Model;

namespace Projekat.Common
{
    [Serializable]
    public class Pin
    {
        public double X { get; set; }
        public double Y { get; set; }
        public Vrsta Vrsta { get; set; }
    }
}
