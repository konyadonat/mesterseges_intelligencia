using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OA4R7U_betucserelo
{
    class Optimalis : Kereso
    {
        public Optimalis()
        {
            Kereses();
        }
        public override void Kereses()
        {
            List<Csomopont> ut = new List<Csomopont>();
            ut.Add(new Csomopont(new Allapot(), null));

            while (ut.Count > 0 && !ut.Last().Allapot.celfeltel())
            {
                Csomopont aktual = ut.Last();
                ut.RemoveAt(ut.Count - 1);
                foreach (Operator _operator in Operatorok)
                {
                    if (_operator.Elofeltetel(aktual.Allapot))
                    {
                        Allapot ujallapot = _operator.atir(aktual.Allapot);
                        Csomopont ujcsomopont = new Csomopont(ujallapot, aktual);

                        if (!ut.Contains(ujcsomopont))
                        {
                            ut.Add(ujcsomopont);
                        }

                        else
                        {
                            int i = ut.IndexOf(ujcsomopont);
                            Csomopont regicsomopont = ut[i];

                            if (regicsomopont.Koltseg > ujcsomopont.Koltseg)
                            {
                                ut[i] = ujcsomopont;
                            }
                        }

                    }
                }
                ut.Sort(
                    delegate (Csomopont cs1, Csomopont cs2)
                    {
                        if (cs1.Koltseg > cs2.Koltseg)
                            return -1;
                        else if (cs1.Koltseg < cs2.Koltseg)
                            return 1;
                        else
                            return 0;
                        
                    });


            }
            if(ut.Count > 0)
            {
                Csomopont celcsomopont = ut.Last();
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
