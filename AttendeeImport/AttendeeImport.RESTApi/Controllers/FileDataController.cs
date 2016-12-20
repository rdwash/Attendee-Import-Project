using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Http;
using AttendeeImport.Common.Models;
using AttendeeImport.Common.Services;
using AttendeeImport.Common.Types;
using AttendeeImport.RESTApi.Models;

namespace AttendeeImport.RESTApi.Controllers
{
    public class FileDataController : ApiController
    {
        public FileService fileService;
        public string[] files;

        public FileDataController()
        {
            LoadData();
        }


        public FileDataController(string test)
        {

        }

        private void LoadData()
        {
            string dataDirectory = "~/data/";
            fileService = new FileService(new FileProcessor());
            files = Directory.GetFiles(HttpContext.Current.Server.MapPath(dataDirectory));

            foreach (string file in files)
            {
                fileService.ProcessFile(file);
            }
        }

        [HttpPost]
        [Route("records")]
        public IHttpActionResult Post(NewRecordModel recModel)
        {
            if(recModel == null)
                return Content(HttpStatusCode.NotModified, "Record object sent not the correct type.");

            //Persist to FileRecords list
            foreach (KeyValuePair<string, char> pair in DelimeterTypes.DelimeterTypesDict)
            {
                if (recModel.rec.Contains(pair.Value))
                {
                    fileService.FileProcessor.LoadFileData(fileService.FileRecords, recModel.rec, pair.Value);
                    return Content(HttpStatusCode.OK, fileService.FileRecords);                    
                }
            }

            return Content(HttpStatusCode.NoContent, "Record sent not in correctly delimeted format.");
        }

        [HttpGet]
        [Route("records/{sort}")]        
        public IEnumerable<FileRecord> GetRecords(string sort)
        {  
            fileService.SetSortOrder(sort);
            return fileService.FileRecords;
        }
    }
}