using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TDDLab.Core.InvoiceMgmt;

namespace TDDLab.Tests
{
    [TestFixture]
    class DomainExtensionsTests
    {
        [Test]
        public void ToCurrency_SameAsConverterConvert()
        {
            Money money = new Money(64, "GBP");
            Assert.That(money.ToCurrency("EUR").Amount, Is.EqualTo(CurrencyConverter.Convert("GBP", "EUR", money.Amount)));
        }

        [Test]
        public void ToCurrency_ReturnsValidMoney()
        {
            Money money = new Money(64, "GBP");
            Assert.That(
                money.ToCurrency("EUR"),
                Is.EqualTo(new Money(64, "EUR")));
        }
    }
}
