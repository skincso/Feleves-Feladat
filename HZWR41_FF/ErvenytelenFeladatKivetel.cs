using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HZWR41_FF.Feladatok;

namespace HZWR41_FF
{
    class ErvenytelenFeladatKivetel : Exception
    {
        public ErvenytelenFeladatKivetel(string message) : base(message)
        {
        }
    }
}
