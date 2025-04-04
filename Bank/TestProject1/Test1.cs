using Bank;


namespace TestProject1
{
    [TestClass]
    public sealed class Test1
    {
        [TestMethod]
        public void Utworzenie_Konta()
        {
            string klient = "Marcin Nowak";
            decimal poczatkowyBilans = 100;

            Konto konto = new Konto(klient, poczatkowyBilans);

            Assert.AreEqual(klient, konto.Nazwa);
            Assert.AreEqual(poczatkowyBilans, konto.Bilans);
            Assert.IsFalse(konto.Zablokowane);

        }

        [TestMethod]
        public void Wplata_Na_Konto()
        {
            string klient = "Dawid Pokluda";
            decimal poczatkowyBilans = 0;

            Konto konto = new Konto(klient, poczatkowyBilans);

            konto.Wplata(100);

            Assert.AreEqual(100, konto.Bilans);
            

        }
        [TestMethod]
        public void Wyplata_Z_Konto() 
        {
            var konto = new Konto("Jan Nowak", 200);
            konto.Wyplata(100);
            Assert.AreEqual(100, konto.Bilans);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Wpłata_Na_Konto_Liczba_Ujemna()
        {
            var konto = new Konto("Dawid Drozd", 100);

            konto.Wplata(-100);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Wpłata_Na_Konto_0()
        {
            var konto = new Konto("Dawid Drozd", 100);

            konto.Wplata(0);
          
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Blokowanie_Konta()
        {
            var konto = new Konto("Dawid Drozd", 100);
            konto.BlokujKonto();
            konto.Wyplata(50);
        }
        [TestMethod]
        public void Oblokowanie_Konta()
        {
            var konto = new Konto("Dawid Drozd", 100);
            konto.BlokujKonto();
            konto.OdblokujKonto();
            konto.Wplata(100);
            Assert.AreEqual(200, konto.Bilans);
        }
    }
}
