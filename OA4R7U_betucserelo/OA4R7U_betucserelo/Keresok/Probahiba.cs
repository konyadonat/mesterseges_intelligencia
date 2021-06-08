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

            while (!ut.Last().celfeltel())
            {
                Operator kivalasztottoperator = Operatorok[rnd.Next(0, Operatorok.Count)];
                if (kivalasztottoperator.Elofeltetel(ut.Last()))
                {
                    Allapot uj = kivalasztottoperator.atir(ut.Last());
                    ut.Add(uj);
                }
                
               
                
            }
            foreach (Allapot allapot in ut)
            {
                Ut.Add(allapot);
            }
        }
    }
}
