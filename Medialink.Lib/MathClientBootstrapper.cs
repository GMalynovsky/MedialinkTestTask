using MediaLink.Lib.LogService;
using MediaLink.Lib.MathService;
using RestSharp;
using System.Net;
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
            container.RegisterType<IMathRestClient, MathRestClient>();

            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;

            return container.Resolve<MathWebClient>();
        }
    }
}
