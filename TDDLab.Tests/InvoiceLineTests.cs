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
    public class InvoiceLineTests
    {
        [Test]
        public void ProductName_Test()
        {
            InvoiceLine il = new InvoiceLine("", Money.ZERO);
            Assert.That(
                il.Validate(),
                Is.EqualTo(new [] { InvoiceLine.ValidationRules.ProductName }));
        }

        [Test]
        public void Monet_Test()
        {
            InvoiceLine il = new InvoiceLine("Kot Rudy", new Money(100, ""));
            Assert.That(
                il.Validate(),
                Is.EqualTo(new[] { InvoiceLine.ValidationRules.Money }));
        }

        [Test]
        public void ToString_Test()
        {
            InvoiceLine il = new InvoiceLine("Kot Rudy", new Money(100, "USD"));
            Assert.That(il.ToString(), Is.EqualTo("Kot Rudy for 100USD"));
        }
    }
}
