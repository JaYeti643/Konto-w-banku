namespace Bank
{
    public class KontoLimit
    {
        private Konto konto;
        private decimal jednorazowyLimitDebetowy;

        public KontoLimit(string klient, decimal bilansNaStart = 0, decimal limitDebetowy = 0)
        {
            konto = new Konto(klient, bilansNaStart);
            this.jednorazowyLimitDebetowy = limitDebetowy;
        }

        public string Nazwa
        {
            get { return konto.Nazwa; }
        }

        public decimal Bilans
        {
            get { return konto.Bilans + jednorazowyLimitDebetowy; }
        }

        public bool Zablokowane
        {
            get { return konto.Zablokowane; }
        }

        public void Wplata(decimal kwota)
        {
            konto.Wplata(kwota);
            if (konto.Bilans > 0 && konto.Zablokowane)
            {
                konto.OdblokujKonto();
            }
        }

        public void Wyplata(decimal kwota)
        {
            if (kwota > konto.Bilans + jednorazowyLimitDebetowy)
            {
                throw new ArgumentException("Nie można wypłacić więcej niż jest na koncie plus limit debetowy");
            }

          
            decimal tymczasowyBilans = konto.Bilans;
            konto.Wplata(jednorazowyLimitDebetowy);

            try
            {
                konto.Wyplata(kwota);
            }
            finally
            {
              
                konto.Wyplata(jednorazowyLimitDebetowy);
            }

            if (konto.Bilans < 0)
            {
                konto.BlokujKonto();
            }
        }

        public void ZmienLimitDebetowy(decimal nowyLimit)
        {
            jednorazowyLimitDebetowy = nowyLimit;
        }
    }
}