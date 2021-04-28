using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HZWR41_FF
{
    /*
     * KÉRDÉSEK:
     *  - Hogyan adjuk át minden kör elején az új feladatokat?
     *      Vagy az elején hozzáadunk minden feladatot különböző korral?
     */


    class CPU
    {
        BinarisKeresofa aktualisFeladatok; //adott korben elvegzendo, prioritas szerint rendezve
        int idokapacitas;

        ForditvaRendezettLancoltLista[] osszesFeladat;
        List<List<IFeladat>> lehetsegesEsetek; // nem biztos hogy kell

        public CPU()
        {
            idokapacitas = 10;
            osszesFeladat = new ForditvaRendezettLancoltLista[idokapacitas + 1];
            lehetsegesEsetek = new List<List<IFeladat>>();
            for (int i = 0; i < osszesFeladat.Length; i++)
            {
                osszesFeladat[i] = new ForditvaRendezettLancoltLista();
            }

        }

        void CPUFeladatUtemezo(List<IFeladat> ujFeladatok)
        {
            // Kell egy külső metódus, amit meghívunk a Mainből, ami addig hívogatja a feladatütemezőt, amíg van feladat
            // txt-ből beolvasás, delegálton keresztül átadni neki a StreamReadert ?

            UjFeladatokFelvetele(ujFeladatok); //rendezett beszúrás --- Kell?

            /* Ütemezés
             * 
             * 1. Megnézzük, hogy van-e olyan összeállítás, ami kihasználja a maximális kapacitást
             * 2. Ha van, akkor megkeressük ezekből a legidősebb feladatokat végrehajtó variációt
             * 3. Ha nincs, akkor tovább keressük a minél nagyobb igényű összeállítást
             * 
             */

            int aktualisMaxKapacitas = idokapacitas; // ezt csökkentjük, ha nem találunk az adott idokapacitásra megoldást

            for (int i = 0; i <= (aktualisMaxKapacitas + 1)/ 2; i++) // (10 + 1) / 2 = 5.5 -> 5     (9 + 1) / 2 = 5 
            {
                int idx = aktualisMaxKapacitas - i;
                if (osszesFeladat[i] != null && osszesFeladat[idx] != null)
                {
                    lehetsegesEsetek.Add(null);
                }
            }






            //if (osszesFeladat != null)
            //{
                // elvegzendo feladatok kivalasztasa --> aktualisFeladatokba betenni

                /*
                 *  Vegigmegyunk az aktualis feladatokon:
                 *   esemeny meghivasa
                 *   elvegezve = true;
                 */

                /*
                 *  Vegigmegyunk a tobbi feladaton
                 *   hanyszimulacioskorotael++
                 */
            //}
        }

        void Utemezo()
        {
            List<IFeladat>[] oMegoldasok = new List<IFeladat>[idokapacitas + 1]; // 11 

            for (int i = 1; i < osszesFeladat.Length; i++)
            {
                oMegoldasok[i] = null;
            }
        }

        List<IFeladat> OptimalisMegoldas(int idoigeny)
        {
            ForditvaRendezettLancoltLista[] feladatok = osszesFeladat;
            OptimalisReszmegoldas[] reszmegoldasok = new OptimalisReszmegoldas[idokapacitas + 1];
            for (int i = 0; i < reszmegoldasok.Length; i++)
            {
                reszmegoldasok[i].Feladatok = new ForditvaRendezettLancoltLista();
            }

            if (idoigeny == 1)
            {
                reszmegoldasok[1].Feladatok.Beszuras(feladatok[idoigeny].Fej.tartalom, feladatok[idoigeny].Fej.kulcs);
                feladatok[idoigeny].TorlesElsoElem();
            }
            else
            {
                if (true)
                {

                }
            }
            return null;
        }

        void UjFeladatokFelvetele(List<IFeladat> ujFeladatok)
        {
            foreach (IFeladat f in ujFeladatok)
            {
                if (f.Idoigeny > idokapacitas)
                {
                    throw new TulNagyFeladatKivetel($"A feladat időigénye meghaladja a CPU kapacitását");
                }
                else
                {
                    osszesFeladat[f.Idoigeny].Beszuras(f, f.HanySzimulaciosKorOtaEl);
                }
            }
        }
        IFeladat[] Egyesites(IFeladat[] x, IFeladat[] y)
        {
            IFeladat[] unio = new IFeladat[x.Length + y.Length];
            int i = 0;
            while (i < x.Length)
            {
                unio[i] = x[i];
                i++;
            }
            int j = 0;
            while (i < unio.Length)
            {
                unio[i] = y[j];
                i++;
                j++;
            }
            return unio;
        }
        BinarisKeresofa FeladatKivalaszto(IFeladat[] feladatok) // rendezve kor szerint (kor szerint keresünk)
        {
            LinkedList<IFeladat> megoldas = new LinkedList<IFeladat>();

            int i = feladatok.Length - 1;
            int k = idokapacitas;
            while (i >= 0 || k > 0)
            {
                if (feladatok[i].Idoigeny >= k)
                {
                    megoldas.AddLast(feladatok[i]);
                    k -= feladatok[i].Idoigeny;
                    i--;
                }
                else i--;
            }
            if (k == 0)
            {
                return ListabolFa(megoldas);
            }


            return null;
        }
        BinarisKeresofa ListabolFa(LinkedList<IFeladat> lista)
        {
            BinarisKeresofa fa = new BinarisKeresofa();
            foreach (IFeladat f in lista)
            {
                fa.Beszuras(f, f.Prioritas); // prioritás szerint
            }
            return fa;
        }
        int MaxKivalasztasKor(IFeladat[] y)
        {
            int maxIndex = 0;
            int maxErtek = y[0].HanySzimulaciosKorOtaEl;
            for (int i = 0; i < y.Length; i++)
            {
                if (y[i].HanySzimulaciosKorOtaEl > maxErtek)
                {
                    maxIndex = i;
                    maxErtek = y[i].HanySzimulaciosKorOtaEl;
                }
            }
            return maxIndex;
        }
    }
}
