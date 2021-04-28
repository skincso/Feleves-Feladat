using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HZWR41_FF
{
    class TulNagyFeladatKivetel : Exception
    {
        public TulNagyFeladatKivetel(string message) : base(message)
        {
        }
    }
}
