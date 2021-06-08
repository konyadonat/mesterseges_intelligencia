using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OA4R7U_betucserelo
{
    class Probahiba : Kereso
    {
        public Probahiba()
        {
            Kereses();
        }
        public override void Kereses()
        {
            Allapot kezdo = new Allapot();
            List<Allapot> ut = new List<Allapot>();

            ut.Add(kezdo);

            Random rnd = new Random();

            while (true)
            {
                Operator kivalasztottoperator = Operatorok[rnd.Next(0, Operatorok.Count)];
                if (kivalasztottoperator.Elofeltetel(ut.Last()))
                {
                    Allapot uj = kivalasztottoperator.atir(ut.Last());
                    if (uj.celfeltel())
                        break;
                    ut.Add(uj);
                }
                
               
                
            }
            for (int i = 0; i < ut.Count; i++)
            {
                Ut.Add(ut[i]);
            }
        }
    }
}
