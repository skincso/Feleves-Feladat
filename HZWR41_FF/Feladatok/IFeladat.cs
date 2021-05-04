using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HZWR41_FF;

namespace HZWR41_FF.Feladatok
{
    public delegate void FeladatUtemezesKezelo(IFeladat feladat);

    public interface IFeladat
    {
        int Prioritas { get; }
        int Idoigeny { get; }
        bool Elvegezve { get; set; }
        int HanySzimulaciosKorOtaEl { get; set; }

        event FeladatUtemezesKezelo FeladatBeutemezve;

        void FeladatElvegzes();

    }


}
