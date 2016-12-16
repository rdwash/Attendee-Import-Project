using System.Collections.Generic;
using System.IO;
using System.Linq;
using GuaranteedRateInterview.Common.Types;
using GuaranteedRateInterview.Common.Models;

namespace GuaranteedRateInterview.Common.Services
{
    public class FileProcessor : IFileProcessor
    {
        public List<FileRecord> ReadFile(string fileToProcess)
        {
            List<FileRecord> fileRecords = new List<FileRecord>();

            if(File.Exists(fileToProcess))
            {
                using (StreamReader reader = new StreamReader(fileToProcess))
                {
                    string record = string.Empty;
                    while ((record = reader.ReadLine()) != null)
                    {
                        foreach (KeyValuePair<string, char> pair in DelimeterTypes.DelimeterTypesDict)
                        {
                            if (record.Contains(pair.Value))
                            {
                                LoadFileData(fileRecords, record, pair.Value);
                            }
                        }
                    }
                }
            }            

            return fileRecords;            
        }

        private static void LoadFileData(List<FileRecord> fileRecords, string record, char delimeter)
        {
            if(fileRecords != null)
            {
                string[] recordData = record.Split(delimeter);
                FileRecord newFileRecord = new FileRecord(recordData[0], recordData[1], recordData[2], recordData[3], recordData[4]);
                fileRecords.Add(newFileRecord);
            }            
        }
    }
}