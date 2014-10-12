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
    public class RecipientTests
    {
        [Test]
        public void AddressInvalid_Test()
        {
            Address a = new Address("", "Seattle", "California", "80126");
            Recipient recipient = new Recipient("Jane", a);

            Assert.That(
                recipient.Validate(),
                Is.EqualTo(new[] { Recipient.ValidationRules.Address }));
        }

        //[Test]
        //public void AddressNull_Test()
        //{
        //    Recipient recipient = new Recipient("Jane", null);
        //    Assert.That(
        //        recipient.Validate(),
        //        Is.EqualTo(new[] { Recipient.ValidationRules.Address }));
        //}

        [Test]
        public void NameEmpty_Test()
        {
            Address a = new Address("Street", "Seattle", "California", "80126");
            Recipient recipient = new Recipient("", a);
            Assert.That(
                recipient.Validate(),
                Is.EqualTo(new[] { Recipient.ValidationRules.Name }));
        }
    }
}
