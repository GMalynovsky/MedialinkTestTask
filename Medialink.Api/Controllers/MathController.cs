using Medialink.Common;
using System.Net.Http;
using System.Web.Http;

namespace Medialink.Api.Controllers
{
    public class MathController : ApiController
    {
        public ICalculatorService Service;

        public MathController()
        {
            Service = new CalculatorService();
        }

        [HttpGet]
        public HttpResponseMessage Add(int a, int b)
        {
            return Service.Calculate(a, b, OperationType.Add);
        }

        [HttpGet]
        public HttpResponseMessage Multiply(int a, int b)
        {
            return Service.Calculate(a, b, OperationType.Multiply);
        }

        [HttpGet]
        public HttpResponseMessage Divide(int a, int b)
        {
            return Service.Calculate(a, b, OperationType.Divide);
        }
    }
}
