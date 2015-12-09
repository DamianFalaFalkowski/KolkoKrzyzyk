using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KolkoKrzyrzyk_Proj
{
    // statyczna klasa do starowania grą
    public static class ObsługaGry
    {
        private static Gra _gra { get; set; }

        public static void NowaGra(Gra gra)
        {
            _gra = gra;
        }
    }
}
