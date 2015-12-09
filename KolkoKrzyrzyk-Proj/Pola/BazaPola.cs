using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;

namespace KolkoKrzyrzyk_Proj.Pola
{

    public abstract class BazaPola : IDisposable
    {        
        public int NumerPola
        {
            get { return _przycisk != null ? Convert.ToInt32(_przycisk.Tag) : -1; }
            private set { }
        }

        public ImageSource ObrazekSource
        {
            get { return _przycisk != null ? (_przycisk.Content as Image).Source : null; }
            set { if(_przycisk != null) (_przycisk.Content as Image).Source = value; }
        }

        private Button _przycisk;

        public BazaPola(Button przycisk)
        {           
            _przycisk = przycisk;
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
