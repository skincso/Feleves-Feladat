using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HZWR41_FF.Feladatok
{
    public class MerevlemezIO : IOFeladat
    {
        public MerevlemezIO(int prioritas, int idoigeny, int hanySzimulaciosKorOtaEl) : base(prioritas, idoigeny, hanySzimulaciosKorOtaEl)
        {
        }
        public override event FeladatUtemezesKezelo FeladatBeutemezve;

        public override void FeladatElvegzes()
        {
            FeladatBeutemezve?.Invoke($"Merevlemez IO feladat beütemezve, időigény: {Idoigeny}, prioritás: {Prioritas}, kor: {HanySzimulaciosKorOtaEl}");
            Elvegezve = true;
        }

    }
}
