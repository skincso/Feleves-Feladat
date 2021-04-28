using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HZWR41_FF
{
    delegate void FeladatUtemezesKezelo();

    interface IFeladat : IComparer<IFeladat>
    {
        int Prioritas { get; }
        int Idoigeny { get; }
        bool Elvegezve { get; set; }
        int HanySzimulaciosKorOtaEl { get; set; }

        event FeladatUtemezesKezelo FeladatBeutemezve;

        //int IComparer.Compare(IFeladat x, IFeladat y);


    }


}
