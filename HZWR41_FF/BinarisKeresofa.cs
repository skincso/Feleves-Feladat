using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                this.Tartalom = tartalom;
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

        public IFeladat Kereses(int kulcs)
        {
            return _Kereses(gyoker, kulcs);
        }

        IFeladat _Kereses(FaElem p, int kulcs)
        {
            if (p != null)
            {
                if (p.Kulcs > kulcs)
                {
                    return _Kereses(p.bal, kulcs);
                }
                else if (p.Kulcs < kulcs)
                {
                    return _Kereses(p.jobb, kulcs);
                }
                else
                {
                    return p.Tartalom;
                }
            }
            else
            {
                throw new ArgumentException("Nincs ilyen prioritasu elem");
            }
        }

        public void Torles(int kulcs)
        {
            _Torles(ref gyoker, kulcs);
        }

        void _Torles(ref FaElem p, int kulcs)
        {
            if (p != null)
            {
                if (p.Kulcs > kulcs)
                {
                    _Torles(ref p.bal, kulcs);
                }
                else if (p.Kulcs < kulcs)
                {
                    _Torles(ref p.jobb, kulcs);
                }
                else if (p.bal == null)
                {
                    p = p.jobb;
                }
                else if (p.jobb == null)
                {
                    p = p.bal;
                }
                else _TorlesKetGyerek(p, ref p.bal);
            }
            else
            {
                throw new ArgumentException("Nincs ilyen prioritasu feladat");
            }
        }

        void _TorlesKetGyerek(FaElem e, ref FaElem r) // e -> p, r -> p.bal
        {
            if (r.jobb != null)
            {
                _TorlesKetGyerek(e, ref r.jobb);
            }
            else
            {
                e.Tartalom = r.Tartalom;
                e.Kulcs = r.Kulcs;
                r = r.bal;
            }
        }
    }
}
