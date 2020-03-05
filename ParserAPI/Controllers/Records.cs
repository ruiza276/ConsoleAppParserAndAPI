using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ConsoleParserApp;

namespace ParserAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class Records : ControllerBase
    {

        ParserApp parserApp = new ParserApp();
        string[] args = new string[3];


        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<Records> _logger;

        public Records(ILogger<Records> logger)
        {
            _logger = logger;
        }


        [HttpGet]
        public IActionResult Test()
        {
            return Ok("You have reached the Parser Api test endpoint");
        }

        [HttpGet]
        [Route("gender")]
        [ProducesResponseType(statusCode: 200, type: typeof(string))]
        public IActionResult GetGenderSorted()
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
        public IActionResult GetBirthdateSorted()
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
        public IActionResult GetNameSorted()
        {

            args[0] = @"C:\Users\aruiz\Desktop\TestFolder\TifaFile.txt";
            args[1] = @"C:\Users\aruiz\Desktop\TestFolder\CloudFile.txt";
            args[2] = @"C:\Users\aruiz\Desktop\TestFolder\AerithFile.txt";
            parserApp.GetParserTask(args);
            return Ok(parserApp.lastNameJson);
        }
    }
}
