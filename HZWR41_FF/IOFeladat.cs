using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HZWR41_FF
{
    class IOFeladat : IFeladat
    {
        public int Prioritas { get; }
        public int Idoigeny { get; }
        public bool Elvegezve{ get; set; }
        public int HanySzimulaciosKorOtaEl { get; set; }
        public IOFeladat(int prioritas, int idoigeny)
        {
            Prioritas = prioritas;
            Idoigeny = idoigeny;
            Elvegezve = false;
            HanySzimulaciosKorOtaEl = 0;
        }

        public event FeladatUtemezesKezelo FeladatBeutemezve;
        public int Compare(IFeladat x, IFeladat y) 
            // x < y ->  < 0
            // x = y -> 0
            // x > y -> > 0
 
        {
            if (x.HanySzimulaciosKorOtaEl < y.HanySzimulaciosKorOtaEl)
            {
                return -1;
            }
            else if (x.HanySzimulaciosKorOtaEl > y.HanySzimulaciosKorOtaEl)
            {
                return 1;
            }
            else if (x.Prioritas < y.Prioritas) // ha egyenlő korúak
            {
                return 1;
            }
            else return -1;

        }
    }
}
