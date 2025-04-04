using Bank;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestProject1
{
    [TestClass]
    public sealed class Testy_Konto
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

    [TestClass]
    public sealed class Testy_Konto_plus
    {
        [TestMethod]
        public void Wplata_Na_Konto_Plus()
        {
            var KontoPlus = new KontoPlus("Anna Kowalska", 100, 200);
            KontoPlus.Wplata(150);
            Assert.AreEqual(450, KontoPlus.Bilans);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Wyplata_Powyzej_Limitu_Debetowego()
        {
            var KontoPlus = new KontoPlus("Piotr Nowak", 100, 200);
            KontoPlus.Wyplata(350);
        }

        [TestMethod]
        public void Blokowanie_Konta_Plus()
        {
            var KontoPlus = new KontoPlus("Ewa Kowalska", 100, 200);
            KontoPlus.Wyplata(300);
            Assert.IsTrue(KontoPlus.Zablokowane);
        }

        [TestMethod]
        public void Odblokowanie_Konta_Plus()
        {
            var KontoPlus = new KontoPlus("Adam Nowak", 100, 200);
            KontoPlus.Wyplata(300);
            Assert.IsTrue(KontoPlus.Zablokowane);
            KontoPlus.Wplata(400);
            Assert.IsFalse(KontoPlus.Zablokowane);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Wplata_Na_Zablokowane_Konto_Plus()
        {
            var KontoPlus = new KontoPlus("Katarzyna Nowak", 100, 200);
            KontoPlus.Wyplata(300);
            KontoPlus.Wplata(-50);
        }
    }

    [TestClass]
    public sealed class Testy_Konto_Limit
    {
        [TestMethod]
        public void Wplata_Na_Konto_Limit()
        {
            var KontoLimit = new KontoLimit("Anna Kowalska", 100, 200);
            KontoLimit.Wplata(150);
            Assert.AreEqual(450, KontoLimit.Bilans);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Wyplata_Powyzej_Limitu_Debetowego()
        {
            var KontoLimit = new KontoLimit("Piotr Nowak", 100, 200);
            KontoLimit.Wyplata(350);
        }

        [TestMethod]
        public void Blokowanie_Konta_Limit()
        {
            var KontoLimit = new KontoLimit("Ewa Kowalska", 100, 200);
            KontoLimit.Wyplata(300);
            Assert.IsTrue(KontoLimit.Zablokowane);
        }

        [TestMethod]
        public void Odblokowanie_Konta_Limit()
        {
            var KontoLimit = new KontoLimit("Adam Nowak", 100, 200);
            KontoLimit.Wyplata(300);
            Assert.IsTrue(KontoLimit.Zablokowane);
            KontoLimit.Wplata(400);
            Assert.IsFalse(KontoLimit.Zablokowane);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Wplata_Na_Zablokowane_Konto_Limit()
        {
            var KontoLimit = new KontoLimit("Katarzyna Nowak", 100, 200);
            KontoLimit.Wyplata(300);
            KontoLimit.Wplata(-50);
        }
    }
}