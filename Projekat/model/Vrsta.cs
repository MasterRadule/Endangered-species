using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Windows.Media.Imaging;

namespace Projekat.Model
{
    [Serializable]
    public class Vrsta : ISerializable
    {
        public string Oznaka { get; set; }
        public string Ime { get; set; }
        public string Opis { get; set; }
        public Tip Tip { get; set; }
        public StatusUgrozenosti StatusUgrozenosti { get; set; }
        public BitmapImage Ikonica { get; set; }
        public bool Opasna { get; set; }
        public bool IUCN { get; set; }
        public bool ZiviUNaseljenomRegionu { get; set; }
        public TuristickiStatus TuristickiStatus { get; set; }
        public double GodisnjiPrihod { get; set; }
        public DateTime DatumOtkrivanja;
        List<Etiketa> Etikete { get; set; }

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
            GodisnjiPrihod = info.GetDouble("GodisnjiPrihod");
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
