using System.Collections.Generic;
using GuaranteedRateInterview.Common.Models;

namespace GuaranteedRateInterview.Common.Services
{
    public interface IFileProcessor
    {
        List<FileRecord> ReadFile(string fileLocation);
        void LoadFileData(List<FileRecord> fileRecords, string record, char delimeter);
    }
}