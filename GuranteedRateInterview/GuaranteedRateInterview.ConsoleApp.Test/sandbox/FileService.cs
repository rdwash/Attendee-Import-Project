using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuaranteedRateInterview.ConsoleApp.Test.sandbox
{
    public class FileService
    {
        public IFileProcessor FileProcessor { get; private set; }
        public List<FileRecord> FileRecords { get; private set; }

        public FileService(IFileProcessor fileProcessor)
        {
            FileProcessor = fileProcessor;
        }

        public void ProcessFile(string fileToProcess)
        {
            FileRecords = FileProcessor.ReadFile(fileToProcess);
        }

        public void SetSortOrder(string sortOrder = "")
        {
            if(FileRecords != null && FileRecords.Count > 1)
            {
                if (!String.IsNullOrEmpty(sortOrder))
                {
                    if (sortOrder == "gender")
                        FileRecords = FileRecords.OrderBy(x => x.Gender).ThenBy(y => y.LastName).ToList();

                    if (sortOrder == "birthdate")
                        FileRecords = FileRecords.OrderBy(x => x.DateOfBirth).ToList();

                    if (sortOrder == "lastname")
                        FileRecords = FileRecords.OrderBy(x => x.LastName).ToList();
                }
            }            
        }

        public void DisplayFileRecords()
        {
            if (FileRecords == null || FileRecords.Count == 0)
                Console.WriteLine("No records to display");

            foreach(var record in FileRecords)
            {
                record.DisplayInfo();
            }
        }
    }
}