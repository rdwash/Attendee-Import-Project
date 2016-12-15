using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuaranteedRateInterview.ConsoleApp.Test.sandbox
{
    public static class DelimeterTypes
    {
        public enum DelimeterTypesEnum
        {
            Commas = ',',
            Pipes = '|',
            Space = ' '
        }

        public static Dictionary<string, char> DelimeterTypesDict = new Dictionary<string, char>()
        {
            {"commas", ','},
            {"pipes", '|'},
            {"space", ' '}
        };

    }
    
}
