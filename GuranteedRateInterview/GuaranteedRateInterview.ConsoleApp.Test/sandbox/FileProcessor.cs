using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuaranteedRateInterview.ConsoleApp.Test.sandbox
{
    public class FileProcessor : IFileProcessor
    {
        public List<FileRecord> ReadFile(string fileToProcess)
        {
            List<FileRecord> fileRecords = null;

            using (StreamReader reader = new StreamReader(fileToProcess))
            {
                string record = string.Empty;
                while ((record = reader.ReadLine()) != null)
                {
                    foreach(var delimType in Enum.GetValues(typeof(DelimeterTypes)))
                    {
                        if(record.Contains((string)delimType))
                        {
                            LoadFileData(fileRecords, record, delimType);
                        }
                    }                    
                }
            }

            return fileRecords;            
        }

        private static void LoadFileData(List<FileRecord> personRecords, string record, object delimType)
        {
            string[] recordData = record.Split((char)delimType);
            FileRecord newPerson = new FileRecord(recordData[0], recordData[1], recordData[2], recordData[3], recordData[4]);
            personRecords.Add(newPerson);
        }
    }
}
