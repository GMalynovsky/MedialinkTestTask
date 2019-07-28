using MediaLink.Lib;
using MediaLink.Lib.LogService;
using MediaLink.Lib.MathService;
using NSubstitute;
using NSubstitute.Extensions;
using NUnit.Framework;
using RestSharp;
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
            var mrk = Substitute.For<IMathRestClient>();
            mrk
                .Configure()
                .Add(Arg.Any<int>(), Arg.Any<int>())
                .Returns(x => ((int)x[0] + (int)x[1]).ToString());

            var logger = Substitute.For<ILogger>();
            var counter = 0;
            logger
                .Configure()
                .Log(Arg.Any<string>(), LogEntryType.Event, Arg.Any<int>(), Arg.Any<int>(), Arg.Any<int>())
                .ReturnsForAnyArgs(x => counter)
                .AndDoes(x => counter++);

            var calculator = Substitute.For<MathWebClient>(mrk, logger);

            Assert.That(calculator.Add(1, 2), Is.EqualTo(3));
        }
    }
}
