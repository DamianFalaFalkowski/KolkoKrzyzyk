using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace KolkoKrzyrzyk_Proj
{
    public class Gra
    {
        /// <summary>
        /// określa czyj trwa aktualnie ruch true - kółko, false - krzyżyk
        /// </summary>
        public bool CzyjRuch { get; private set; }

        /// <summary>
        /// określa czy gra została zakończona
        /// </summary>
        public bool CzySkończona { get; private set; }

        /// <summary>
        /// określa status gry
        /// </summary>
        public ObsługaGry.Status StatusGry { get; private set; }

        /// <summary>
        /// konstruktor - ustawia początkowe wartości
        /// </summary>
        public Gra()
        {
            CzyjRuch = true;
            CzySkończona = false;
            StatusGry = ObsługaGry.Status.trwa;
        }

        /// <summary>
        /// Obsługuje aktualizację gry po wykonaniu ruchu
        /// </summary>
        /// <param name="status">status gry, po zaktualizowaniu gry w klasie Plansza</param>
        public void WykonanoRuch(ObsługaGry.Status status)
        {
            StatusGry = status;

            if (status== ObsługaGry.Status.kółkowygrało ||
            status== ObsługaGry.Status.krzyżykwygrał ||
            status== ObsługaGry.Status.remis)
            {                    
                ZakończGrę();
            }
            else
            {
                CzyjRuch = !CzyjRuch;   
            }                           
        }

        /// <summary>
        /// Obsługuje zakończenie gry
        /// </summary>
        private void ZakończGrę()
        {
            CzySkończona = true;

            switch (StatusGry)
            {
                case ObsługaGry.Status.kółkowygrało:
                    MessageBox.Show("Kółko wygrało!");
                    break;
                case ObsługaGry.Status.krzyżykwygrał:
                    MessageBox.Show("Krzyżyk wygrał!");
                    break;
                case ObsługaGry.Status.remis:
                    MessageBox.Show("Remis!");
                    break;
                default:
                    break;
            }
        }            
    }   
}
