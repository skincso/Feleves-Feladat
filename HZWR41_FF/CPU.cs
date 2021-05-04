using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HZWR41_FF.Feladatok;

namespace HZWR41_FF
{
    public delegate void FeladatVegrehajtasKezelo(IFeladat feladat);
    
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
            IFeladat[][] megoldasokTomb = megoldasok.ToArray();

            // a megoldasokTomb elemei közül kiválasztjuk a megfelelőt
            int megoldasIndex = MegoldasValasztas(megoldasokTomb);

            // a kiválasztott feladatokat bináris fává alakítjuk
            aktualisFeladatok = AktualisFeladatokBeszurasa(megoldasokTomb[megoldasIndex]);

            // növeljük a hanyszimulacioskorotael változót azoknál a feladatoknál, amik nem lettek beütemezve


        }

        void VisszalepesesKereses(int szint, IFeladat[] jelenlegiMegoldas, IFeladat[] feladatok, 
            List<IFeladat[]> megoldasok) // szint 0-tól indexelve
        {
            // elágazásnál új referencia létrehozása
            // jelenlegiMegoldas tömb másolása -> ICloneable

            int i = -1;
            while (i < 1)
            {
                IFeladat[] ujJelenlegiMegoldas = new IFeladat[jelenlegiMegoldas.Length];
                for (int j = 0; j < jelenlegiMegoldas.Length; j++)
                {
                    ujJelenlegiMegoldas[j] = jelenlegiMegoldas[j];
                }

                i++;
                bool elsoFutas = (i == 0);
                if (elsoFutas)
                {
                    if (Belefer(ujJelenlegiMegoldas, feladatok[szint].Idoigeny, szint)) // függvény ami eldönti, hogy befér-e
                    {
                        ujJelenlegiMegoldas[szint] = feladatok[szint];
                        if (szint == feladatok.Length - 1)
                        {
                            megoldasok.Add(ujJelenlegiMegoldas);
                        }
                        else
                        {
                            VisszalepesesKereses(szint + 1, ujJelenlegiMegoldas, feladatok, megoldasok);
                        }
                    }
                    else
                    {
                        ;
                    }
                }
                else
                {
                    if (szint == feladatok.Length - 1)
                    {
                        megoldasok.Add(ujJelenlegiMegoldas);
                    }
                    else
                    {
                        VisszalepesesKereses(szint + 1, ujJelenlegiMegoldas, feladatok, megoldasok);
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
        int MegoldasValasztas(IFeladat[][] megoldasokTomb)
        {
            // for megoldasok
            // sum idoigeny
            int maxIndex = -1; // a kiválasztott feladat összeállítás
            int maxIdoigeny = -1; // megoldasokTomb[maxIndex] feladatok össz időigénye
            int maxKor = -1; // megoldasokTomb[maxIndex] feladatok közül a legidősebb
            for (int i = 0; i < megoldasokTomb.Length; i++)
            {
                int idoigeny = 0;
                int kor = -1;
                for (int j = 0; j < megoldasokTomb[i].Length; j++)
                {
                    if (megoldasokTomb[i][j] != null)
                    {
                        idoigeny += megoldasokTomb[i][j].Idoigeny;
                        if (megoldasokTomb[i][j].HanySzimulaciosKorOtaEl > kor)
                        {
                            kor = megoldasokTomb[i][j].HanySzimulaciosKorOtaEl;
                        }
                    }
                }
                if (idoigeny > maxIdoigeny)
                {
                    maxIndex = i;
                    maxIdoigeny = idoigeny;
                    maxKor = kor;
                }
                else if (idoigeny == maxIdoigeny)
                {
                    if (kor > maxKor)
                    {
                        maxIndex = i;
                        maxIdoigeny = idoigeny;
                        maxKor = kor;
                    }
                }
            }

            return maxIndex;
        }
        BinarisKeresofa AktualisFeladatokBeszurasa(IFeladat[] feladatok)
        {
            BinarisKeresofa aktualisFeladatok = new BinarisKeresofa();
            for (int i = 0; i < feladatok.Length; i++)
            {
                aktualisFeladatok.Beszuras(feladatok[i], feladatok[i].Prioritas);
            }

            return aktualisFeladatok;
        }
        public void NemBeutemezettFeladatok()
        {

        }
        public void FeladatVegrehajtas()
        {
            aktualisFeladatok.InorderBejaras(Elvegzes);
        }
        void Elvegzes(IFeladat feladat)
        {
            feladat.FeladatElvegzes();
        }
    }
}
