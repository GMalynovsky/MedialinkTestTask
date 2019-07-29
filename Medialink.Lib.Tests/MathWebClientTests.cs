using MediaLink.Lib;
using MediaLink.Lib.LogService;
using MediaLink.Lib.MathService;
using NSubstitute;
using NSubstitute.Extensions;
using NUnit.Framework;
using System;

namespace Medialink.Lib.Tests
{
    public class MathWebClientTests
    {
        [Test]
        [Category("Service Connected")]
        public void TestConnectedAdd()
        {
            var client = MathClientBootstrapper.GetDIMathClient();

            var result = client.Add(1, 2);

            Assert.AreEqual(result, 3);
        }

        [Test]
        [Category("Service Connected")]
        public void TestConnectedMultiply()
        {
            var client = MathClientBootstrapper.GetDIMathClient();

            var result = client.Multiply(1, 2);

            Assert.AreEqual(result, 2);
        }

        [Test]
        [Category("Service Connected")]
        public void TestConnectedDivide()
        {
            var client = MathClientBootstrapper.GetDIMathClient();

            var result = client.Divide(3, 2);

            Assert.AreEqual(result, 1);
        }

        [Test]
        [Category("Service Substituted")]
        public void TestSubstituteAdd()
        {
            var calculator = GetMathWebClientSubstitute();

            LoopCheck(0, 2, (a, b) => Assert.That(calculator.Add(a, b), Is.EqualTo(a + b)));
        }

        [Test]
        [Category("Service Substituted")]
        public void TestSubstituteMultiply()
        {
            var calculator = GetMathWebClientSubstitute();

            LoopCheck(0, 2, (a, b) => Assert.That(calculator.Multiply(a, b), Is.EqualTo(a * b)));
        }

        [Test]
        [Category("Service Substituted")]
        public void TestSubstituteDivide()
        {
            var calculator = GetMathWebClientSubstitute();

            LoopCheck(1, 3, (a, b) => Assert.That(calculator.Divide(a, b), Is.EqualTo(a / b)));
        }

        [Test]
        [Category("Service Substituted")]
        public void TestSubstituteAddAndLog()
        {
            var logger = GetLoggerSubstitute();

            var calculator = Substitute.For<MathWebClient>(GetMathRestClientSubstitute(), logger);

            calculator.Add(1, 3);

            logger
                .Received().Log(Arg.Any<string>(), LogEntryType.Event, 1, 3, 4);
        }

        private void LoopCheck(int low, int high, Action<int, int> action)
        {
            if (low > high) throw new Exception("low arg should be lesser or equal then high arg!");

            for (int arg1 = low; arg1 <= high; arg1++)
            {
                for (int arg2 = low; arg2 <= high; arg2++)
                {
                    action.Invoke(arg1, arg2);
                }
            }
        }

        private MathWebClient GetMathWebClientSubstitute()
        {
            return Substitute.For<MathWebClient>(GetMathRestClientSubstitute(), GetLoggerSubstitute());
        }

        private IMathRestClient GetMathRestClientSubstitute()
        {
            var mrk = Substitute.For<IMathRestClient>();

            mrk
                .Configure()
                .Add(Arg.Any<int>(), Arg.Any<int>())
                .Returns(x => ((int)x[0] + (int)x[1]).ToString());
            mrk
                .Configure()
                .Multiply(Arg.Any<int>(), Arg.Any<int>())
                .Returns(x => ((int)x[0] * (int)x[1]).ToString());
            mrk
                .Configure()
                .Divide(Arg.Any<int>(), Arg.Any<int>())
                .Returns(x => ((int)x[0] / (int)x[1]).ToString());

            return mrk;
        }

        private ILogger GetLoggerSubstitute()
        {
            var logger = Substitute.For<ILogger>();

            var counter = 0;
            logger
                .Configure()
                .Log(Arg.Any<string>(), LogEntryType.Event, Arg.Any<int>(), Arg.Any<int>(), Arg.Any<int>())
                .ReturnsForAnyArgs(x => counter)
                .AndDoes(x => counter++);

            return logger;
        }
    }
}
