using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
    internal class KontoPlus : Konto
    {
        public KontoPlus(string klient, decimal bilansNaStart = 0) : base(klient, bilansNaStart)
        {
        }
    }
}
