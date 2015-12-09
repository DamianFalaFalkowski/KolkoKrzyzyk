using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;

namespace KolkoKrzyrzyk_Proj.Pola
{
    /// <summary>
    /// Abstrakcyjna klasa będąca podstawą każdego pola
    /// </summary>
    public abstract class BazaPola : IDisposable
    {
        // określa typ pola ustawionie wartości jest chronione(protected) to znaczy że tylko w klasie BazaPola i w klasach dziedziczących po BazaPola może być edytowana
        public Plansza.TypPola TypPola { get; protected set; }

        // numer pola - pobierany z tagu przycisku
        public int NumerPola
        {
            get { return _przycisk != null ? Convert.ToInt32(_przycisk.Tag) : -1; }
            private set { }
        }

        // obrazek podobnie jak typ pola jest chroniony(protected)
        public ImageSource ObrazekSource
        {
            get { return _przycisk != null ? (_przycisk.Content as Image).Source : null; }
            protected set { if (_przycisk != null) (_przycisk.Content as Image).Source = value; }
        }

        // referencja do przycisku
        private Button _przycisk;
       
        // konstruktor 1 - tworzy całkowicie nowy obiekt
        public BazaPola(Button przycisk)
        {
            _przycisk = przycisk;
        }

        // konstruktor 2 - tworzy obiekt za starego obiektu typu BazaPola
        public BazaPola(BazaPola starePole)
        {
            _przycisk = starePole._przycisk;
        }

        #region Implementacja IDisposable
            public virtual void Dispose()
            {
                Dispose(true);
                GC.SuppressFinalize(this);
            }

            ~BazaPola()
            {
                Dispose(false);
            }

            protected virtual void Dispose(bool disposing)
            {
                if (disposing)
                {
                    //plansza = null; //Usuwamy z obiektu wszytkie referencje
                    //obrazek = null;
                }

                //if (przycisk != null)
                //{
                //    if (form.Controls.Contains(przycisk))
                //        form.Controls.Remove(przycisk);
                //    przycisk.Dispose();
                //    przycisk = null;
                //}
            }
            #endregion
    }
}
