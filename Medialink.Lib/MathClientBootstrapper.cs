using MediaLink.Lib.LogService;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Unity;
using Unity.Injection;

namespace MediaLink.Lib
{
    public class MathClientBootstrapper
    {
        public static IMathWebClient GetDIMathClient()
        {
            var container = new UnityContainer();

            container.RegisterType<ILogger, LocalDBLogger>();
            container.RegisterType<IRestClient, RestClient>(new InjectionConstructor("https://medialinkapi.azurewebsites.net/api/math/"));

            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;

            return container.Resolve<MathWebClient>();
        }
    }
}
