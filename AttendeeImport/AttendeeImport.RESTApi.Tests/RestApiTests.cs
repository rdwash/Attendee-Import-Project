using System.Collections.Generic;
using System.IO;
using AttendeeImport.Common.Models;
using AttendeeImport.Common.Services;
using AttendeeImport.RESTApi.Controllers;
using AttendeeImport.RESTApi.Models;
using FluentAssertions;
using NUnit.Framework;

namespace AttendeeImport.RESTApi.Tests
{
    [TestFixture]
    public class RestApiTests
    {
        private FileService fileService;
        private FileProcessor fileProcessor;
        private string dataDirectory;
        private string[] files;

        [SetUp]
        public void SetUp()
        {
            fileProcessor = new FileProcessor();
            fileService = new FileService(fileProcessor);

            dataDirectory = @"..\\..\\data\";
            files = Directory.GetFiles(dataDirectory);

            fileService.ProcessFile(files[0]);
        }

        [TearDown]
        public void TearDown()
        {
            fileProcessor = null;
            fileService = null;
            dataDirectory = string.Empty;
            for (var i = 0; i < files.Length; i++)
            {
                files[i] = string.Empty;
            }
        }

        [Test]
        public void Post_ShouldReturnNewlyInsertedRecord()
        {
            var controller = new FileDataController("test");
            controller.fileService = fileService;
            
            controller.Post(new NewRecordModel() { rec = "Jordan,Mike,Male,Red,2/17/1969" });

            fileService.FileRecords.Add(new FileRecord("Jordan", "Mike", "Male", "Red", "2/17/1969"));

            controller.fileService.FileRecords.ShouldBeEquivalentTo(fileService.FileRecords);                         
        }

        [Test]
        public void GetRecords_GenderSortShouldReturnRecordsInOrderByGenderAsc()
        {
            var controller = new FileDataController("test");
            controller.fileService = fileService;

            var result = controller.GetRecords("gender") as List<FileRecord>;

            result.Should().BeInAscendingOrder(x => x.Gender);
        }

        [Test]
        public void GetRecords_BirthDateSortShouldReturnRecordsInOrderByBirthDateAsc()
        {
            var controller = new FileDataController("test");
            controller.fileService = fileService;

            var result = controller.GetRecords("birthdate") as List<FileRecord>;

            result.Should().BeInAscendingOrder(x => x.DateOfBirth);
        }

        [Test]
        public void GetRecords_NameSortShouldReturnRecordsInOrderByLastNameAsc()
        {
            var controller = new FileDataController("test");
            controller.fileService = fileService;

            var result = controller.GetRecords("lastname") as List<FileRecord>;

            result.Should().BeInAscendingOrder(x => x.LastName);
        }

        [Test]
        public void GetRecords_BadSortShouldReturnRecordsInOriginalOrder()
        {
            var controller = new FileDataController("test");
            controller.fileService = fileService;

            var result = controller.GetRecords("fake") as List<FileRecord>;

            result.Should().BeEquivalentTo(fileService.FileRecords);
        }
    }
}