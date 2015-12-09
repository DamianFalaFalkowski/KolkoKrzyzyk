using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace KolkoKrzyrzyk_Proj
{
    // statyczna klasa do starowania grą
    public static class ObsługaGry
    {
        private static Plansza _plansza { get; set; }

        private static Gra _gra { get; set; }

        public static void NowaGra()
        {
            if (_plansza.CzyPlanszaJestZaladowana)
            {
                _gra = new Gra();
                _plansza.PrzygotujPlanszę();               
                MessageBox.Show("Nowa gra rozpoczęta! Zaczyna kółko.");
            }
            else
            {
                throw new NotImplementedException("Plansza nie jest w pełni załadowana");
            }
        }

        public static void ZarejestrujPlanszę()
        {
            _plansza = new Plansza();
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

        public static void RuchWykonany(int tag)
        {
            // jeśli gra nie została jeszcze stworzone to nic nie rób
            if (_gra==null)
            {
                return;
            }
            // jeśli gra nie jest skończon to wykonaj ruch
            if ( !_gra.CzySkończona)
            {
                _gra.WykonanoRuch(_plansza.WykonanoRuch(tag, _gra.CzyjRuch));
            }
            else
            {
                MessageBox.Show("Aktualna gra jest już zakończona");
            }
        }

        public enum Status { kółkowygrało, krzyżykwygrał, remis, trwa }
    }
}
