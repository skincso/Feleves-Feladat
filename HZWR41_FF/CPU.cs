using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HZWR41_FF.Feladatok;

namespace HZWR41_FF
{
    class CPU
    {
        BinarisKeresofa aktualisFeladatok; //adott korben elvegzendo, prioritas szerint rendezve
        int idokapacitas;

        public CPU()
        {
            idokapacitas = 10;
        }

        public void FeladatValasztas(List<IFeladat> feladatok)
        {
            List<IFeladat[]> megoldasok = new List<IFeladat[]>();
            VisszalepesesKereses(0, new IFeladat[feladatok.Count], feladatok.ToArray(), megoldasok);
        }

        void VisszalepesesKereses(int szint, IFeladat[] jelenlegiMegoldas, IFeladat[] feladatok, 
            List<IFeladat[]> megoldasok) // szint 0-tól indexelve
        {
            // elágazásnál új referencia létrehozása
            // jelenlegiMegoldas tömb másolása -> ICloneable

            int i = -1;
            while (i < 2)
            {
                i++;
                bool elsoFutas = i == 0;
                if (elsoFutas)
                {
                    if (Belefer(jelenlegiMegoldas, feladatok[szint].Idoigeny, szint)) // függvény ami eldönti, hogy befér-e
                    {
                        jelenlegiMegoldas[szint] = feladatok[szint];
                        if (szint == feladatok.Length - 1)
                        {
                            megoldasok.Add(jelenlegiMegoldas);
                        }
                        else
                        {
                            VisszalepesesKereses(szint + 1, jelenlegiMegoldas, feladatok, megoldasok);
                        }
                    }
                }
                else
                {
                    if (szint == feladatok.Length - 1)
                    {
                        megoldasok.Add(jelenlegiMegoldas);
                    }
                    else
                    {
                        VisszalepesesKereses(szint + 1, jelenlegiMegoldas, feladatok, megoldasok);
                    }
                }
            }
        }

        bool Belefer(IFeladat[] jelenlegiMegoldas, int idoigeny, int szint)
        {
            // szabad kapacitás

            int szabadKapacitas = idokapacitas;
            for (int i = 0; i < szint; i++)
            {
                if (jelenlegiMegoldas[i] != null)
                {
                    szabadKapacitas -= jelenlegiMegoldas[i].Idoigeny;
                }
            }

            // befér?

            if (szabadKapacitas >= idoigeny)
            {
                return true;
            }
            else return false;

        }
        void FeladatVegrehajtas()
        {

        }
    }
}
