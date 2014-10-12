using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TDDLab.Core.InvoiceMgmt;

namespace TDDLab.Tests
{
    // public Address(string addresLine1, string city, string state, string zip)
    [TestFixture]
    public class AddressTests
    {
        [TestFixtureSetUp]
        public void Initialize() { }

        [Test]
        public void AddressLine1_Test()
        {
            Address address = new Address("", "Seattle", "California", "98101");
            Assert.That(
                address.Validate(),
                Is.EqualTo(new[] { Address.ValidationRules.AddressLine1 }));
        }

        [Test]
        public void City_Test() {
            Address address = new Address("Test", "", "California", "98101");
            Assert.That(
                address.Validate(),
                Is.EqualTo(new[] { Address.ValidationRules.City }));
        }

        [Test]
        public void State_Test()
        {
            Address address = new Address("Test", "Seattle", "", "98101");
            Assert.That(
                address.Validate(),
                Is.EqualTo(new[] { Address.ValidationRules.State }));
        }

        [Test]
        public void Zip_Test()
        {
            Address address = new Address("Test", "Seattle", "California", "");
            Assert.That(
                address.Validate(),
                Is.EqualTo(new[] { Address.ValidationRules.Zip }));
        }
    }
}
