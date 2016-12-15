using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuaranteedRateInterview.ConsoleApp.Test.sandbox
{
    public interface IFileProcessor
    {
        List<FileRecord> ReadFile(string fileLocation);
    }
}
