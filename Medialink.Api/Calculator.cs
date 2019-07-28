using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web;

namespace Medialink.Api
{
    public class Calculator
    {
        public static int Calculate(int a, int b, [CallerMemberName] string operation = null)
        {
            int result = 0;

            switch (operation)
            {
                case "Add": result = a + b;
                    break;
                case "Multiply": result = a * b;
                    break;
                case "Divide": result = a / b;
                    break;
                default: result = 0;
                    break;
            }

            return result;
        }
    }
}