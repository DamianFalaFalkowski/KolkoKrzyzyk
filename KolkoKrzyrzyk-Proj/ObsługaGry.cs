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
        /// <summary>
        /// Obiekt planszy - odpowiada za poprawne wyświetlanie się planszy i określanie statusu gry
        /// </summary>
        private static Plansza _plansza { get; set; }

        /// <summary>
        /// Obiekt gry - odpowiada za kolejność wykonywania ruchów, stwierdzanie czy gra się skończyła i prezentację statusu gry 
        /// </summary>
        private static Gra _gra { get; set; }

        /// <summary>
        /// Metoda rozpoczynająca nową grę
        /// </summary>
        public static void NowaGra()
        {
            // najpierw sprawdza czy plansza poprawnie się załadowała
            if (_plansza.CzyPlanszaJestZaladowana)
            {
                // tworzy nowy obiekt gry
                _gra = new Gra();

                // przygotowuje planszę(zamienia kółka i krzyżyki o ile są na planszy na puste pola)
                _plansza.PrzygotujPlanszę();
               
                MessageBox.Show("Nowa gra rozpoczęta! Zaczyna kółko.");
            }
            else
            {
                // jeśli plansza nie jest załadowana to wyrzuć błąd
                throw new NotImplementedException("Plansza nie jest w pełni załadowana");
            }
        }

        /// <summary>
        /// Tworzy nowy obiekt planszy
        /// </summary>
        public static void ZarejestrujPlanszę()
        {
            _plansza = new Plansza();
        }

        /// <summary>
        /// Tworzy pole
        /// </summary>
        /// <param name="przycisk">przykisk który ma stać się polem(musi zawierać Tag o watrości {0,8} i Image w swoim Contencie)</param>
        public static void ZarejestrujPole(Button przycisk)
        {
            if (_plansza != null)
            {
                _plansza.ZarejestrujPole(przycisk);
            }
            else
            {
                // jeśli nie ma planszy to wyrzuć błąd
                throw new NotImplementedException("Plansza nie została zarejestrowana!!!");
            }           
        }

        /// <summary>
        /// Obsługa wykonanego ruchu
        /// </summary>
        /// <param name="tag">Tag pola które zostało kilknięte</param>
        public static void RuchWykonany(int tag)
        {
            // jeśli gra nie została jeszcze stworzona to nic nie rób
            if (_gra==null)
            {
                return;
            }
            // jeśli gra nie jest skończon to wykonaj ruch
            if ( !_gra.CzySkończona)
            {
                if (_plansza.CzyPolejestPuste(tag))
                {
                    _gra.WykonanoRuch(_plansza.WykonanoRuch(tag, _gra.CzyjRuch));
                }                
            }
            else
            {
                // jeśli jednak jest skończone to wyświetl wiadomość
                MessageBox.Show("Aktualna gra jest już zakończona");
            }
        }

        public enum Status { kółkowygrało, krzyżykwygrał, remis, trwa }
    }
}
