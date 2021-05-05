using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HZWR41_FF.Feladatok;

namespace HZWR41_FF
{
    public delegate void SzimulacioVegeKezelo(string uzenet);

    class Szimulacio
    {
        CPU cpu;
        List<IFeladat> osszFeladatok;
        public event SzimulacioVegeKezelo SzimulacioVege;

        public Szimulacio()
        {
            cpu = new CPU();
            osszFeladatok = new List<IFeladat>();
        }

        public void SzimulacioInditas(List<IFeladat> feladatLista) // Main-ből hívjuk meg
        {
            osszFeladatok = feladatLista;
            while (osszFeladatok.Count != 0) // amíg van feladat
            {
                SzimulaciosKor();
            }
            SzimulacioVege?.Invoke("A szimuláció véget ért.");

        }

        void SzimulaciosKor()
        {
            // cpu választ feladatokat
            cpu.FeladatValasztas(osszFeladatok);

            // cpu elvégzi a beütemezett feladatokat
            cpu.FeladatVegrehajtas();

            // elvégzett feladatok törlése és hanyszimulacioskorotael++
            ElvegzettFeladatokKezelese();
        }
        void ElvegzettFeladatokKezelese()
        {
            for (int i = 0; i < osszFeladatok.Count; i++)
            {
                if (osszFeladatok[i].Elvegezve == false)
                {
                    osszFeladatok[i].HanySzimulaciosKorOtaEl++;
                }
                else
                {
                    osszFeladatok[i] = null;
                }
            }

            // hogyan töröljük a nullelemeket a listából?
            ListaMasolas();
        }
        public void FeladatEllenorzes(List<IFeladat> feladatLista)
        {
            foreach (IFeladat feladat in feladatLista)
            {
                if (feladat.Idoigeny > cpu.idokapacitas)
                {
                    throw new TulNagyFeladatKivetel("A feladat mérete meghaladja a CPU kapacitását", feladat);
                }
            }
        }

        void ListaMasolas()
        {
            List<IFeladat> ujLista = new List<IFeladat>();
            foreach (IFeladat feladat in osszFeladatok)
            {
                if (feladat != null)
                {
                    ujLista.Add(feladat);
                }
            }
            osszFeladatok = ujLista;
        }

    }
}
