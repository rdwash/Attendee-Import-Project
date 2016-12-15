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
            List<FileRecord> fileRecords = new List<FileRecord>();

            using (StreamReader reader = new StreamReader(fileToProcess))
            {
                string record = string.Empty;
                while ((record = reader.ReadLine()) != null)
                {
                    foreach(KeyValuePair<string, char> pair in DelimeterTypes.DelimeterTypesDict)
                    {
                        if (record.Contains(pair.Value))
                        {
                            LoadFileData(fileRecords, record, pair.Value);
                        }
                    }               
                }
            }

            return fileRecords;            
        }

        private static void LoadFileData(List<FileRecord> personRecords, string record, char delimeter)
        {
            string[] recordData = record.Split(delimeter);
            FileRecord newPerson = new FileRecord(recordData[0], recordData[1], recordData[2], recordData[3], recordData[4]);
            personRecords.Add(newPerson);
        }
    }
}