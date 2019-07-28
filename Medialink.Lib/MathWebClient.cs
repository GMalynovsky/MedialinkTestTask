using MediaLink.Lib.LogService;
using MediaLink.Lib.MathService;
using System;

namespace MediaLink.Lib
{
    public class MathWebClient : IMathWebClient
    {
        public MathWebClient(IMathRestClient mathRestClient, ILogger logger)
        {
            _mathRestClient = mathRestClient;
            _logService = logger;
        }

        public int Add(int a, int b)
        {
            return GetResultAndLog(a, b, OperationType.Add);
        }

        public int Multiply(int a, int b)
        {
            return GetResultAndLog(a, b, OperationType.Multiply);
        }

        public int Divide(int a, int b)
        {
            return GetResultAndLog(a, b, OperationType.Divide);
        }

        private int GetResultAndLog(int a, int b, OperationType operation)
        {
            string response = string.Empty;

            try
            {
                switch (operation)
                {
                    case OperationType.Add:
                        response = _mathRestClient.Add(a, b);
                        break;
                    case OperationType.Multiply:
                        response = _mathRestClient.Multiply(a, b);
                        break;
                    case OperationType.Divide:
                        response = _mathRestClient.Divide(a, b);
                        break;
                }

                var result = Convert.ToInt32(response);

                Log($"{operation.ToString()}", LogEntryType.Event, a, b, result);

                return result;
            }
            catch (Exception ex)
            {
                Log($"Response: {response}\nError message: {ex.Message}", LogEntryType.Error);

                throw ex;
            }
        }

        private void Log(string message, LogEntryType type, params int[] p)
        {
            Console.WriteLine(message);

            _logService.Log(message, type, p);
        }

        private readonly IMathRestClient _mathRestClient;
        private readonly ILogger _logService;
    }
}
