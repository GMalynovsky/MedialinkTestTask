using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Medialink.Api.Controllers
{
    public class MathController : ApiController
    {
        public MathController()
        {
        }

        [HttpGet]
        public HttpResponseMessage Add(int a, int b)
        {
            var response = new HttpResponseMessage(HttpStatusCode.OK);
            response.Content = new StringContent(Convert.ToString(a + b));

            return response;
        }

        [HttpGet]
        public HttpResponseMessage Multiply(int a, int b)
        {
            var response = new HttpResponseMessage(HttpStatusCode.OK);
            response.Content = new StringContent(Convert.ToString(a * b));

            return response;
        }

        public HttpResponseMessage Divide(int a, int b)
        {
            var response = new HttpResponseMessage(HttpStatusCode.OK);
            response.Content = new StringContent(Convert.ToString(a / b));

            return response;
        }
    }
}
