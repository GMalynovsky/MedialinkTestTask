using Medialink.Api.Controllers;
using NSubstitute;
using NSubstitute.Extensions;
using NUnit.Framework;
using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;

namespace Medialink.Api.Tests
{
    public class MathControllerTests
    {
        [Test]
        [Category("Service Substituted")]
        public void TestSubstituteAdd()
        {
            var calculator = GetMathAPISubstitute();

            LoopCheck(0, 2, (a, b) => Assert.That(GetContentFromResponse(calculator.Add(a, b).Content), Is.EqualTo((a + b))));
        }

        [Test]
        [Category("Service Substituted")]
        public void TestSubstituteMultiply()
        {
            var calculator = GetMathAPISubstitute();

            LoopCheck(0, 2, (a, b) => Assert.That(GetContentFromResponse(calculator.Multiply(a, b).Content), Is.EqualTo(a * b)));
        }

        [Test]
        [Category("Service Substituted")]
        public void TestSubstituteDivide()
        {
            var calculator = GetMathAPISubstitute();

            LoopCheck(1, 3, (a, b) => Assert.That(GetContentFromResponse(calculator.Divide(a, b).Content), Is.EqualTo(a / b)));
        }

        [Test]
        [Category("Service Substituted")]
        public void TestSubstituteDivideByZero()
        {
            var calculator = GetMathAPISubstitute();

            Assert.That(calculator.Divide(1, 0).StatusCode, Is.EqualTo(HttpStatusCode.InternalServerError));
        }

        private MathController GetMathAPISubstitute()
        {
            var calc = Substitute.For<ICalculatorService>();

            calc
                .Configure()
                .Calculate(Arg.Any<int>(), Arg.Any<int>(), Common.OperationType.Add)
                .Returns(x => new HttpResponseMessage(System.Net.HttpStatusCode.OK) { Content = new StringContent(((int)x[0] + (int)x[1]).ToString()) });
            calc
                .Configure()
                .Calculate(Arg.Any<int>(), Arg.Any<int>(), Common.OperationType.Multiply)
                .Returns(x => new HttpResponseMessage(System.Net.HttpStatusCode.OK) { Content = new StringContent(((int)x[0] * (int)x[1]).ToString()) });
            calc
                .Configure()
                .Calculate(Arg.Any<int>(), Arg.Is<int>(x => x != 0), Common.OperationType.Divide)
                .Returns(x => new HttpResponseMessage(System.Net.HttpStatusCode.OK) { Content = new StringContent(((int)x[0] / (int)x[1]).ToString()) });
            calc
                .Configure()
                .Calculate(Arg.Any<int>(), Arg.Is<int>(x => x == 0), Common.OperationType.Divide)
                .Returns(x => new HttpResponseMessage(System.Net.HttpStatusCode.InternalServerError) { Content = new StringContent("Division by zero!") });

            var controller =  Substitute.For<MathController>();
            controller.Service = calc;

            return controller;
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

        private int GetContentFromResponse(HttpContent content)
        {
            return Convert.ToInt32(content.ReadAsStringAsync().Result);
        }
    }
}
