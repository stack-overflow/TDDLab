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
    class MoneyTests
    {
        [Test]
        public void Currency_Test()
        {
            Money money = new Money(100, "");
            Assert.That(
                money.Validate(),
                Is.EqualTo(new[] { Money.ValidationRules.Currency }));
        }

        [Test]
        public void OperatorPlusDefault_Test()
        {
            Money left = new Money(2);
            Money right = new Money(4);
            Money result = left + right;
            Assert.That(result.Amount, Is.EqualTo(6));
        }

        [Test]
        public void OperatorPlusCurrencyChange_Test()
        {
            Money left = new Money(2, "EUR");
            Money right = new Money(4, "USD");
            Money result = left + right;
            Assert.That(result.Currency, Is.EqualTo("EUR"));
        }

        [Test]
        public void ToString_Test()
        {
            Money money = new Money(512, "GBP");
            Assert.That(money.ToString(), Is.EqualTo("512GBP"));
        }


        [Test]
        public void EqualsMoneySelf_Test()
        {
            Money money = new Money(256, "EUR");
            Assert.That(money.Equals(money), Is.EqualTo(true));
        }

        [Test]
        public void EqualsMoneyNull_Test()
        {
            Money money = new Money(256, "EUR");
            Assert.That(money.Equals(null), Is.EqualTo(false));
        }

        [Test]
        public void EqualsMoneyPositive_Test()
        {
            Money left = new Money(256, "EUR");
            Money right = new Money(256, "EUR");
            Assert.That(left.Equals(right), Is.EqualTo(true));
        }
        [Test]
        public void EqualsMoneyNegative_Test()
        {
            Money left = new Money(256, "EUR");
            Money right = new Money(512, "EUR");
            Assert.That(left.Equals(right), Is.EqualTo(false));
        }
        [Test]
        public void EqualsObjectPositive_Test()
        {
            Money left = new Money(256, "EUR");
            object right = new Money(256, "EUR");
            Assert.That(left.Equals(right), Is.EqualTo(true));
        }
        [Test]
        public void EqualsObjectNonMoney_Test()
        {
            Money left = new Money(256, "EUR");
            String right = "Lolzord";
            Assert.That(left.Equals(right), Is.EqualTo(false));
        }

        [Test]
        public void EqOperatorSameAsEquals_Test()
        {
            Money left = new Money(256, "EUR");
            Money right = new Money(256, "EUR");
            Assert.That(left == right, Is.EqualTo(left.Equals(right)));
        }

        [Test]
        public void EqOperatorPositive_Test()
        {
            Money left = new Money(256, "EUR");
            Money right = new Money(256, "EUR");
            Assert.That(left == right, Is.EqualTo(true));
        }

        [Test]
        public void NeOperatorPositive_Test()
        {
            Money left = new Money(256, "EUR");
            Money right = new Money(512, "EUR");
            Assert.That(left != right, Is.EqualTo(true));
        }
    }
}
