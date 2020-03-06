using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using NLog;
using System.Threading.Tasks;
using ConsoleParserApp;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;

namespace ConsoleParserApp
{
    public class ParserApp
    {
        private static readonly NLog.Logger Logger = NLog.LogManager.GetCurrentClassLogger();

        public string genderJson;
        public string bdayJson;
        public string lastNameJson;

        public string firstFilePath;
        public string secondFilePath;
        public string thirdFilePath;

        public void GetParserTask(string[] args)
        {

            if (args.Length != 3)
            {
                System.ArgumentException argEx = new System.ArgumentException("Correct amount of File Paths needs to be entered please!", "Too Much/Too Little!");
                Logger.Error(argEx);
                throw argEx;
            }

            try
            {
                Logger logger = LogManager.GetLogger("Logger");
                RunEngine runEngine = new RunEngine();
                foreach (var fileName in args)
                {
                    if (File.Exists(fileName))
                    {

                        runEngine.ReadingEngine(fileName);
                    }
                    else
                    {
                        System.ArgumentException argEx = new System.ArgumentException("File Doesn't Exist! Please Check Directory!!! Check the C: Drive! Check the Hard Drive!!!! Call the FBI!!", "AHHHHHHHHHHHHHHHHHHHHHh");
                        Logger.Error(argEx);
                        Console.WriteLine(argEx);

                    }
                }
                //runEngine.PublishCombinedRecordsToTextFile(); In case you wanted a text file generated...
                var gender = runEngine.PublishGenderSortedRecords();
                var bday = runEngine.PublishBirthdaySortedRecords();
                var lastName = runEngine.PublishLastNameSortedRecords();

                genderJson = JsonSerializer.Serialize(gender);
                bdayJson = JsonSerializer.Serialize(bday);
                lastNameJson = JsonSerializer.Serialize(lastName);

            }
            catch (Exception ex)
            {
                Logger.Error(ex);
            }
        }

    }
}
