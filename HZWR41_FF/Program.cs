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
        // FeladatTípusa/Prioritás/Időigény/HánySzimulációsKörÓtaÉl
        // tesztelés


        // láthatóságokat ellenőrizni


        static void Main(string[] args)
        {
            Szimulacio szim = new Szimulacio(10);
            szim.SzimulacioVege += SzimulacioVege;
            List<IFeladat> feladatok = FeladatBeolvasas(szim.Cpu.Idokapacitas);
            szim.SzimulacioInditas(feladatok);
            Console.ReadLine();
        }

        static List<IFeladat> FeladatBeolvasas(int cpuKapacitas)
        {
            List<IFeladat> feladatokLista = new List<IFeladat>();
            StreamReader sr = new StreamReader("cpu_feladatok.txt");
            while (!sr.EndOfStream)
            {
                string feladat = sr.ReadLine();
                string[] adatok = feladat.Split('/');

                try
                {
                    if (int.Parse(adatok[1]) <= 0 || int.Parse(adatok[2]) <= 0 || int.Parse(adatok[2]) > cpuKapacitas || int.Parse(adatok[3]) < 0)
                    {
                        throw new ErvenytelenFeladatKivetel($"A feladat érvénytelen: {adatok[0]}");
                    }
                    switch (adatok[0])
                    {
                        case "IO":
                            IOFeladat IOFeladat = new IOFeladat(int.Parse(adatok[1]), int.Parse(adatok[2]), int.Parse(adatok[3]));
                            IOFeladat.FeladatBeutemezve += FeladatBeutemezve;
                            feladatokLista.Add(IOFeladat);
                            break;
                        case "Szamitasi":
                            SzamitasiFeladat szamitasiFeladat = new SzamitasiFeladat(int.Parse(adatok[1]), int.Parse(adatok[2]), int.Parse(adatok[3]));
                            szamitasiFeladat.FeladatBeutemezve += FeladatBeutemezve;
                            feladatokLista.Add(szamitasiFeladat);
                            break;
                        case "HDMI_IO":
                            HDMI_IO hdmiIO = new HDMI_IO(int.Parse(adatok[1]), int.Parse(adatok[2]), int.Parse(adatok[3]));
                            hdmiIO.FeladatBeutemezve += FeladatBeutemezve;
                            feladatokLista.Add(hdmiIO);
                            break;
                        case "MerevlemezIO":
                            MerevlemezIO merevlemezIO = (new MerevlemezIO(int.Parse(adatok[1]), int.Parse(adatok[2]), int.Parse(adatok[3])));
                            merevlemezIO.FeladatBeutemezve += FeladatBeutemezve;
                            feladatokLista.Add(merevlemezIO);
                            break;
                        default:
                            break;
                    }
                }
                catch (ErvenytelenFeladatKivetel e)
                {
                    Console.WriteLine(e.Message);
                }

                
            }
            sr.Close();
            return feladatokLista;
        }
        static void FeladatBeutemezve(int prioritas, int idoigeny, int kor)
        {
            Console.WriteLine($"Feladat beütemezve: prioritás: {prioritas}, időigény: {idoigeny}, kor: {kor}");
        }
        static void SzimulacioVege()
        {
            Console.WriteLine("A szimuláció véget ért");
        }
    }
}
