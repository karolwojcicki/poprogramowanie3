using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoloKrzyzyk
{
    public class TablicaWynikow
    {
        int licznik;
        char[,] pole;

        public TablicaWynikow()
        {
            pole = new char[3, 3];
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    pole[i, j] = '-';
                }
            }
                licznik = 0;
        }

        public void Ustaw(int x, int y, char uzytkownik)
        {
            pole[x, y] = uzytkownik;
            licznik++;
        }

        public Wynik SprawdzWynik()
        {
            Wynik wynik = SprawdzWynikPom();

            if (wynik!= Wynik.remis)
            {
                return wynik;
            }

            if (licznik < 9)
            {
                return Wynik.brak;
            }
            else return Wynik.remis;
        }

        public Wynik SprawdzWynikPom()
        {
            Wynik wynik;
            for (int i = 0; i < 3; i++)
            {
                wynik = SprawdzWynik(pole[i, 0], pole[i, 1], pole[i, 2]);
                if (wynik != Wynik.remis)
                {
                    return wynik;
                }
                wynik = SprawdzWynik(pole[0, i], pole[1, i], pole[2, i]);
                if (wynik != Wynik.remis)
                {
                    return wynik;
                }
            }

            wynik = SprawdzWynik(pole[0, 0], pole[1, 1], pole[2, 2]);
            if (wynik != Wynik.remis)
            {
                return wynik;
            }

            wynik = SprawdzWynik(pole[0, 2], pole[1, 1], pole[2, 0]);
            if (wynik != Wynik.remis)
            {
                return wynik;
            }

            return wynik;
        }

        private Wynik SprawdzWynik(char p1, char p2, char p3)
        {
            if (p1 == p2 && p2 == p3)
            {
                if (p1 == 'o')
                {
                    return Wynik.wygrywaO;
                }
                else if (p1 == 'x')
                {
                    return Wynik.wygrywaX;
                }
            }
            return Wynik.remis;
        }

/// <summary>
/// /////////////////////////////////////////////////
/// </summary>
/// <returns></returns>
        public int[] RuchKomputera()
        {
            int[] punkt = new int[2];
            punkt = SprawdzPotencjalneWygrane('x');
            if(punkt[0] != -1)
            {
                return punkt;
            }
            punkt = SprawdzPotencjalneWygrane('o');
            if (punkt[0] != -1)
            {
                return punkt;
            }
            
            return WylosujRuch();
        }


        private int[] SprawdzPotencjalneWygrane(char znak)
        {
            int[] punkt = new int[2];
            int wynik = -1;
            for (int i = 0; i < 3; i++)
            {
                wynik = SprawdzPotencjalnaWygrana(pole[i, 0], pole[i, 1], pole[i, 2], znak);
                if (wynik != -1)
                {
                    punkt[0] = i;
                    punkt[1] = wynik;
                    return punkt;
                }
                wynik = SprawdzPotencjalnaWygrana(pole[0, i], pole[1, i], pole[2, i], znak);
                if (wynik != -1)
                {
                    punkt[0] = wynik;
                    punkt[1] = i; 
                    return punkt;
                }
            }

            wynik = SprawdzPotencjalnaWygrana(pole[0, 0], pole[1, 1], pole[2, 2], znak);
            if (wynik != -1)
            {
                punkt[0] = wynik;
                punkt[1] = wynik;
                return punkt;
            }

            wynik = SprawdzPotencjalnaWygrana(pole[0, 2], pole[1, 1], pole[2, 0], znak);
            if (wynik != -1)
            {
                punkt[0] = wynik;
                punkt[1] = 2-wynik;
                return punkt;
            }

            punkt[0] = -1;
            punkt[1] = -1;

            return punkt;
        }

        private int SprawdzPotencjalnaWygrana(char p1, char p2, char p3, char znak)
        {

            if(p1 == '-' && p2 == znak && p3 == znak)
            {
                return 0;
            }
            if (p1 == znak && p2 == '-' && p3 == znak)
            {
                return 1;
            }
            if (p1 == znak && p2 == znak && p3 == '-')
            {
                return 2;
            }
            return -1;
        }

        private int[] WylosujRuch()
        {
            int[] punkt = new int[2];
            Random r = new Random(DateTime.Now.Millisecond);
            int rand = r.Next(0, 9 - licznik);
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if(pole[i, j] == '-')
                    {
                        if(rand == 0)
                        {
                            punkt[0] = i;
                            punkt[1] = j;
                            return punkt;
                        }
                        rand--;
                    }
                    
                }
            }
            punkt[0] = -1;
            punkt[1] = -1;
            return punkt;
        }


    }
}
