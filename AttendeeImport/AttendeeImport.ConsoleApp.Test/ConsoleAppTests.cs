using System.Collections.Generic;
using System.IO;
using NUnit.Framework;
using FluentAssertions;
using AttendeeImport.Common.Services;
using AttendeeImport.Common.Models;

namespace GuaranteedRateInterview.ConsoleApp.Test
{
    [TestFixture]
    public class ConsoleAppTests
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
            for(var i = 0; i < files.Length; i++)
            {
                files[i] = string.Empty;
            }
        }

        [Test]
        public void FileProcessor_RecordListShouldContainZeroRecordsIfInputFileDoesNotExist()
        {
            List<FileRecord> fileRecords = fileProcessor.ReadFile(dataDirectory + "noFile.txt");
            fileRecords.Count.Should().Equals(0);
        }

        [Test]
        public void FileProcessor_RecordListShouldMoreThanOneRecordIfInputFileExistWithProperDelimeter()
        {
            List<FileRecord> fileRecords = fileProcessor.ReadFile(files[0]);
            fileRecords.Count.Should().BeGreaterThan(0);
        }

        [Test]
        public void FileService_FileServiceFileProcessorExists()
        {
            Assert.IsNotNull(fileService.FileProcessor);                                   
        }

        [Test]
        public void FileService_RecordsShouldLoadAfterProcessingFile()
        {
            int result = fileService.FileRecords.Count;
            Assert.That(result, Is.GreaterThan(0));
        }              

        [Test]
        public void FileService_SortingByGenderShouldReturnAllFemalesFirst()
        {
            fileService.SetSortOrder("gender");
            fileService.FileRecords.Should().BeInAscendingOrder(x => x.Gender);
        }

        [Test]
        public void FileService_SortingByBirthDateShouldReturnAllRecordsInAscendingOrder()
        {
            fileService.SetSortOrder("birthdate");
            fileService.FileRecords.Should().BeInAscendingOrder(x => x.DateOfBirth);
        }

        [Test]
        public void FileService_SortingByLastNameShouldReturnAllRecordsInAscendingOrder()
        {
            fileService.SetSortOrder("lastname");
            fileService.FileRecords.Should().BeInAscendingOrder(x => x.LastName);
        }

        [Test]
        public void FileService_ProcessingMultipleFilesTogetherShouldAppendRecordsNotOverwrite()
        {
            FileService tempFileService = new FileService(new FileProcessor());
            tempFileService.ProcessFile(files[0]);

            foreach(string file in files)
            {
                fileService.ProcessFile(file);
            }

            fileService.FileRecords.Should().NotBeSameAs(tempFileService.FileRecords);
            fileService.FileRecords.Count.Should().NotBe(tempFileService.FileRecords.Count);
            fileService.FileRecords.Count.Should().BeGreaterThan(tempFileService.FileRecords.Count);
        }
    }
}
