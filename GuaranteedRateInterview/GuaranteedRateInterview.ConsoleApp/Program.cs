using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using GuaranteedRateInterview.Common.Services;

namespace GuaranteedRateInterview.ConsoleApp
{
    public class Program
    {
        public const string dataDirectory = @"..\\..\\data\";

        static void Main(string[] args)
        {
            FileService fileService = new FileService(new FileProcessor());

            string[] files = Directory.GetFiles(dataDirectory); 

            foreach(string f in files)
            {
                fileService.ProcessFile(f);                               
            }

            Console.WriteLine("\n------------SORTED BY GENDER -------------------------------------\n");
            fileService.SetSortOrder("gender");
            fileService.DisplayFileRecords();

            Console.WriteLine("\n------------SORTED BY BIRTH DATE -------------------------------------\n");
            fileService.SetSortOrder("birthdate");
            fileService.DisplayFileRecords();

            Console.WriteLine("\n------------SORTED BY LAST NAME -------------------------------------\n");
            fileService.SetSortOrder("lastname");
            fileService.DisplayFileRecords();

            Console.ReadKey();
        }
    }
}