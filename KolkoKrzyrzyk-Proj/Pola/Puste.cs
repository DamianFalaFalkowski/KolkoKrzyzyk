﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace KolkoKrzyrzyk_Proj.Pola
{
    public class Puste : BazaPola, IDisposable
    {
        public Puste(Button przycisk)
            : base(przycisk)
        {
            base.ObrazekSource = null;
        }

        public override void Dispose()
        {
            base.Dispose();
        }
    }
}