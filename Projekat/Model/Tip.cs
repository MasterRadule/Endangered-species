using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using Projekat.Utility;
using System.Runtime.Serialization;
using System.IO;

namespace Projekat.Model
{
    [Serializable]
    public class Tip : ISerializable
    {
        public string Oznaka { get; set; }
        public string Ime { get; set; }
        public BitmapImage Ikonica { get; set; }
        public string Opis { get; set; }

        public Tip()
        {
            Ikonica = new BitmapImage();
        }

        protected Tip(SerializationInfo info, StreamingContext context)
        {
            Oznaka = info.GetString("Oznaka");
            Ime = info.GetString("Ime");
            Opis = info.GetString("Opis");

            byte[] array = (byte[])info.GetValue("Ikonica", typeof(byte[]));
            using (var ms = new MemoryStream(array))
            {
                BitmapImage image = new BitmapImage();
                image.BeginInit();
                image.CacheOption = BitmapCacheOption.OnLoad;
                image.StreamSource = ms;
                image.EndInit();
                Ikonica = image;
            }
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Oznaka", Oznaka);
            info.AddValue("Ime", Ime);
            info.AddValue("Opis", Opis);

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
