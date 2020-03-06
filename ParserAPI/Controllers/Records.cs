using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ConsoleParserApp;
using ConsoleParserApp.Models;
using Microsoft.Extensions.Configuration;

namespace ParserAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class Records : ControllerBase
    {

        ParserApp parserApp = new ParserApp();
        string[] args = new string[3];
        private IConfiguration config;
        private readonly ILogger<Records> _logger;

        public Records(ILogger<Records> logger, IConfiguration Iconfig)
        {
            _logger = logger;
            config = Iconfig;
        }


        [HttpGet]
        [Route("Test")]
        public ActionResult Test()
        {
            return Ok("Hi hello friend!! ParserAPI is up and running! :D");
        }

        [HttpGet]
        [Route("gender")]
        [ProducesResponseType(statusCode: 200, type: typeof(string))]
        public ActionResult GetGenderSorted()
        {
            args[0] = config.GetSection("FilePath1").Value;
            args[1] = config.GetSection("FilePath2").Value;
            args[2] = config.GetSection("FilePath3").Value;
            parserApp.GetParserTask(args);
            return Ok(parserApp.genderJson);
        }

        [HttpGet]
        [Route("birthdate")]
        [ProducesResponseType(statusCode: 200, type: typeof(string))]
        public ActionResult GetBirthdateSorted()
        {

            args[0] = config.GetSection("FilePath1").Value;
            args[1] = config.GetSection("FilePath2").Value;
            args[2] = config.GetSection("FilePath3").Value;
            parserApp.GetParserTask(args);
            return Ok(parserApp.bdayJson);
        }

        [HttpGet]
        [Route("name")]
        [ProducesResponseType(statusCode: 200, type: typeof(string))]
        public ActionResult GetNameSorted()
        {

            args[0] = config.GetSection("FilePath1").Value;
            args[1] = config.GetSection("FilePath2").Value;
            args[2] = config.GetSection("FilePath3").Value;
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
