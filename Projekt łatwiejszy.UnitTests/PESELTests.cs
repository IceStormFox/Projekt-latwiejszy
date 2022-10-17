using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Projekt_łatwiejszy.UnitTests
{
    class PESELTests
    {
        [Test]
        public void LiczbaKontorlnaPowinnaWynosic4()
        {
            //arrange
            var Pesel = new PESEL();
            //act
            Pesel.obliczonka();
            //assert
            Assert.AreEqual(4, PESEL.liczbak);
        }
    }
}
