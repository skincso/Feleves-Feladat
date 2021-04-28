using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HZWR41_FF
{

    class ListaElem
    {
        public IFeladat tartalom { get; set; }
        public int kulcs { get; set; }
        public ListaElem kovetkezo { get; set; }

        public ListaElem(IFeladat tartalom, int kulcs)
        {
            this.tartalom = tartalom;
            this.kulcs = kulcs;
        }
    }
    class ForditvaRendezettLancoltLista
    {

        public ListaElem Fej { get; private set; }

        public void Beszuras(IFeladat tartalom, int kulcs)
        {
            ListaElem uj = new ListaElem(tartalom, kulcs);
            ListaElem p = Fej;
            ListaElem e = null;
            while (p != null && p.kulcs > kulcs)
            {
                e = p;
                p = p.kovetkezo;
            }
            if (e == null)
            {
                uj.kovetkezo = Fej;
                Fej = uj;
            }
            else
            {
                uj.kovetkezo = p;
                e.kovetkezo = uj;
            }
        }

        public void TorlesElsoElem()
        {
            Fej = Fej.kovetkezo;
        }

    }
}
