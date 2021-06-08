using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OA4R7U_betucserelo
{
    class Melysegi : Kereso
    {
        public Melysegi()
        {
            Kereses();
        }

        public override void Kereses()
        {
            Stack<Csomopont> nyiltcsucsok = new Stack<Csomopont>();
            List<Csomopont> zartcsucsok = new List<Csomopont>();

            nyiltcsucsok.Push(new Csomopont(new Allapot(), null));

            while(nyiltcsucsok.Count > 0 && !nyiltcsucsok.Peek().Allapot.celfeltel())
            {
                Csomopont aktualcsomopont = nyiltcsucsok.Pop();
                foreach (Operator _operator in Operatorok)
                {
                    if (_operator.Elofeltetel(aktualcsomopont.Allapot))
                    {
                        Allapot ujallapot = _operator.atir(aktualcsomopont.Allapot);
                        Csomopont ujcsomopont = new Csomopont(ujallapot, aktualcsomopont);

                        if (!nyiltcsucsok.Contains(ujcsomopont) && !zartcsucsok.Contains(ujcsomopont))
                            nyiltcsucsok.Push(ujcsomopont);
                    }
                }
                zartcsucsok.Add(aktualcsomopont);
            }

            if (nyiltcsucsok.Count > 0)
            {
                Csomopont celcsomopont = nyiltcsucsok.Peek();

                while (celcsomopont != null)
                {
                    this.Ut.Add(celcsomopont.Allapot);
                    celcsomopont = celcsomopont.Szulo;
                }
                this.Ut.Reverse();
            }
        }
    }
}
