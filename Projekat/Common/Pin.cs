using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projekat.Model;
using System.ComponentModel;

namespace Projekat.Common
{
    [Serializable]
    public class Pin : INotifyPropertyChanged
    {
        protected virtual void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        [field: NonSerialized]
        public event PropertyChangedEventHandler PropertyChanged;

        public double X { get; set; }
        public double Y { get; set; }

        private Vrsta _vrsta;
        public Vrsta Vrsta
        {
            get
            {
                return _vrsta;
            }
            set
            {
                if (value != _vrsta)
                {
                    _vrsta = value;
                    OnPropertyChanged("Vrsta");
                }
            }
        }
    }
}
