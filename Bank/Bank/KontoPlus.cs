using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
    public class KontoPlus : Konto
    {
        private decimal jednorazowyLimitDebetowy;

        public KontoPlus(string klient, decimal bilansNaStart = 0, decimal limitDebetowy = 0) : base(klient, bilansNaStart)
        {
            this.jednorazowyLimitDebetowy = limitDebetowy;
        }

        public override decimal Bilans
        {
            get { return base.Bilans + jednorazowyLimitDebetowy; }
        }

        public void ZmienLimitDebetowy(decimal nowyLimit)
        {
            jednorazowyLimitDebetowy = nowyLimit;
        }

        public override void Wplata(decimal kwota)
        {
            base.Wplata(kwota);
            if (base.Bilans > 0 && Zablokowane)
            {
                OdblokujKonto();
            }
        }

        public override void Wyplata(decimal kwota)
        {
            if (kwota > base.Bilans + jednorazowyLimitDebetowy)
            {
                throw new ArgumentException("Nie można wypłacić więcej niż jest na koncie plus limit debetowy");
            }

            base.Wyplata(kwota);

            if (base.Bilans < 0)
            {
                BlokujKonto();
            }
        }
    }
}