using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Services;

namespace Medialink.Api.Controllers
{
    public class MathController : ApiController
    {
        public MathController()
        {
        }

        [WebMethod]
        public HttpResponseMessage Add(int a, int b)
        {
            var response = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(Convert.ToString(a + b))
            };

            return response;
        }

        [HttpGet]
        public HttpResponseMessage Multiply(int a, int b)
        {
            var response = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(Convert.ToString(a * b))
            };

            return response;
        }

        [HttpGet]
        public HttpResponseMessage Divide(int a, int b)
        {
            var response = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(Convert.ToString(a / b))
            };

            return response;
        }
    }
}
