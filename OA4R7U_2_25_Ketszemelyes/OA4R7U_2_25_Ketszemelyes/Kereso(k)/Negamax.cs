using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OA4R7U_2_25_Ketszemelyes
{
    class Negamax
    {

        int maxMelyseg = 2;

        public Operator ajanl(Allapot allapot)
        {
            List<Operator> ajanlottOperatorok = new List<Operator>();

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Operator aktOperator = new Operator(allapot.Jatekos, new System.Drawing.Point(i, j));
                    if (aktOperator.elofeltetel(allapot))
                    {
                        Allapot ujAllapot = aktOperator.lerak(allapot);
                        bejaras(ujAllapot, aktOperator, 0, 1);
                        ajanlottOperatorok.Add(aktOperator);
                    }
                }
            }

            ajanlottOperatorok = ajanlottOperatorok.OrderByDescending(o => o.Suly).ToList();

            return ajanlottOperatorok[0];
        }

        private void bejaras(Allapot allapot, Operator eredetiOperator, int melyseg, int elojel)
        {
            if (allapot.celfeltetel() == 1 || allapot.celfeltetel() == -1)
            {
                eredetiOperator.Suly = elojel * allapot.heurisztika();
            }
            else
            {
                if (melyseg < maxMelyseg)
                {
                    int max = Int32.MinValue;
                    for (int i = 0; i < 3; i++)
                    {
                        for (int j = 0; j < 3; j++)
                        {
                            Operator aktOperator = new Operator(allapot.Jatekos, new System.Drawing.Point(i, j));
                            if (aktOperator.elofeltetel(allapot))
                            {
                                Allapot ujAllapot = aktOperator.lerak(allapot);
                                int aktSuly = ujAllapot.heurisztika();
                                if (aktSuly > max)
                                {
                                    max = aktSuly;
                                }
                                bejaras(ujAllapot, aktOperator, melyseg + 1, -elojel);
                            }
                        }
                    }
                    eredetiOperator.Suly += max;
                }
            }
        }
    }
}
