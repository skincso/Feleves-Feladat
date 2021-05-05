using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HZWR41_FF.Feladatok;

namespace HZWR41_FF
{
    class TulNagyFeladatKivetel : Exception
    {
        public IFeladat Feladat { get; }
        public TulNagyFeladatKivetel(string message, IFeladat feladat) : base(message)
        {
            Feladat = feladat;
        }
    }
}
