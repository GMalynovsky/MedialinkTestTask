using System.Net.Http;
using Medialink.Common;

namespace Medialink.Api
{
    public interface ICalculatorService
    {
        HttpResponseMessage Calculate(int a, int b, OperationType operation);
    }
}