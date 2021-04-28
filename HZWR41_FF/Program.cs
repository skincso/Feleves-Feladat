using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace HZWR41_FF
{
    class Program
    {
        static void Main(string[] args)
        {
            LancoltListaTeszt();

            Console.ReadLine();

        }

        static void LancoltListaTeszt()
        {
            IOFeladat io1 = new IOFeladat(2, 5);
            IOFeladat io2 = new IOFeladat(1, 10);
            IOFeladat io3 = new IOFeladat(3, 4);

            io1.HanySzimulaciosKorOtaEl += 9;
            io2.HanySzimulaciosKorOtaEl += 2;
            io3.HanySzimulaciosKorOtaEl += 5;

            ForditvaRendezettLancoltLista lista = new ForditvaRendezettLancoltLista();
            lista.Beszuras(io1, io1.HanySzimulaciosKorOtaEl);
            lista.Beszuras(io2, io2.HanySzimulaciosKorOtaEl);
            lista.Beszuras(io3, io3.HanySzimulaciosKorOtaEl);

        }

        static void FeladatBeolvasas(ref StreamReader sr,)
    }
}
