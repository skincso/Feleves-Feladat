using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HZWR41_FF.Feladatok
{
    class SzamitasiFeladat : IFeladat
    {
        public int Prioritas { get; }
        public int Idoigeny { get; }
        public bool Elvegezve { get; set; }
        public int HanySzimulaciosKorOtaEl { get; set; }
        public SzamitasiFeladat(int prioritas, int idoigeny)
        {
            Prioritas = prioritas;
            Idoigeny = idoigeny;
            Elvegezve = false;
            HanySzimulaciosKorOtaEl = 0;
        }

        public event FeladatUtemezesKezelo FeladatBeutemezve;

        public void FeladatElvegzes()
        {
            FeladatBeutemezve?.Invoke(this);
            Elvegezve = true;
        }
    }
}
