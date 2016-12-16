using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuaranteedRateInterview.Common.Models
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

        public void DisplayInfo()
        {
            Console.WriteLine(string.Format("Last Name: {0}, First Name: {1}, Gender: {2}, Favorite Color: {3}, Date of Birth: {4}", LastName, FirstName, Gender, FavoriteColor, DateOfBirth.ToShortDateString()));
        }
    }
}
