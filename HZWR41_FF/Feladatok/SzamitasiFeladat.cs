using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HZWR41_FF.Feladatok
{
    public class SzamitasiFeladat : IFeladat
    {
        public int Prioritas { get; }
        public int Idoigeny { get; }
        public bool Elvegezve { get; set; }
        public int HanySzimulaciosKorOtaEl { get; set; }
        public bool Ervenyes { get; set; }
        public SzamitasiFeladat(int prioritas, int idoigeny, int hanySzimulaciosKorOtaEl)
        {
            Prioritas = prioritas;
            Idoigeny = idoigeny;
            Elvegezve = false;
            HanySzimulaciosKorOtaEl = hanySzimulaciosKorOtaEl;
        }

        public event FeladatUtemezesKezelo FeladatBeutemezve;

        public void FeladatElvegzes()
        {
            FeladatBeutemezve?.Invoke(Prioritas, Idoigeny, HanySzimulaciosKorOtaEl);
            Elvegezve = true;
        }
    }
}
