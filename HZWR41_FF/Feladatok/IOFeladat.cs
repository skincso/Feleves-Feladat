using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HZWR41_FF.Feladatok
{
    public class IOFeladat : IFeladat
    {
        public int Prioritas { get; }
        public int Idoigeny { get; }
        public bool Elvegezve{ get; set; }
        public int HanySzimulaciosKorOtaEl { get; set; }

        public IOFeladat(int prioritas, int idoigeny, int hanySzimulaciosKorOtaEl)
        {
            Prioritas = prioritas;
            Idoigeny = idoigeny;
            Elvegezve = false;
            HanySzimulaciosKorOtaEl = hanySzimulaciosKorOtaEl;
        }

        public virtual event FeladatUtemezesKezelo FeladatBeutemezve;

        public virtual void FeladatElvegzes()
        {
            FeladatBeutemezve?.Invoke($"IO feladat beütemezve, időigény: {Idoigeny}, prioritás: {Prioritas}, kor: {HanySzimulaciosKorOtaEl}");
            Elvegezve = true;
        }
    }
}
