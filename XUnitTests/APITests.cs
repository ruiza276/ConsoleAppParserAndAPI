using System;
using System.IO;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using ConsoleParserApp;
using ConsoleParserApp.Models;
using ParserAPI.Controllers;
using ParserAPI;
using Xunit;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;

namespace XUnitTests
{
    public class APITests
    {
        private IConfiguration config;
        private readonly ILogger<Records> _logger;
        DateTime thisDay = DateTime.Today;




        [Fact]
        public void GetNameSorted()
        {
            Records controller = new Records(_logger, config);
            ConsoleParserApp.Models.Record rec = new ConsoleParserApp.Models.Record();

            var result = controller.GetNameSorted();

            Assert.IsType<Microsoft.AspNetCore.Mvc.OkObjectResult>(result);

        }

        [Fact]
        public void GetBdaySorted()
        {
            Records controller = new Records(_logger, config);
            ConsoleParserApp.Models.Record rec = new ConsoleParserApp.Models.Record();

            var result = controller.GetBirthdateSorted();

            Assert.IsType<Microsoft.AspNetCore.Mvc.OkObjectResult>(result);

        }


        [Fact]
        public void GetGenderSorted()
        {
            Records controller = new Records(_logger, config);
            ConsoleParserApp.Models.Record rec = new ConsoleParserApp.Models.Record();

            var result = controller.GetGenderSorted();

            Assert.IsType<Microsoft.AspNetCore.Mvc.OkObjectResult>(result);

        }

        [Fact]
        public void RecordsTest()
        {
            // Arrange
            Records controller = new Records(_logger, config);
            ConsoleParserApp.Models.Record rec = new ConsoleParserApp.Models.Record();

            rec.FirstName = "Alex";
            rec.LastName = "Ruiz";
            rec.Gender = "FeMaLe";
            rec.FavoriteColor = "Orange";
            rec.DateOfBirth = thisDay;
            var result = controller.PostSingleLine(rec);


            Assert.IsType<Microsoft.AspNetCore.Mvc.OkObjectResult> (result);
        }
    }
}

