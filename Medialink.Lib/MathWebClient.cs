using RestSharp;
using System;

namespace MediaLink.Lib
{
    public class MathWebClient
    {
        private IRestClient _restClient;

        public MathWebClient()
        {
            _restClient = new RestClient("http://api.mathweb.com/");
        }

        public int Add(int a, int b)
        {
            string sum = _restClient.Get(new RestRequest($"add?a={a}&b={b}", Method.GET)).Content;

            //log the request

            return Convert.ToInt32(sum);
        }

        public int Multiply(int a, int b)
        {
            string product = _restClient.Get(new RestRequest($"multiply?a={a}&b={b}", Method.GET)).Content;

            //log the request

            return Convert.ToInt32(product);
        }

        public int Divide(int a, int b)
        {
            string quotient = _restClient.Get(new RestRequest($"divide?a={a}&b={b}", Method.GET)).Content;

            //log the request

            return Convert.ToInt32(quotient);
        }
    }
}
