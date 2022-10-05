using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Noppapeli
{
    class Noppa
    {
        //private Random rng = new Random();
        // property
        public int Luku;
        public int Koko;
        public PictureBox Boxi;

        // method
        public Noppa(int koko, PictureBox boxi) // constructor
        {
            Koko = koko;
            Luku = 1;
            //Heitto();
            Boxi = boxi;
            Boxi.Size = new Size(40,40);
            Boxi.SizeMode = PictureBoxSizeMode.Zoom;
        }
        public void Heitto(Random rng)
        { 
            Luku = rng.Next(1, Koko+1);
        }

        public string GetNoppaKey() // "N1" - "N6"
        {
            string returnValue = "N"; // Noppa picture filenames begin with Text "N" in NoppaPictures.resx

            return returnValue + Luku;
        }

        public static Image GetPictureResX(string key)
        {
            return Noppapeli.NoppaPictures.ResourceManager.GetObject(key) as Image;
        }
    }
}
