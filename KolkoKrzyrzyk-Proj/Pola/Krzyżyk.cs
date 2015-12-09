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
        private static string _krzyżykImage = "";

        public Krzyżyk(Button przycisk)
            : base(przycisk)
        {
            base.TypPola = Plansza.TypPola.krzyżyk;
            base.ObrazekSource = new BitmapImage(new Uri(_krzyżykImage));
        }

        public override void Dispose()
        {
            base.Dispose();
        }
    }
}
