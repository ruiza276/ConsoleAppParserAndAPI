using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ConsoleParserApp;
using ConsoleParserApp.Models;

namespace ParserAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class Records : ControllerBase
    {

        ParserApp parserApp = new ParserApp();
        string[] args = new string[3];

        private readonly ILogger<Records> _logger;

        public Records(ILogger<Records> logger)
        {
            _logger = logger;
        }


        [HttpGet]
        [Route("Test")]
        public ActionResult Test()
        {
            return Ok("You have reached the Parser Api test endpoint");
        }

        [HttpGet]
        [Route("gender")]
        [ProducesResponseType(statusCode: 200, type: typeof(string))]
        public ActionResult GetGenderSorted()
        {
            args[0] = @"C:\Users\aruiz\Desktop\TestFolder\TifaFile.txt";
            args[1] = @"C:\Users\aruiz\Desktop\TestFolder\CloudFile.txt";
            args[2] = @"C:\Users\aruiz\Desktop\TestFolder\AerithFile.txt";
            parserApp.GetParserTask(args);
            return Ok(parserApp.genderJson);
        }

        [HttpGet]
        [Route("birthdate")]
        [ProducesResponseType(statusCode: 200, type: typeof(string))]
        public ActionResult GetBirthdateSorted()
        {

            args[0] = @"C:\Users\aruiz\Desktop\TestFolder\TifaFile.txt";
            args[1] = @"C:\Users\aruiz\Desktop\TestFolder\CloudFile.txt";
            args[2] = @"C:\Users\aruiz\Desktop\TestFolder\AerithFile.txt";
            parserApp.GetParserTask(args);
            return Ok(parserApp.bdayJson);
        }

        [HttpGet]
        [Route("name")]
        [ProducesResponseType(statusCode: 200, type: typeof(string))]
        public ActionResult GetNameSorted()
        {

            args[0] = @"C:\Users\aruiz\Desktop\TestFolder\TifaFile.txt";
            args[1] = @"C:\Users\aruiz\Desktop\TestFolder\CloudFile.txt";
            args[2] = @"C:\Users\aruiz\Desktop\TestFolder\AerithFile.txt";
            parserApp.GetParserTask(args);
            return Ok(parserApp.lastNameJson);
        }

        [HttpPost]
        public ActionResult PostSingleLine(Record record)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Bad Data, please send again");
            }
            Record rec = new Record();
            rec.FirstName = record.FirstName;
            rec.LastName = record.LastName;
            rec.Gender = record.Gender;
            rec.FavoriteColor = record.FavoriteColor;
            rec.DateOfBirth = record.DateOfBirth;
            if (rec.Gender.Trim().ToUpper() == "F")
            {
                rec.GenderFlag = 0;

            }
            else
            {
                rec.GenderFlag = 1;
            }

            if(rec.DelimiterFlag == null)
            {
                rec.DelimiterFlag = " ";
            }

            return Ok(rec);
        }


    }
}
