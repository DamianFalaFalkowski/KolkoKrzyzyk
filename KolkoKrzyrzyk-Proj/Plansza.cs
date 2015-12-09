using KolkoKrzyrzyk_Proj.Pola;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace KolkoKrzyrzyk_Proj
{ 
    public class Plansza
    {
        /// <summary>
        /// Kombinacje ułożeń które wygrywają
        /// </summary>
        public static readonly List<bool[]> ListaWygranychUłożeń = new List<bool[]>(){
            new bool[9] {true, true, true, false, false, false, false, false, false},
            new bool[9] {false, false, false, true, true, true, false, false, false},
            new bool[9] {false, false, false, false, false, false, true, true, true},
            new bool[9] {true, false, false, true, false, false, true, false, false},
            new bool[9] {false, true, false, false, true, false, false, true, false},
            new bool[9] {false, false, true, false, false, true, false, false, true},
            new bool[9] {true, false, false, false, true, false, false, false, true},
            new bool[9] {false, false, true, false, true, false, true, false, false}          
        };

        /// <summary>
        /// bool określający cza plansza jest już gotowa do gry
        /// </summary>
        public bool CzyPlanszaJestZaladowana { get { return _sprawdźPlanszę(); } private set { } }

        /// <summary>
        /// Przyciski planszy
        /// </summary>
        private BazaPola[] _przyciski;

        /// <summary>
        /// Stwórz nowa planszę
        /// </summary>
        public Plansza()
        {
            _przyciski = new BazaPola[9];
        }

        public void PrzygotujPlanszę()
        {
            for (int i = 0; i < _przyciski.Length; i++)
            {
                if (_przyciski[i].TypPola == TypPola.krzyżyk || _przyciski[i].TypPola == TypPola.kółko)
                {
                    _przyciski[i] = new Puste(_przyciski[i]);
                }
            }
        }

        /// <summary>
        /// Zarejestruj puste pole
        /// </summary>
        /// <param name="przycisk">przycisk który rejestrujemy</param>
        public void ZarejestrujPole(Button przycisk)
        {
            if (_sprawdźPrzycisk(przycisk))
            {
                _przyciski[Convert.ToInt16(przycisk.Tag)] = new Puste(przycisk);
            }
        }

        /// <summary>
        /// Zarejestruj pole o konkretnym typie
        /// </summary>
        /// <param name="przycisk">Przycisk który rejestrujemy</param>
        /// <param name="typ">typ pola które rejestrujemy</param>
        public void ZarejestrujPole(Button przycisk, TypPola typ)
        {
            if (_sprawdźPrzycisk(przycisk))
            {
                switch (typ)
                {
                    case TypPola.puste:
                        _przyciski[Convert.ToInt16(przycisk.Tag)] = new Puste(przycisk);
                        break;
                    case TypPola.kółko:
                        _przyciski[Convert.ToInt16(przycisk.Tag)] = new Kółko(przycisk);
                        break;
                    case TypPola.krzyżyk:
                        _przyciski[Convert.ToInt16(przycisk.Tag)] = new Krzyżyk(przycisk);
                        break;
                    default:
                        break;
                }
            }
        }

        /// <summary>
        /// Sprawdza czy podane pole jest puste
        /// </summary>
        /// <param name="nrPola"></param>
        /// <returns></returns>
        public bool CzyPolejestPuste(int nrPola)
        {
            if (_przyciski[nrPola].TypPola == TypPola.puste)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Metoda aktualizuje widok, sprawdza czy gra została zakończona true oznacza koniec gry
        /// </summary>
        /// <param name="pole">pole któe zostało wcisnięte</param>
        /// <param name="czyjaTura">true - kółko, false - krzyżyk</param>
        /// <returns></returns>
        public ObsługaGry.Status WykonanoRuch(int pole, bool czyjaTura)
        {
            // aktualizuje widok
            BazaPola zaktualizowanePole = czyjaTura ? 
                new Kółko(_przyciski[pole]) as BazaPola : 
                new Krzyżyk(_przyciski[pole]) as BazaPola;
            _przyciski[pole] = zaktualizowanePole;

            // sprawdzam czy jest wygrana
            if (_sprawdźCzyWygrana(czyjaTura))
            {
                if (czyjaTura)
                {
                    return ObsługaGry.Status.kółkowygrało;
                }
                else
                {
                    return ObsługaGry.Status.krzyżykwygrał;
                }
            } 

            // sprawdzam czy remis
            if (_scprwdźCzyRemis())
            {
                return ObsługaGry.Status.remis;
            }            

            // jeśli żadenz powyzszych scenariuszy się nie sprawdził to zwróć, że gra trwa
            return ObsługaGry.Status.trwa;
        }

        /// <summary>
        /// Sprawdza czy plansza jest gotowa do gry
        /// </summary>
        /// <returns></returns>
        private bool _sprawdźPlanszę()
        {
            foreach (var przycisk in this._przyciski)
            {
                if (przycisk == null)
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// Sprawdza czy przekazany przycisk jest zgodny ze standardem gry
        /// </summary>
        /// <param name="przycisk">przekazany przycisk</param>
        /// <returns>true - przycisk jest ok, false - coś jest nie tak</returns>
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

        /// <summary>
        /// Sprawdź czy gra zakończyła się remisem
        /// </summary>
        /// <returns>true - remis, false - gra trwa dalej</returns>
        private bool _scprwdźCzyRemis()
        {           
            foreach (var przycisk in _przyciski)
            {
                // jeśli znajdzie się choć jedno pole które jest puste to gra trwa dalej
                if (przycisk.TypPola==TypPola.puste)
                {
                    return false;
                }
            }
            // jeśli nie ma pustych pól to jest remis
            return true;
        }

        /// <summary>
        /// Metoda sprawdzająca czy gra została zakończona wygraną którejś ze stron
        /// </summary>
        /// <param name="czyjaTura"></param>
        /// <returns>true - wygrana strony której tura aktualnie trwa, false - gra trwa dalej</returns>
        private bool _sprawdźCzyWygrana(bool czyjaTura)
        {
            int pasująceElementyUłożenia;
            // przechodź po kolei po wygranych ułożeniach
            foreach (var ułożenie in ListaWygranychUłożeń)
            {
                // przechodząc do kolejnego ułozenia wyzeruj licznik
                pasująceElementyUłożenia = 0;
                // w każdym ułożeniu przechodź po jego elementach
                for (int i = 0; i < ułożenie.Length; i++)
                {
                    // jeśli rozpatrywane pole w ułożeniu ma wartosć true to przejśdz dalej aby sprawdzić pokrycie
                    if (ułożenie[i])
                    {
                        // jeśli jest tura kółka i na aktualnie rozpatrywanym polu też jest kółko to...
                        if (czyjaTura && _przyciski[i].TypPola==TypPola.kółko)
                        {
                            // ... zwiększ licznik pasujących elementów ułożenia
                            pasująceElementyUłożenia++;
                        } // jeśli jednak jest tura krzyżyka i na rozpatrywanym polu jest krzyżyk to...
                        else if (!czyjaTura && _przyciski[i].TypPola == TypPola.krzyżyk)
                        {
                            // ... zwiększ licznik pasujących elementów ułożenia
                            pasująceElementyUłożenia++;
                        }
                    }
                }
                // jeśli 3 elementy w ułożeniu pasowały zwróć true czyli wygraną
                if (pasująceElementyUłożenia==3)
                {
                    return true;
                }
            }
            // jeśli żadne ułożenie nie pasowało zwróć false
            return false;
        }

        public enum TypPola { puste, kółko, krzyżyk }
    }   
}
