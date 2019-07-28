using MediaLink.Lib.LogService;
using MediaLink.Lib.MathService;
using RestSharp;
using System;
using System.Net;

namespace MediaLink.Lib
{
    internal class MathWebClient : IMathWebClient
    {
        private readonly IMathRestClient _mathRestClient;
        private readonly ILogger _logService;

        internal MathWebClient(IMathRestClient restClient, ILogger logger)
        {
            _mathRestClient = restClient;
            _logService = logger;
        }

        public int Add(int a, int b)
        {
            string sum = _mathRestClient.Add(a, b);

            _logService.Log("", LogEntryType.Event);

            return Convert.ToInt32(sum);
        }

        public int Multiply(int a, int b)
        {
            string product = _mathRestClient.Multiply(a, b);

            _logService.Log("", LogEntryType.Event);

            return Convert.ToInt32(product);
        }

        public int Divide(int a, int b)
        {
            string quotient = _mathRestClient.Divide(a, b);

            _logService.Log("", LogEntryType.Event);

            return Convert.ToInt32(quotient);
        }
    }
}
