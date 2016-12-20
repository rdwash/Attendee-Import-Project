using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttendeeImport.Common.Models
{
    public class FileRecord
    {
        public string LastName { get; private set; }
        public string FirstName { get; private set; }
        public string Gender { get; private set; }
        public string FavoriteColor { get; private set; }
        public DateTime DateOfBirth { get; private set; }

        public FileRecord(string lastName, string firstName, string gender, string favoriteColor, string dateofbirth)
        {
            LastName = lastName;
            FirstName = firstName;
            Gender = gender;
            FavoriteColor = favoriteColor;
            DateOfBirth = DateTime.Parse(dateofbirth);
        }

        public string DisplayInfo()
        {
            return string.Format("{0}, {1} --- G: {2} --- FC: {3} --- DOB: {4}", LastName, FirstName, Gender, FavoriteColor, DateOfBirth.ToShortDateString());
        }
    }
}
