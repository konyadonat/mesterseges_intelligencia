using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OA4R7U_betucserelo
{
    class Program
    {
        static void Main(string[] args)
        {
            string beirt;
            do
            {
                Console.WriteLine("Adott kereső használatához írja be a kereső kezdőbetűjét!");
                Console.WriteLine("Mélységi - m");
                Console.WriteLine("Próba-hiba módszer - p");
                Console.WriteLine("Backtrack - b");
                Console.WriteLine("Kilépés - e");
                beirt = Console.ReadLine();

                if (beirt == "m")
                    Kiir(new Melysegi());
                if (beirt == "p")
                    Kiir(new Probahiba());
                

                
            } while (beirt != "e");
            



        }
        public static void Kiir(Kereso kereso)
        {
            foreach (Allapot allapot in kereso.Ut)
            {
                for (int i = 0; i < 5; i++)
                {
                    Console.Write(allapot.Karakterek[i]);
                }
                Console.WriteLine();
            }
            Console.WriteLine("Lépések száma: "+kereso.Ut.Count);
        }
    }
}
