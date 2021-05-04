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
        public void FeladatBetoltes()
        {
            osszFeladatok.Add(new HDMI_IO(2, 5));
            osszFeladatok.Add(new SzamitasiFeladat(6, 10));
            osszFeladatok.Add(new SzamitasiFeladat(5, 5));

        }

        public void SzimulacioInditas()
        {
            while (osszFeladatok.Count != 0)
            {
                SzimulaciosKor();
            }
            SzimulacioVege?.Invoke("A szimuláció véget ért.");

        }

        public void SzimulaciosKor()
        {
            // cpu választ feladatokat
            cpu.FeladatValasztas(osszFeladatok);

            // cpu elvégzi a beütemezett feladatokat
            cpu.FeladatVegrehajtas();

            // hanyszimulacioskorotael++
            NemBeutemezettFeladatok();
        }

        void NemBeutemezettFeladatok()
        {
            foreach (IFeladat feladat in osszFeladatok)
            {
                if (feladat.Elvegezve == false)
                {
                    feladat.HanySzimulaciosKorOtaEl++;
                }
                else
                {
                    osszFeladatok.Remove(feladat);
                }
            }
        }

    }
}
