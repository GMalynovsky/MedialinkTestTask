using MediaLink.Lib.LogService;
using RestSharp;
using System;

namespace MediaLink.Lib
{
    public class MathWebClient
    {
        private readonly IRestClient _restClient;
        private readonly ILogger _logService;

        public MathWebClient(IMedialinkRestClient restClient, ILogger logger)
        {
            _restClient = restClient;
            _logService = logger;
        }

        public int Add(int a, int b)
        {
            string sum = _restClient.Get(new RestRequest($"add?a={a}&b={b}", Method.GET)).Content;

            _logService.Log("", LogEntryType.Event);

            return Convert.ToInt32(sum);
        }

        public int Multiply(int a, int b)
        {
            string product = _restClient.Get(new RestRequest($"multiply?a={a}&b={b}", Method.GET)).Content;

            _logService.Log("", LogEntryType.Event);

            return Convert.ToInt32(product);
        }

        public int Divide(int a, int b)
        {
            string quotient = _restClient.Get(new RestRequest($"divide?a={a}&b={b}", Method.GET)).Content;

            _logService.Log("", LogEntryType.Event);

            return Convert.ToInt32(quotient);
        }
    }
}
