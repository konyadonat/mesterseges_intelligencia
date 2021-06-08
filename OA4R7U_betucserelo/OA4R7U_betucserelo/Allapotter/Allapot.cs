using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OA4R7U_betucserelo
{
    class Allapot
    {
        public static string path = @"C:\Users\konya\Documents\GitHub\mesterseges_intelligencia\OA4R7U_betucserelo\OA4R7U_betucserelo\wordlist.txt";
        public string[] szavak = File.ReadAllLines(path);

        public static string kezdoszo = "mouse";
        private char[] karakterek = new char[5];

        public char[] Karakterek { get => karakterek; set => karakterek = value; }
        public static string vegszo = "tiger";

        public Allapot()
        {
            for (int i = 0; i < kezdoszo.Length; i++)
            {
                karakterek[i]=kezdoszo[i];
            }
        }

        public bool celfeltel()
        {
            for (int i = 0; i < vegszo.Length; i++)
            {
                if (!(karakterek[i] == vegszo[i]))
                {
                    return false;
                }
            }
            return true;
        }
        public override bool Equals(object obj)
        {
            Allapot masikallapot = (Allapot)obj;
            for (int i = 0; i < 5; i++)
            {
                if (karakterek[i] != masikallapot.karakterek[i])
                {
                    return false;
                }
            }
            return true;
        }
    }
}
