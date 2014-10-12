using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TDDLab.Core.InvoiceMgmt;
using TDDLab.Core.x;

namespace TDDLab.Tests
{
    [TestFixture]
    class InvoiceTests
    {
        string validInvoiceNumber;
        Address validAddress;
        Recipient validRecipient;
        Money validMoney;
        IEnumerable<InvoiceLine> validLines;

        [TestFixtureSetUp]
        public void Initialize()
        {
            validAddress = new Address("Street", "Seattle", "California", "80126");
            validRecipient = new Recipient("Jane", validAddress);
            validMoney = new Money(100);
            validInvoiceNumber = "12481632";
            validLines = new[] {
                    new InvoiceLine("Rudy Kot", new Money(128)),
                    new InvoiceLine("Hyperion", new Money(256))
            };
        }

        [Test]
        public void IsValidNoDiscount_Test()
        {
            Invoice invoice = new Invoice(
                validInvoiceNumber,
                validRecipient,
                validAddress,
                validLines
            );
            Assert.That(invoice.IsValid, Is.EqualTo(true));
        }

        [Test]
        public void IsValidDiscountNull_Test()
        {
            Invoice invoice = new Invoice(
                validInvoiceNumber,
                validRecipient,
                validAddress,
                validLines,
                null
            );
            Assert.That(invoice.IsValid, Is.EqualTo(true));
        }

        [Test]
        public void DiscountValidAndSet_Test()
        {
            var discount = new Money(10);
            Invoice invoice = new Invoice(
                validInvoiceNumber,
                validRecipient,
                validAddress,
                validLines,
                discount
            );
            Assert.That(invoice.Discount, Is.EqualTo(discount));
        }

        [Test]
        public void InvoiceNumberEmpty_Test()
        {
            Invoice invoice = new Invoice(
                "",
                validRecipient,
                validAddress,
                validLines
            );
            Assert.That(invoice.Validate(), Is.EqualTo(new [] { Invoice.ValidationRules.InvoiceNumber }));
        }

        [Test]
        public void InvoiceLinesEmpty_Test()
        {
            Invoice invoice = new Invoice(
                validInvoiceNumber,
                validRecipient,
                validAddress,
                new InvoiceLine[] { }
            );
            Assert.That(invoice.Validate(), Is.EqualTo(new[] { Invoice.ValidationRules.Lines }));
        }

        [Test]
        public void RecipientNull_Test()
        {
            var discount = new Money(10);
            Invoice invoice = new Invoice(
                validInvoiceNumber,
                null,
                validAddress,
                validLines,
                discount
            );
            Assert.That(invoice.Validate(), Is.EqualTo(new [] { Invoice.ValidationRules.Recipient }));
        }

        [Test]
        public void RecipientNotValid_Test()
        {
            var discount = new Money(10);
            Invoice invoice = new Invoice(
                validInvoiceNumber,
                new Recipient("", validAddress),
                validAddress,
                validLines,
                discount
            );
            Assert.That(invoice.Validate(), Is.EqualTo(new[] { Invoice.ValidationRules.Recipient }));
        }

        [Test]
        public void AddressNull_Test()
        {
            var discount = new Money(10);
            Invoice invoice = new Invoice(
                validInvoiceNumber,
                validRecipient,
                null,
                validLines,
                discount
            );
            Assert.That(invoice.Validate(), Is.EqualTo(new[] { Invoice.ValidationRules.BillingAddress }));
        }

        [Test]
        public void AddressNotValid_Test()
        {
            var discount = new Money(10);
            Invoice invoice = new Invoice(
                validInvoiceNumber,
                validRecipient,
                new Address("", "Seattle", "California", "80126"),
                validLines,
                discount
            );
            Assert.That(invoice.Validate(), Is.EqualTo(new[] { Invoice.ValidationRules.BillingAddress }));
        }

        [Test]
        public void InvoiceLinesInvalid_Test()
        {
            Invoice invoice = new Invoice(
                validInvoiceNumber,
                validRecipient,
                validAddress,
                new InvoiceLine[] {
                    new InvoiceLine("Rudy Kot", new Money(128)),
                    new InvoiceLine("", new Money(256)),
                }
            );
            Assert.That(invoice.Validate(), Is.EqualTo(new[] { Invoice.ValidationRules.Lines }));
        }

        [Test]
        public void LinesGetter_Test()
        {
            Invoice invoice = new Invoice(
                validInvoiceNumber,
                validRecipient,
                validAddress,
                validLines,
                new Money(10)
            );

            Assert.That(invoice.Lines, Is.EqualTo(validLines));
        }


    }
}
