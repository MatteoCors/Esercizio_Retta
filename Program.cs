using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esercizio_Retta
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Retta r = new Retta();
            r.M = 5;
            r.Q = 12;
            Console.WriteLine("Il punto (0, 12) appartiene alla retta = {0}", r.Contains(0, 12));
            Console.WriteLine("Il punto (7, 9) appartiene alla retta = {0}", r.Contains(7, 9));

            int puntiIntersezione;
            float x1;
            float y1;
            r.Intersect(19, 8, out puntiIntersezione, out x1, out y1);
            StampaIntersezioni(puntiIntersezione, x1, y1);
            r.Intersect(5, 12, out puntiIntersezione, out x1, out y1);
            StampaIntersezioni(puntiIntersezione, x1, y1);
            r.Intersect(5, 10, out puntiIntersezione, out x1, out y1);
            StampaIntersezioni(puntiIntersezione, x1, y1);

            Console.ReadKey();
        }
        static void StampaIntersezioni(int puntiIntersezione, float x1, float y1)
        {
            if (puntiIntersezione == 0)
            {
                Console.WriteLine("Nessuna intersezione");
            }
            else if (puntiIntersezione == 2)
            {
                Console.WriteLine("Infiniti punti di intersezione");
            }
            else
            {
                Console.WriteLine("Intersezioni: {0}, in {1}, {2}", puntiIntersezione, x1, y1);
            }
        }
    }
    public class Retta
    {
        public float M { get; set; }
        public float Q { get; set; }
        public bool Contains (float x, float y)
        {
            return M * x + Q == y;
        }
        public void Intersect(float M2, float Q2, out int puntiIntersezione, out float x1, out float y1)
        {
            if(M == M2 && Q != Q2)
            {
                puntiIntersezione = 0;
                x1 = float.NaN; 
                y1 = float.NaN;
            }
            else if(M == M2 && Q == Q2)
            {
                puntiIntersezione = 2;
                x1 = float.NaN;
                y1 = float.NaN;
            }
            else
            {
                x1 = (Q - Q2) / (M2 - M);
                y1 = M2 * x1 + Q2;
                puntiIntersezione = 1;
            }
        }
    }
}
