using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projekat.Common;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using Projekat.Model;
using System.Windows.Media.Imaging;

namespace Projekat.Utility
{
    public static class Loader
    {
        public static void Serijalizuj(GlavniKontejner glavniKontejner, string putanja)
        {
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream(putanja, FileMode.Create, FileAccess.Write, FileShare.None);
            formatter.Serialize(stream, glavniKontejner);
            stream.Close();
            Console.WriteLine("Serijalizovano u {0}!", putanja);
        }

        public static GlavniKontejner Deserijalizuj(string putanja)
        {
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream(putanja, FileMode.Open, FileAccess.Read, FileShare.Read);
            GlavniKontejner kontejner = (GlavniKontejner)formatter.Deserialize(stream);
            stream.Close();

            Console.WriteLine("Deserijalizovano!");
            return kontejner;
        }

        /*public static void Test()
        {
            GlavniKontejner kontejner = new GlavniKontejner();

            Vrsta v = new Vrsta();
            v.DatumOtkrivanja = new DateTime();
            v.GodisnjiPrihod = 1500;
            v.Ikonica.BeginInit();
            v.Ikonica.UriSource = new Uri(@"C:\Users\korisnik\Downloads\Telegram Desktop\photo_2019-05-28_15-12-40.jpg", UriKind.Absolute);
            v.Ikonica.EndInit();
            v.Ime = "Tigar";
            v.IUCN = false;
            v.Opasna = true;
            v.Opis = "grrr";
            v.Oznaka = "MUU";
            v.StatusUgrozenosti = StatusUgrozenosti.KriticnoUgrozena;
            v.TuristickiStatus = TuristickiStatus.DelimicnoHabituirana;
            v.ZiviUNaseljenomRegionu = true;

            Vrsta v1 = new Vrsta();
            v1.DatumOtkrivanja = new DateTime();
            v1.GodisnjiPrihod = 1500;
            v1.Ikonica.BeginInit();
            v1.Ikonica.UriSource = new Uri(@"C:\Users\korisnik\Downloads\Telegram Desktop\photo_2019-05-28_15-12-40.jpg", UriKind.Absolute);
            v1.Ikonica.EndInit();
            v1.Ime = "Tigar";
            v1.IUCN = false;
            v1.Opasna = true;
            v1.Opis = "grrr";
            v1.Oznaka = "MUU";
            v1.StatusUgrozenosti = StatusUgrozenosti.KriticnoUgrozena;
            v1.TuristickiStatus = TuristickiStatus.DelimicnoHabituirana;
            v1.ZiviUNaseljenomRegionu = true;

            Etiketa e = new Etiketa();
            e.Boja = "crvena";
            e.Opis = "c";
            e.Oznaka = "C";

            Etiketa e1 = new Etiketa();
            e.Boja = "crvena";
            e.Opis = "c";
            e.Oznaka = "C";

            v.Etikete.Add(e);
            kontejner.Etikete.Add(e1);

            Tip t = new Tip();
            t.Ikonica.BeginInit();
            t.Ikonica.UriSource = new Uri(@"C:\Users\korisnik\Downloads\Telegram Desktop\photo_2019-05-28_15-12-40.jpg", UriKind.Absolute);
            t.Ikonica.EndInit();
            t.Ime = "Macka";
            t.Opis = "mjau";
            t.Oznaka = "F";

            Tip t1 = new Tip();
            t1.Ikonica.BeginInit();
            t1.Ikonica.UriSource = new Uri(@"C:\Users\korisnik\Downloads\Telegram Desktop\photo_2019-05-28_15-12-40.jpg", UriKind.Absolute);
            t1.Ikonica.EndInit();
            t1.Ime = "Macka";
            t1.Opis = "mjau";
            t1.Oznaka = "F";

            kontejner.Tipovi.Add(t1);

            v.Tip = t;
            v1.Tip = t;
            kontejner.Vrste.Add(v1);

            Pin p = new Pin();
            p.OznakaVrste = v.Oznaka;
            p.X = 40;
            p.Y = 30;

            kontejner.Mape[0].Pinovi.Add(p);

            Serijalizuj(kontejner, "kontejner.es");
        }*/
    }
}
