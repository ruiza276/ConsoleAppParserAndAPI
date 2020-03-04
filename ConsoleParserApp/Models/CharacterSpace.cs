using System;
using System.IO;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileHelpers;
using NLog;


namespace ConsoleParserApp.Models
{
    [DelimitedRecord(" ")]
    public class CharacterSpace
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Gender { get; set; }
        public string FavoriteColor { get; set; }
        public string DateOfBirth { get; set; }

        public override string ToString()
        {
            return LastName + " " + FirstName + " " + Gender + " " + FavoriteColor + " " + DateOfBirth;
        }

    }
}
