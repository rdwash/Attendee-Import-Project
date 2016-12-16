using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using GuaranteedRateInterview.Common.Services;
using GuaranteedRateInterview.Common.Models;
using System.IO;

namespace GuaranteedRateInterview.RESTApi.Controllers
{
    public class FileDataController : ApiController
    {
        FileService fileService;
        string[] files;

        public FileDataController()
        {
            string dataDirectory = @"..\\..\\data\";
            fileService = new FileService(new FileProcessor());
            files = Directory.GetFiles(dataDirectory);
        }

        [Route("/records")]
        public IEnumerable<FileRecord> GetAllRecords()
        {
            foreach(string file in files)
            {
                fileService.ProcessFile(file);
            }

            return fileService.FileRecords;
        }

        [Route("records/{sort}")]
        public IEnumerable<FileRecord> GetRecords(string sort)
        {
            foreach (string file in files)
            {
                fileService.ProcessFile(file);
            }

            fileService.SetSortOrder(sort);

            return fileService.FileRecords;
        }
    }
}
