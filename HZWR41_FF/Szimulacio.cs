using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HZWR41_FF.Feladatok;

namespace HZWR41_FF
{
    class Szimulacio
    {
        CPU cpu;
        List<IFeladat> osszFeladatok;

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
            // cpu választ feladatokat
            cpu.FeladatValasztas(osszFeladatok);

            // cpu elvégzi a beütemezett feladatokat
            // hanyszimulacioskorotael++
        }

    }
}
