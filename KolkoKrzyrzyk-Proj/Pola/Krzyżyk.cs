using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace KolkoKrzyrzyk_Proj.Pola
{
    public class Krzyżyk : BazaPola, IDisposable
    {
        private static string _krzyżykImage = "Images/img_krzyżyk.png";

        public Krzyżyk(Button przycisk)
            : base(przycisk)
        {
            base.TypPola = Plansza.TypPola.krzyżyk;
            base.ObrazekSource = new BitmapImage(new Uri(_krzyżykImage, UriKind.Relative));
        }

        public Krzyżyk(BazaPola starePole)
            : base(starePole)
        {
            base.TypPola = Plansza.TypPola.krzyżyk;
            base.ObrazekSource = new BitmapImage(new Uri(_krzyżykImage, UriKind.Relative));
        }

        public override void Dispose()
        {
            base.Dispose();
        }
    }
}
