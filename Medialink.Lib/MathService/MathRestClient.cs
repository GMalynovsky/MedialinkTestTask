using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaLink.Lib.MathService
{
    public class MathRestClient : IMathRestClient
    {
        readonly IRestClient _restClient;

        public MathRestClient(IRestClient restClient)
        {
            _restClient = restClient;
        }

        public string Add(int a, int b)
        {
            string sum = _restClient.Get(new RestRequest($"add?a={a}&b={b}", Method.GET)).Content;

            return sum;
        }

        public string Multiply(int a, int b)
        {
            string product = _restClient.Get(new RestRequest($"multiply?a={a}&b={b}", Method.GET)).Content;

            return product;
        }

        public string Divide(int a, int b)
        {
            string quotient = _restClient.Get(new RestRequest($"divide?a={a}&b={b}", Method.GET)).Content;

            return quotient;
        }
    }
}
