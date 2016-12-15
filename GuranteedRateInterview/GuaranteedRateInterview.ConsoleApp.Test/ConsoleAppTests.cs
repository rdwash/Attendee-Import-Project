using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GuaranteedRateInterview.ConsoleApp.Test.sandbox;
using NUnit.Framework;

namespace GuaranteedRateInterview.ConsoleApp.Test
{
    [TestFixture]
    public class ConsoleAppTests
    {
        private FileService fileService;
        private string[] files;

        [SetUp]
        public void SetUp()
        {
            fileService = new FileService(new FileProcessor());
            files = Directory.GetFiles("/data/");
        }

        [TearDown]
        public void TearDown()
        {
            fileService = null;
        }

        [Test]
        public void FileServiceFileProcessorExists()
        {
                        
        }

        [Test]
        public void SortingByGenderShouldReturnAllFemalesFirst()
        {

        }

        [Test]
        public void SortingByBirthDateShouldReturnAllRecordsInAscendingOrder()
        {

        }

        [Test]
        public void SortingByLastNameShouldReturnAllRecordsInAscendingOrder()
        {

        }
    }
}
