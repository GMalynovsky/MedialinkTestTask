using Medialink.Common;
using System;
using System.Net;
using System.Net.Http;

namespace Medialink.Api
{
    public class CalculatorService : ICalculatorService
    {
        public HttpResponseMessage Calculate(int a, int b, OperationType operation)
        {
            var message = string.Empty;

            try
            {
                switch (operation)
                {
                    case OperationType.Add:
                        message = Add(a, b);
                        break;
                    case OperationType.Multiply:
                        message = Multiply(a, b);
                        break;
                    case OperationType.Divide:
                        message = Divide(a, b);
                        break;
                }
            }
            catch (Exception ex)
            {
                return new HttpResponseMessage(HttpStatusCode.InternalServerError)
                {
                    Content = new StringContent(ex.Message)
                };
            }

            return new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(message)
            };
        }

        private string Add(int a, int b)
        {
            return Convert.ToString(Calculator.Add(a, b));
        }

        private string Multiply(int a, int b)
        {
            return Convert.ToString(Calculator.Multiply(a, b));
        }

        private string Divide(int a, int b)
        {
            if (b == 0)
            {
                throw new Exception("You cannot divide by 0!!!");
            }

            return Convert.ToString(Calculator.Divide(a, b));
        }
    }
}