using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace KoloKrzyzyk
{
    public partial class KolkoKrzyzyk : UserControl
    {
        Image kolko;
        Image krzyzyk;
       
        int wielkosc;
        // char uzytkownik;
        TypGry typGry;
        KolkoKrzyzyk graNadrzedna;

        TablicaWynikow tablicaWynikow;

        public KolkoKrzyzyk()
        {
            InitializeComponent();

            typGry = TypGry.wieloosobowa;
            tablicaWynikow = new TablicaWynikow();

         
            wielkosc = 170;
            

        }

        public void Inicjalizuj(Image kolko, Image krzyzyk)
        {
            this.kolko = kolko;
            this.krzyzyk = krzyzyk;
        }
        

        public void Start(TypGry typGry)
        {
            this.typGry = typGry;
            if (typGry == TypGry.podGra)
            {
                wielkosc = 50;
            }
            else
            {
                wielkosc = 170;
            }

            this.Controls.Clear();

            for (int y = 0; y < 3; y++)
            {
                for (int x = 0; x < 3; x++)
                {
                    if(typGry == TypGry.superGra)
                    {
                        DodajPodGre(x, y, this);
                    }
                    else
                    {
                        DodajPrzycisk(x, y);
                    }
                    
                }
            }
            tablicaWynikow = new TablicaWynikow();

        }


        public void Wyczysc()
        {
            this.Controls.Clear();
           

        }

        private void DodajPrzycisk(int indexX, int indexY)
        {
            
            var button = new System.Windows.Forms.Button();
            int locationX = 3 + (wielkosc + 3) * indexX;
            int locationY = 3 + (wielkosc + 3) * indexY;

            button.Location = new System.Drawing.Point(locationX, locationY);
            button.Name = ("btn" + (indexX + 1)) + (indexY + 1);
            button.Size = new System.Drawing.Size(wielkosc, wielkosc);
            button.TabIndex = 1;
            button.UseVisualStyleBackColor = true;
            button.Click += new System.EventHandler(this.btn_Click);

            this.Controls.Add(button);
        }

        private void DodajZnak(int indexX, int indexY, int x, int y, char type)
        {
            PictureBox pictureBox = new System.Windows.Forms.PictureBox();
            if(type == 'o')
            {
                pictureBox.Image = kolko;
            }
            else if (type == 'x')
            {
                pictureBox.Image = krzyzyk;
            }
        
            pictureBox.Location = new System.Drawing.Point(x, y);
            pictureBox.Name = "pictureBox"+ indexX.ToString()+ indexY.ToString();
            pictureBox.Size = new System.Drawing.Size(wielkosc, wielkosc);
            pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            pictureBox.TabIndex = 0;
            pictureBox.TabStop = false;
            this.Controls.Add(pictureBox);
        }

        private void KlikniecieWPrzycisk(Button btn)
        {
            int indexX = Int32.Parse(btn.Name[3] + "");
            int indexY = Int32.Parse(btn.Name[4] + "");

            DodajZnak(indexX, indexY, btn.Location.X, btn.Location.Y, Gra.getInstanca().GetUzytkownik());
            btn.Visible = false;
            tablicaWynikow.Ustaw(indexX - 1, indexY - 1, Gra.getInstanca().GetUzytkownik());
            Gra.getInstanca().WykonajRuch();

            Wynik wynik = tablicaWynikow.SprawdzWynik();

            if (typGry == TypGry.wieloosobowa)
            {
                if (wynik != Wynik.brak)
                {
                    WypiszWynik(wynik);
                    Wyczysc();
                }

            }
            else if (typGry == TypGry.jednoOsobowa)
            {
                if (wynik != Wynik.brak)
                {
                    WypiszWynik(wynik);
                    Wyczysc();
                }
                else
                {
                    int[] ruchKomputera = tablicaWynikow.RuchKomputera();
                    indexX = ruchKomputera[0]+1;
                    indexY = ruchKomputera[1]+1;
                    btn = (Button)this.Controls["btn" + indexX.ToString() + indexY.ToString()];

                    DodajZnak(indexX, indexY, btn.Location.X, btn.Location.Y, Gra.getInstanca().GetUzytkownik());
                    btn.Visible = false;
                    tablicaWynikow.Ustaw(indexX - 1, indexY - 1, Gra.getInstanca().GetUzytkownik());
                    Gra.getInstanca().WykonajRuch();
                    wynik = tablicaWynikow.SprawdzWynik();
                    if (wynik != Wynik.brak)
                    {
                        WypiszWynik(wynik);
                        Wyczysc();
                    }
                }

            }
            else if (typGry == TypGry.podGra)
            {
                if (wynik != Wynik.brak)
                {
                    indexX = Int32.Parse(this.Name[4] + "");
                    indexY = Int32.Parse(this.Name[3] + "");
                    graNadrzedna.GraNadrzedna(wynik, indexX, indexY, this.Location.X, this.Location.Y);
                    this.Visible = false;
                    //WypiszWynik(wynik);
                    //Wyczysc();
                }
            }
        }

        private void GraNadrzedna(Wynik wynik, int indexX, int indexY, int locX, int locY)
        {

            char w = '-';
            if(wynik == Wynik.wygrywaO)
            {
                w = 'o';
            }
            else if (wynik == Wynik.wygrywaX)
            {
                w = 'x';
            }

           tablicaWynikow.Ustaw(indexX - 1, indexY - 1, w);

            if (w == 'o' || w == 'x')
            {
                DodajZnak(indexX, indexY, locX, locY, w);
            }

            Wynik wynikGryNadrzednej = tablicaWynikow.SprawdzWynik();
            if (wynikGryNadrzednej != Wynik.brak)
            {
                WypiszWynik(wynikGryNadrzednej);
                Wyczysc();
            }
        }


        private void DodajPodGre(int indexX, int indexY, KolkoKrzyzyk graNadrzedna)
        {
            var kolkoKrzyzyk = new KolkoKrzyzyk();
            int locationX = 3 + (wielkosc + 3) * indexX;
            int locationY = 3 + (wielkosc + 3) * indexY;

            kolkoKrzyzyk.Location = new System.Drawing.Point(locationX, locationY);

            kolkoKrzyzyk.Name = "gra" + (indexX + 1) + (indexY + 1); ;
            kolkoKrzyzyk.Size = new System.Drawing.Size(wielkosc, wielkosc);
            kolkoKrzyzyk.TabIndex = 0;
            kolkoKrzyzyk.graNadrzedna = graNadrzedna;
            this.Controls.Add(kolkoKrzyzyk);
            kolkoKrzyzyk.Inicjalizuj(kolko, krzyzyk);
            kolkoKrzyzyk.Start(TypGry.podGra);
        }

        private void btn_Click(object sender, EventArgs e)
        {
            KlikniecieWPrzycisk((Button)sender);
        }
               

        private void WypiszWynik(Wynik wynik)
        {
            if(wynik == Wynik.wygrywaO)
            {
                System.Windows.Forms.MessageBox.Show("Wygrywa o");
            }
            else if (wynik == Wynik.wygrywaX)
            {
                System.Windows.Forms.MessageBox.Show("Wygrywa x");
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("Remis");
            }

        }

    }
}
