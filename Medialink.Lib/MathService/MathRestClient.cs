using RestSharp;

namespace MediaLink.Lib.MathService
{
    public class MathRestClient : IMathRestClient
    {
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

        readonly IRestClient _restClient;
    }
}
