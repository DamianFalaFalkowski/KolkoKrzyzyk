﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace KolkoKrzyrzyk_Proj.Pola
{
    public class Kółko : BazaPola, IDisposable
    {
        // ścirżka do obrazku kółka
        private static string _kółkoImage = "Images/img_kółko.png";

        // konstruktor 1 opierający się na konstruktorze z klasy bazowej czyli BazaPola
        public Kółko(Button przycisk)
            : base(przycisk)
        {
            base.TypPola = Plansza.TypPola.kółko;
            base.ObrazekSource = new BitmapImage(new Uri(_kółkoImage, UriKind.Relative));
        }

        // konstruktor 2 opierający się na konstruktorze z klasy bazowej czyli BazaPola
        public Kółko(BazaPola starePole)
            : base(starePole)
        {     
            base.TypPola = Plansza.TypPola.kółko;
            base.ObrazekSource = new BitmapImage(new Uri(_kółkoImage, UriKind.Relative));
        }

        public override void Dispose()
        {
            base.Dispose();
        }
    }
}
