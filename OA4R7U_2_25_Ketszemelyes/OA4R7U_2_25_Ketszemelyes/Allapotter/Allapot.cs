using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OA4R7U_2_25_Ketszemelyes
{
    class Allapot
    {
        int[,] palya;

        int jatekos;

        int mezoallapot;

        public int Jatekos { get => jatekos; set => jatekos = value; }
        public int[,] Palya { get => palya; set => palya = value; }
        public int Mezoallapot { get => mezoallapot; set => mezoallapot = value; }

        public Allapot()
        {
            this.palya = new int[3, 3];
            this.jatekos = 1;
            this.mezoallapot = 0;
        }


        public int celfeltetel()
        {
            for (int i = 0; i < 3; i++)
            {
                if (palya[i,0]+
                    palya[i,1]+
                    palya[i,2] == 3)
                {
                    //player nyert
                    return 1;
                }
                else if(palya[i,0]+
                        palya[i,1]+
                        palya[i,2] == 3)
                {
                    //gép nyert
                    return -1;
                }
            }


            for (int i = 0; i < 3; i++)
            {
                if (palya[0, i] +
                    palya[1, i] +
                    palya[2, i] == 3)
                {
                    return 1;
                }
                else if (palya[0, i] +
                  palya[1, i] +
                  palya[2, i] == -3)
                {
                    return -1;
                }
            }

            if (palya[0, 0] +
                palya[1, 1] +
                palya[2, 2] == 3)
            {
                return 1;
            }

            if (palya[0, 0] +
                  palya[1, 1] +
                  palya[2, 2] == -3)
            {
                return -1;
            }

            if (palya[0, 2] +
                palya[1, 1] +
                palya[2, 0] == 3)
            {
                return 1;
            }

            if (palya[0, 2] +
                  palya[1, 1] +
                  palya[2, 0] == -3)
            {
                return -1;
            }

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (palya[i, j] == 0)
                    {
                        return 0;
                    }
                }
            }
            //még tart a játék
            return 2;
        }

        public int heurisztika()
        {
            int suly = 0;
            if (celfeltetel() == Jatekos)
            {
                return 100;
            }
            if (celfeltetel() == 1 || celfeltetel() == -1) 
            {
                if (celfeltetel() != Jatekos)
                {
                    return 80;
                }
            }
            for (int i = 0; i < 3; i++)
            {
                if (palya[i, 0] +
                    palya[i, 1] +
                    palya[i, 2] == 2)
                {
                    suly += 5;
                }
                else if (palya[i, 0] +
                  palya[i, 1] +
                  palya[i, 2] == -2)
                {
                    suly += 5;
                }
            }
            for (int i = 0; i < 3; i++)
            {
                if (palya[0, i] +
                    palya[1, i] +
                    palya[2, i] == 2)
                {
                    suly += 5;
                }
                else if (palya[0, i] +
                  palya[1, i] +
                  palya[2, i] == -2)
                {
                    suly += 5;
                }
            }

            if (palya[0, 0] +
                palya[1, 1] +
                palya[2, 2] == 2)
            {
                suly += 5;
            }

            if (palya[0, 0] +
                  palya[1, 1] +
                  palya[2, 2] == -2)
            {
                suly += 5;
            }

            if (palya[0, 2] +
                palya[1, 1] +
                palya[2, 0] == 2)
            {
                suly += 5;
            }

            if (palya[0, 2] +
                  palya[1, 1] +
                  palya[2, 0] == -2)
            {
                suly += 5;
            }

            return suly;
        }

    }
}
