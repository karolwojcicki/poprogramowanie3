using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoloKrzyzyk
{
    public class Gra
    {
        int licznik;

       
        private static Gra instancja;
        private Gra()
        {
           
            licznik = 0;
        }

        public static Gra getInstanca()
        {
            if(instancja == null)
            {
                instancja = new Gra();
            }
            return instancja;
        }

        public char GetUzytkownik()
        {
            if(licznik % 2 == 0)
            {
                return 'o';
            }
            else
            {
                return 'x';
            }
            
        }

        public void WykonajRuch()
        {
            licznik++;
        }

        


    }
}
