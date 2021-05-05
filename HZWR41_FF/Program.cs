using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using HZWR41_FF.Feladatok;

namespace HZWR41_FF
{
    class Program
    { 
        //FeladatTípusa-Prioritás-Időigény-HánySzimulációsKörÓtaÉl
        // tesztelés
        // láthatóságokat ellenőrizni


        static void Main(string[] args)
        {
            Szimulacio szim = new Szimulacio();
            szim.SzimulacioVege += KonzolraKiiras;
            List<IFeladat> feladatok = FeladatBeolvasas();
            try
            {
                szim.FeladatEllenorzes(feladatok);
            }
            catch (TulNagyFeladatKivetel e)
            {
                Console.WriteLine(e.Message);
                feladatok.Remove(e.Feladat);
                Console.WriteLine("A feladat törölve");
            }
            szim.SzimulacioInditas(feladatok);
            
            Console.ReadLine();
        }

        static List<IFeladat> FeladatBeolvasas()
        {
            List<IFeladat> feladatokLista = new List<IFeladat>();
            StreamReader sr = new StreamReader("cpu_feladatok.txt");
            while (!sr.EndOfStream)
            {
                string feladat = sr.ReadLine();
                string[] adatok = feladat.Split('-');

                switch (adatok[0])
                {
                    case "IO":
                        IOFeladat IOFeladat = new IOFeladat(int.Parse(adatok[1]), int.Parse(adatok[2]), int.Parse(adatok[3]));
                        IOFeladat.FeladatBeutemezve += KonzolraKiiras;
                        feladatokLista.Add(IOFeladat);
                        break;
                    case "Szamitasi":
                        SzamitasiFeladat szamitasiFeladat = new SzamitasiFeladat(int.Parse(adatok[1]), int.Parse(adatok[2]), int.Parse(adatok[3]));
                        szamitasiFeladat.FeladatBeutemezve += KonzolraKiiras;
                        feladatokLista.Add(szamitasiFeladat);
                        break;
                    case "HDMI_IO":
                        HDMI_IO hdmiIO = new HDMI_IO(int.Parse(adatok[1]), int.Parse(adatok[2]), int.Parse(adatok[3]));
                        hdmiIO.FeladatBeutemezve += KonzolraKiiras;
                        feladatokLista.Add(hdmiIO);
                        break;
                    case "MerevlemezIO":
                        MerevlemezIO merevlemezIO = (new MerevlemezIO(int.Parse(adatok[1]), int.Parse(adatok[2]), int.Parse(adatok[3])));
                        merevlemezIO.FeladatBeutemezve += KonzolraKiiras;
                        feladatokLista.Add(merevlemezIO);
                        break;
                    default:
                        break;
                }
            }
            sr.Close();
            return feladatokLista;
        }

        static void KonzolraKiiras(string uzenet)
        {
            Console.WriteLine(uzenet);
        }

    }
}
