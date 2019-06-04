using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekat.Model
{
    [Serializable]
    public class Etiketa : INotifyPropertyChanged
    {
        protected virtual void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        [field:NonSerialized]
        public event PropertyChangedEventHandler PropertyChanged;

        private string _oznaka;
        public string Oznaka
        {
            get
            {
                return _oznaka;
            }
            set
            {
                if (value != _oznaka)
                {
                    _oznaka = value;
                    OnPropertyChanged("Oznaka");
                }
            }
        }

        private string _boja;
        public string Boja
        {
            get
            {
                return _boja;
            }
            set
            {
                if (value != _boja)
                {
                    _boja = value;
                    OnPropertyChanged("Boja");
                }
            }
        }

        private string _opis;
        public string Opis
        {
            get
            {
                return _opis;
            }
            set
            {
                if (value != _opis)
                {
                    _opis = value;
                    OnPropertyChanged("Opis");
                }
            }
        }
    }
}
