using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Noppapeli
{
    // Luo luokka "Noppa", jossa on tallessa nopan arvo 1-6
    // nopalla on myös "Heitto"-metodi, joka arpoo sille arvon 1-6
    // Anna nopalle myös constructor-metodi, joka heti alussa arpoo arvon

    // Lähde tekemään Yatzi-peli

    // Lisää nopalle kuvat 1-6

    public partial class Form1 : Form
    {
        // property
        private Random rng = new Random();
        //Noppa noppa1 = new Noppa(6);
        List<Noppa> Nopat = new List<Noppa>();
        public Form1() // constructor, suoritetaan heti alussa
        {
            InitializeComponent();
            // luodaan 5 noppaa
            for (int i = 0; i < 5; i++)
            {
                PictureBox tempPB = new PictureBox();

                this.Controls.Add(tempPB);

                Noppa tempNoppa = new Noppa(6, tempPB);

                Nopat.Add(tempNoppa);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // for käy läpi kaikki listan nopat
            for (int i = 0; i < Nopat.Count; i++)
            {
                Nopat[i].Heitto(rng);
                editPictureBox(Nopat[i], i);
                //label1.Text = noppa1.Luku.ToString();
            }
            //noppa1.Heitto();
            //editPictureBox(noppa1, 1);
            //label1.Text = noppa1.Luku.ToString();
            // lisää nopalle property "Koko", jolla määritellään
            // montako silmälukua nopalla on
            // ja käytetään sitä luvun arvonnassa
            // nopan koko annetaan sitä generoidessa
        }

        private void editPictureBox(Noppa jokuNoppa, int count)
        {
            const int spacing = 60;

            string key = jokuNoppa.GetNoppaKey();
            jokuNoppa.Boxi.Image = Noppa.GetPictureResX(key);
            jokuNoppa.Boxi.Location = new
                Point(13 + count * spacing, 13);
        }

        
        private void buttonOnes_Click(object sender, EventArgs e)
        {
            // Käy läpi Nopat-listan ja summaa kaikki ykköset

            // lista
            // elementti - 0 indeksi => i muuttuja käy läpi kaikki indeksit silmukassa
            // elementti - 1 indeksi
            // elementti - 2 indeksi
            // elementti - 3 indeksi
            // elementti - 3 indeksi

            // Muistakaa listassa on Noppa luokan objektejä
            // Jokaisella objektilla on tallessa property osiossa oma luku
            // esim: nopat[i].Luku

            // muuttuja, johon tulee summa talteet, oletuksena = 0
            // käydään läpi lista, eli tarvitaan silmukka
            // tarkistetaan onko nopan luku yksi, if-else
            //       indeksi vaihtuu joka kierros, eli tarkistetaan
            //      eri elementtiä<
            // jos totta, lisätään nopan luku summaan

            int summa = 0;

            for (int i = 0; i < Nopat.Count; i++)
            {
                if (Nopat[i].Luku == 1)
                {
                    summa += Nopat[i].Luku;
                }
            }

            buttonOnes.Text = summa.ToString();
        }

        private void buttonTwos_Click(object sender, EventArgs e)
        {
            int summa = 0;

            for (int i = 0; i < Nopat.Count; i++)
            {
                if (Nopat[i].Luku == 2)
                {
                    summa += Nopat[i].Luku;
                }
            }

            buttonTwos.Text = summa.ToString();
        }
        private void buttonThrees_Click(object sender, EventArgs e)
        {
            int summa = 0;

            for (int i = 0; i < Nopat.Count; i++)
            {
                if (Nopat[i].Luku == 3)
                {
                    summa += Nopat[i].Luku;
                }
            }

            buttonThrees.Text = summa.ToString();
        }
        private void buttonFours_Click(object sender, EventArgs e)
        {
            int summa = 0;

            for (int i = 0; i < Nopat.Count; i++)
            {
                if (Nopat[i].Luku == 4)
                {
                    summa += Nopat[i].Luku;
                }
            }

            buttonFours.Text = summa.ToString();
        }

        private void buttonFives_Click(object sender, EventArgs e)
        {
            int summa = 0;

            for (int i = 0; i < Nopat.Count; i++)
            {
                if (Nopat[i].Luku == 5)
                {
                    summa += Nopat[i].Luku;
                }
            }

            buttonFives.Text = summa.ToString();
        }

        private void buttonSixes_Click(object sender, EventArgs e)
        {
            int summa = 0;

            for (int i = 0; i < Nopat.Count; i++)
            {
                if (Nopat[i].Luku == 6)
                {
                    summa += Nopat[i].Luku;
                }
            }

            buttonSixes.Text = summa.ToString();
        }

        private void buttonPair_Click(object sender, EventArgs e)
        {
           
            int[] pairs = new int[6]; // count how many of each dice value is found
            
            int[] pairValues = new int[6];
            const int multiplier = 2; // number of dices found, is only multiplied by 2, since you get points for the pair
            // 0 - 5
            for (int i = 0; i < pairs.Length; i++)
            {
                // linQ kirjaston metodeja
                pairs[i] = Nopat.Where(test => 
                    test.Luku == i + 1).Count();
            }

            for (int i = 0; i < pairs.Length; i++)
            {
                if (pairs[i] > 1) // lasketaan vain parit + yli
                {
                    // tarkistetaan, että löytyi 2 paria
                    pairValues[i] = (i + 1) * multiplier;
                }
            }
            // {0, 4, 0, 8, 0, 0}
            buttonPair.Text = pairValues.Max().ToString();

            // päivitetään summa napin teksti
        }

        private void buttonTwoPairs_Click(object sender, EventArgs e)
        {
            //  1  2  3  4  5  6 silmäluvut
            // [2, 0, 1, 2, 0, 0]
            //  0  1  2  3  4  5  indeksit

            int[] pairs = new int[6]; // count how many of each dice value is found
            int[] pairValues = new int[6];
            const int multiplier = 2; // number of dices found, is only multiplied by 2, since you get points for the pair
            int pareja = 0;

            for (int i = 0; i < pairs.Length; i++)
            {
                // linQ kirjaston metodeja
                pairs[i] = Nopat.Where(noppa =>  noppa.Luku == i + 1).Count();
            }

            for (int i = 0; i < pairs.Length; i++)
            {
                if (pairs[i] > 1) // lasketaan vain parit + yli
                {
                    // otetaan talteen, että pari on löytynyt

                    pareja++;


                    pairValues[i] = (i + 1) * multiplier;
                }
            }

            if (pareja == 2)
            {
                buttonTwoPairs.Text = pairValues.Sum().ToString();
            }
            else
            {
                buttonTwoPairs.Text = "0";
            }
            // {0, 4, 0, 8, 0, 0}
            //buttonTwoPairs.Text = pairValues.Max().ToString();
        }

        private void button3OfKind_Click(object sender, EventArgs e)
        {
            

            int[] pairs = new int[6]; // count how many of each dice value is found
            int[] pairValues = new int[6];
            const int multiplier = 3; // number of dices found, is only multiplied by 2, since you get points for the pair
            

            for (int i = 0; i < pairs.Length; i++)
            {
                // linQ kirjaston metodeja
                pairs[i] = Nopat.Where(noppa => noppa.Luku == i + 1).Count();
            }

            for (int i = 0; i < pairs.Length; i++)
            {
                if (pairs[i] > 2) // lasketaan vain 3 samaa + yli
                {
                    pairValues[i] = (i + 1) * multiplier;
                }
            }
            button3OfKind.Text = pairValues.Max().ToString();
        }

        private void button4OfKind_Click(object sender, EventArgs e)
        {
            int[] pairs = new int[6]; // count how many of each dice value is found
            int[] pairValues = new int[6];
            const int multiplier = 4; // number of dices found, is only multiplied by 2, since you get points for the pair


            for (int i = 0; i < pairs.Length; i++)
            {
                // linQ kirjaston metodeja
                pairs[i] = Nopat.Where(noppa => noppa.Luku == i + 1).Count();
            }

            for (int i = 0; i < pairs.Length; i++)
            {
                if (pairs[i] > 3)
                {
                    pairValues[i] = (i + 1) * multiplier;
                }
            }
            button4OfKind.Text = pairValues.Max().ToString();
        }

        private void buttonSmallStraight_Click(object sender, EventArgs e)
        {
            bool smallStraight = true;

            //List<int> numerot = new List<int> { 2, 3, 1, 5, 4 };

            for (int i =1; i < 5; i++)
            {
                if (Nopat.Where(noppa => noppa.Luku == i).Count() == 0) // list does not have a one
                {
                    smallStraight = false;
                }
            }

            

            // numbers 2-5

            // points
            if (smallStraight == true)
            {
                buttonSmallStraight.Text = "30";
            }
            else
            {
                buttonSmallStraight.Text = "0";
            }
        }
    }
}
