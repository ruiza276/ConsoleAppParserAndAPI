using System;
using System.IO;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using ConsoleParserApp;
using ConsoleParserApp.Models;
using Xunit;

namespace XUnitTestProject
{
    public class ConsoleTests
    {
        RunEngine runEngine = new RunEngine();

        [Fact]
        public void Test1()
        {
            int Expected = 3;

            runEngine.ReadingEngine("CloudFile.txt");
            var result = runEngine.totalRecords.Count;
            Assert.Equal(Expected, result);

        }

        [Fact]
        public void Test2()
        {
            DateTime thisDay = DateTime.Today;
            //date = date.now;
            ConsoleParserApp.Models.Record rec = new ConsoleParserApp.Models.Record();
            rec.FirstName = "Cait";
            rec.LastName = "Sith";
            rec.Gender = "M";
            rec.FavoriteColor = "Pink";
            rec.DateOfBirth = thisDay;
            runEngine.ReadingEngine("AerithFile.txt"); //Make sure the solution is pointing to the right directory!
            var result = runEngine.PublishLastNameSortedRecords().First().FirstName;
            Assert.Equal(rec.FirstName, result);

        }
        [Fact]
        public void GetParserTaskTest()
        {
            ParserApp parserApp = new ParserApp();
            string[] args = new string[0];
            System.ArgumentException argEx = new System.ArgumentException("Correct amount of File Paths needs to be entered please!", "Too Much/Too Little!");

            Exception ex = Assert.Throws<ArgumentException>(() => parserApp.GetParserTask(args));

            Assert.Equal(ex.Message, argEx.Message);


        }


    }
}