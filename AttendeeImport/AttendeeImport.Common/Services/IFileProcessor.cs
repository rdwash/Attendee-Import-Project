using System.Collections.Generic;
using AttendeeImport.Common.Models;

namespace AttendeeImport.Common.Services
{
    public interface IFileProcessor
    {
        List<FileRecord> ReadFile(string fileLocation);
        void LoadFileData(List<FileRecord> fileRecords, string record, char delimeter);
    }
}