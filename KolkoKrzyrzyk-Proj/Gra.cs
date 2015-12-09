using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KolkoKrzyrzyk_Proj
{
    public class Gra
    {
        /// <summary>
        /// true - kółko, false - krzyżyk
        /// </summary>
        public bool CzyjRuch { get; private set; }

        public bool CzySkończona { get; private set; }

        public Wynik WynikGry { get; private set; }

        public Gra()
        {
            CzyjRuch = true;
            CzySkończona = false;
        }

        public void WykonanoRuch()
        {
            CzyjRuch = !CzyjRuch;
        }

        public void ZakończGrę(Wynik wynik)
        {
            CzySkończona = true;
            WynikGry = wynik;
        }

        public enum Wynik { kółko, krzyżyk, remis}
    }
}
