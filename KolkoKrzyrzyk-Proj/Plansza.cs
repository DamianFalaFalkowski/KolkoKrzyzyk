using KolkoKrzyrzyk_Proj.Pola;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace KolkoKrzyrzyk_Proj
{
    public class Plansza : IDisposable
    {
        public bool CzyPlanszaJestZaladowana { get { return _sprawdźPlanszę(); } private set { } }

        private BazaPola[] Przyciski;

        public Plansza()
        {
            Przyciski = new BazaPola[9];
        }

        public void ZarejestrujPole(Button przycisk)
        {
            if (_sprawdźPrzycisk(przycisk))
            {
                Przyciski[Convert.ToInt16(przycisk.Tag)] = new Puste(przycisk);
            }
        }

        public void ZarejestrujPole(Button przycisk, TypPola typ)
        {
            if (_sprawdźPrzycisk(przycisk))
            {
                switch (typ)
                {
                    case TypPola.puste:
                        Przyciski[Convert.ToInt16(przycisk.Tag)] = new Puste(przycisk);
                        break;
                    case TypPola.kółko:
                        Przyciski[Convert.ToInt16(przycisk.Tag)] = new Kółko(przycisk);
                        break;
                    case TypPola.krzyżyk:
                        break;
                    default:
                        break;
                }               
            }
        }

        private bool _sprawdźPlanszę()
        {
            foreach (var przycisk in this.Przyciski)
            {
                if (przycisk==null)
                {
                    return false;
                }
            }
            return true;
        }

        private bool _sprawdźPrzycisk(Button przycisk)
        {
            try
            {
                // sprawdzam czy tag jest poprawny
                if (Convert.ToInt16(przycisk.Tag) < 9 && Convert.ToInt16(przycisk.Tag) >= 0)
                {
                    // sprawdzam czy zawartosc przycisku jest poprawna
                    if (przycisk.Content.GetType() == typeof(Image))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                throw new NotImplementedException("Błąd podczas sprawdzania poprawności przycisku");              
            }
            
        }

        public enum TypPola { puste, kółko, krzyżyk}
    }
}
