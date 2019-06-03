using Projekat.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Runtime.Serialization;
using System.Windows.Media.Imaging;

namespace Projekat.Model
{
    [Serializable]
    public class Vrsta : ISerializable, INotifyPropertyChanged
    {
        protected virtual void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        [field: NonSerialized]
        public event PropertyChangedEventHandler PropertyChanged;

        [field: NonSerialized]
        public List<Pin> pinovi = new List<Pin>();

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

        private string _ime;
        public string Ime
        {
            get
            {
                return _ime;
            }
            set
            {
                if (value != _ime)
                {
                    _ime = value;
                    OnPropertyChanged("Ime");
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

        private decimal _godisnjiPrihod;
        public decimal GodisnjiPrihod
        {
            get
            {
                return _godisnjiPrihod;
            }
            set
            {
                if (value != _godisnjiPrihod)
                {
                    _godisnjiPrihod = value;
                    OnPropertyChanged("GodisnjiPrihod");
                }
            }
        }

        private Tip _tip;
        public Tip Tip
        {
            get
            {
                return _tip;
            }
            set
            {
                if (value != _tip)
                {
                    _tip = value;
                    OnPropertyChanged("Tip");
                }
            }
        }

        private bool _opasna;
        public bool Opasna
        {
            get
            {
                return _opasna;
            }
            set
            {
                if (value != _opasna)
                {
                    _opasna = value;
                    OnPropertyChanged("Opasna");
                }
            }
        }

        private bool _iucn;
        public bool IUCN
        {
            get
            {
                return _iucn;
            }
            set
            {
                if (value != _iucn)
                {
                    _iucn = value;
                    OnPropertyChanged("IUCN");
                }
            }
        }

        private bool _naseljeno;
        public bool ZiviUNaseljenomRegionu
        {
            get
            {
                return _naseljeno;
            }
            set
            {
                if (value != _naseljeno)
                {
                    _naseljeno = value;
                    OnPropertyChanged("ZiviUNaseljenomRegionu");
                }
            }
        }

        private StatusUgrozenosti _statusUgrozenosti;
        public StatusUgrozenosti StatusUgrozenosti
        {
            get
            {
                return _statusUgrozenosti;
            }
            set
            {
                if (value != _statusUgrozenosti)
                {
                    _statusUgrozenosti = value;
                    OnPropertyChanged("StatusUgrozenosti");
                }
            }
        }

        private TuristickiStatus _turistickiStatus;
        public TuristickiStatus TuristickiStatus
        {
            get
            {
                return _turistickiStatus;
            }
            set
            {
                if (value != _turistickiStatus)
                {
                    _turistickiStatus = value;
                    OnPropertyChanged("TuristickiStatus");
                }
            }
        }

        private DateTime _datumOtkrivanja;
        public DateTime DatumOtkrivanja
        {
            get
            {
                return _datumOtkrivanja;
            }
            set
            {
                if (value != _datumOtkrivanja)
                {
                    _datumOtkrivanja = value;
                    OnPropertyChanged("DatumOtkrivanja");
                }
            }
        }

        private List<Etiketa> _etikete;
        public List<Etiketa> Etikete {
            get
            {
                return _etikete;
            }
            set
            {
                if (value != _etikete)
                {
                    _etikete = value;
                    OnPropertyChanged("Etikete");
                }
            }
        }

        private BitmapImage _ikonica;
        public BitmapImage Ikonica
        {
            get
            {
                return _ikonica;
            }
            set
            {
                if (value != _ikonica)
                {
                    _ikonica = value;
                    OnPropertyChanged("Ikonica");
                }
            }
        }

        private bool _prikazana = true;
        public bool Prikazana
        {
            get { return _prikazana; }
            set
            {
                if (value != _prikazana)
                {
                    _prikazana = value;
                    OnPropertyChanged("Prikazana");
                }
            }
        }

        public Vrsta()
        {
            Etikete = new List<Etiketa>();
            Ikonica = new BitmapImage();
        }

        protected Vrsta(SerializationInfo info, StreamingContext context)
        {
            Oznaka = info.GetString("Oznaka");
            Ime = info.GetString("Ime");
            Opis = info.GetString("Opis");
            Tip = (Tip)info.GetValue("Tip", typeof(Tip));
            StatusUgrozenosti = (StatusUgrozenosti)info.GetValue("StatusUgrozenosti", typeof(StatusUgrozenosti));
            Opasna = info.GetBoolean("Opasna");
            IUCN = info.GetBoolean("IUCN");
            ZiviUNaseljenomRegionu = info.GetBoolean("ZiviUNaseljenomRegionu");
            TuristickiStatus = (TuristickiStatus)info.GetValue("TuristickiStatus", typeof(TuristickiStatus));
            GodisnjiPrihod = info.GetDecimal("GodisnjiPrihod");
            DatumOtkrivanja = info.GetDateTime("DatumOtkrivanja");
            Etikete = (List<Etiketa>)info.GetValue("Etikete", typeof(List<Etiketa>));

            byte[] array = (byte[])info.GetValue("Ikonica", typeof(byte[]));
            using (var ms = new MemoryStream(array))
            {
                BitmapImage image = new BitmapImage();
                image.BeginInit();
                image.StreamSource = ms;
                image.CacheOption = BitmapCacheOption.OnLoad;
                image.EndInit();
                Ikonica = image;
            }

            Prikazana = true;
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Oznaka", Oznaka);
            info.AddValue("Ime", Ime);
            info.AddValue("Opis", Opis);
            info.AddValue("Tip", Tip);
            info.AddValue("StatusUgrozenosti", StatusUgrozenosti);
            info.AddValue("Opasna", Opasna);
            info.AddValue("IUCN", IUCN);
            info.AddValue("ZiviUNaseljenomRegionu", ZiviUNaseljenomRegionu);
            info.AddValue("TuristickiStatus", TuristickiStatus);
            info.AddValue("GodisnjiPrihod", GodisnjiPrihod);
            info.AddValue("DatumOtkrivanja", DatumOtkrivanja);
            info.AddValue("Etikete", Etikete);

            byte[] ikonica;
            JpegBitmapEncoder encoder = new JpegBitmapEncoder();
            encoder.Frames.Add(BitmapFrame.Create(Ikonica));
            using (MemoryStream ms = new MemoryStream())
            {
                encoder.Save(ms);
                ikonica = ms.ToArray();
            }

            info.AddValue("Ikonica", ikonica);
        }
    }
}
