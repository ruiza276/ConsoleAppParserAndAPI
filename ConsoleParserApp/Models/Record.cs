using System;
using NLog;

namespace ConsoleParserApp.Models
{
    public class Record
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Gender { get; set; }
        public int GenderFlag { get; set; }
        public string FavoriteColor { get; set; }
        public DateTime DateOfBirth { get; set; }

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
