using MediaLink.Lib;
using NSubstitute;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medialink.Lib.Tests
{
    public class MathWebClientTests
    {
        [Test]
        public void TestConnectedAdd()
        {
            var client = MathClientBootstrapper.GetDIMathClient();

            var result = client.Add(1, 2);

            Assert.AreEqual(result, 3);
        }

        [Test]
        public void TestConnectedMultiply()
        {
            var client = MathClientBootstrapper.GetDIMathClient();

            var result = client.Multiply(1, 2);

            Assert.AreEqual(result, 2);
        }

        [Test]
        public void TestConnectedDivide()
        {
            var client = MathClientBootstrapper.GetDIMathClient();

            var result = client.Divide(3, 2);

            Assert.AreEqual(result, 1);
        }

        [Test]
        public void TestSubstituteAdd()
        {
            var calculator = Substitute.For<IMathWebClient>();

            calculator.Add(1, 2).Returns(3);

            Assert.That(calculator.Add(1, 2), Is.EqualTo(3));
        }
    }
}
