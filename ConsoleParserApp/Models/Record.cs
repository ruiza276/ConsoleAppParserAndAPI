using System;
using System.ComponentModel.DataAnnotations;
using NLog;

namespace ConsoleParserApp.Models
{
    public class Record
    {
        [Required]
        public string LastName { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string Gender { get; set; }
        [Required]
        public string FavoriteColor { get; set; }
        [Required]
        public DateTime DateOfBirth { get; set; }
        public int GenderFlag { get; set; }
        public string DelimiterFlag { get; set; }

        public override string ToString()
        {
            if (DelimiterFlag == "|")
            {
                return LastName + "|" + FirstName + "|" + Gender + "|" + FavoriteColor + "|" + DateOfBirth;

            }
            else if(DelimiterFlag == ",") 
            {
                return LastName + "," + FirstName + "," + Gender + "," + FavoriteColor + "," + DateOfBirth;

            }
            else
            {
                return LastName + " " + FirstName + " " + Gender + " " + FavoriteColor + " " + DateOfBirth;
            }

        }
    }
}
