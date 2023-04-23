using System;
using System.Collections.Generic;
using System.Text;

namespace Project3
{
    class Durak
    {
        public string DurakAdi { get; set; }
        public int BosPark { get; set; }
        public int TandemBisiklet { get; set; }
        public int NormalBisiklet { get; set; }

        public Durak(string durakAdi, int bosPark, int tandemBisiklet, int normalBisiklet)
        {
            DurakAdi = durakAdi;
            BosPark = bosPark;
            TandemBisiklet = tandemBisiklet;
            NormalBisiklet = normalBisiklet;
        }

        public override string ToString()
        {
            return DurakAdi;
        }

        public void Status()
        {
            Console.WriteLine("{0} Boş park sayısı --> {1} Normal bisiklet sayısı --> {2} Tandem bisiklet sayısı --> {3}", DurakAdi, BosPark, NormalBisiklet, TandemBisiklet);
        }
    }
}
