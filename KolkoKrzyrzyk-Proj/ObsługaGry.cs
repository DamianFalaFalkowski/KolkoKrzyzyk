using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace KolkoKrzyrzyk_Proj
{
    // statyczna klasa do starowania grą
    public static class ObsługaGry
    {
        private static Plansza _plansza { get; set; }

        private static Gra _gra { get; set; }

        public static void NowaGra(Gra gra)
        {
            _gra = gra;
        }

        public static void ZarejestrujPlanszę(Plansza plansza)
        {
            _plansza = plansza;
        }

        public static void ZarejestrujPole(Button przycisk)
        {
            if (_plansza != null)
            {
                _plansza.ZarejestrujPole(przycisk);
            }
            else
            {
                throw new NotImplementedException("Plansza nie została zarejestrowana!!!");
            }           
        }
    }
}
