using System;
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
        private static string _kółkoImage = "";

        public Kółko(Button przycisk)
            : base(przycisk)
        {
            base.TypPola = Plansza.TypPola.kółko;
            base.ObrazekSource = new BitmapImage(new Uri(_kółkoImage));
        }

        public override void Dispose()
        {
            base.Dispose();
        }
    }
}
