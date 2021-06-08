using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OA4R7U_betucserelo
{
    class Backtrack : Kereso
    {
        public Backtrack()
        {
            Kereses();
        }
        public override void Kereses()
        {
            Stack<Csomopont> ut = new Stack<Csomopont>();
            ut.Push(new Csomopont(new Allapot(), 0));

            while (ut.Count > 0 && !ut.Peek().Allapot.celfeltel())
            {
                Csomopont aktual = ut.Peek();
                if (aktual.OperatorIndex < Operatorok.Count)
                {
                    Operator aktualop = Operatorok[aktual.OperatorIndex];
                    if (aktualop.Elofeltetel(aktual.Allapot))
                    {
                        Allapot uj = aktualop.atir(aktual.Allapot);
                        Csomopont ujcsomo = new Csomopont(uj, 0);
                        if (!ut.Contains(ujcsomo))
                            ut.Push(ujcsomo);
                    }
                    aktual.OperatorIndex++;
                }
                else
                    ut.Pop();
            }
            foreach (Csomopont csomopont in ut)
                Ut.Add(csomopont.Allapot);
            Ut.Reverse();
        }
        
    }
}
