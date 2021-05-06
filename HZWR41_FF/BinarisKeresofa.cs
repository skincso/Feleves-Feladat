using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HZWR41_FF.Feladatok;

namespace HZWR41_FF
{
    class BinarisKeresofa
    {
        class FaElem
        {
            public IFeladat Tartalom { get; set; }
            public int Kulcs { get; set; }
            public FaElem bal;
            public FaElem jobb;
            public FaElem(IFeladat tartalom, int kulcs)
            {
                Tartalom = tartalom;
                Kulcs = kulcs;
            }
        }

        FaElem gyoker;

        public void Beszuras(IFeladat tartalom, int kulcs)
        {
            _Beszuras(ref gyoker, tartalom, kulcs);
        }
        void _Beszuras(ref FaElem p, IFeladat tartalom, int kulcs)
        {
            if (p == null)
            {
                p = new FaElem(tartalom, kulcs);
            }
            else if (p.Kulcs >= kulcs)
            {
                _Beszuras(ref p.bal, tartalom, kulcs);
            }
            else if (p.Kulcs < kulcs)
            {
                _Beszuras(ref p.jobb, tartalom, kulcs);
            }
        }
        public void InorderBejaras(FeladatVegrehajtasKezelo metodus)
        {
            _InorderBejaras(gyoker, metodus);
        }
        void _InorderBejaras(FaElem aktualis, FeladatVegrehajtasKezelo metodus)
        {
            if (aktualis != null)
            {
                _InorderBejaras(aktualis.bal, metodus);
                metodus?.Invoke(aktualis.Tartalom);
                _InorderBejaras(aktualis.jobb, metodus);
            }
        }
    }
}
