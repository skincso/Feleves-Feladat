using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HZWR41_FF.Feladatok;

namespace HZWR41_FF
{
    public delegate void SzimulacioVegeKezelo();

    class Szimulacio
    {
        public CPU Cpu { get; }
        List<IFeladat> osszFeladatok;
        public event SzimulacioVegeKezelo SzimulacioVege;

        public Szimulacio(int cpuKapacitas)
        {
            Cpu = new CPU(cpuKapacitas);
            osszFeladatok = new List<IFeladat>();
        }

        public void SzimulacioInditas(List<IFeladat> feladatLista) // Main-ből hívjuk meg
        {
            osszFeladatok = feladatLista;
            while (osszFeladatok.Count != 0) // amíg van feladat
            {
                SzimulaciosKor();
            }
            SzimulacioVege?.Invoke();

        }
        void SzimulaciosKor()
        {
            // cpu választ feladatokat
            Cpu.FeladatValasztas(osszFeladatok);

            // cpu elvégzi a beütemezett feladatokat
            Cpu.FeladatVegrehajtas();

            // elvégzett feladatok törlése és hanyszimulacioskorotael++
            ElvegzettFeladatokKezelese();
        }
        void ElvegzettFeladatokKezelese()
        {
            List<IFeladat> torlendoFeladatok = new List<IFeladat>();

            foreach (IFeladat feladat in osszFeladatok)
            {
                if (feladat.Elvegezve == false)
                {
                    feladat.HanySzimulaciosKorOtaEl++;
                }
                else
                {
                    torlendoFeladatok.Add(feladat);
                }
            }

            foreach (IFeladat feladat in torlendoFeladatok)
            {
                osszFeladatok.Remove(feladat);
            }
        }
        
    }
}
