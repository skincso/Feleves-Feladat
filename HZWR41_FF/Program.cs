using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using HZWR41_FF.Feladatok;

namespace HZWR41_FF
{
    class Program
    {
        static void Main(string[] args)
        {
            Szimulacio szim = new Szimulacio();
            szim.FeladatBetoltes();
            szim.SzimulacioInditas();
            
            Console.ReadLine();
        }

    }
}
