using System;
using System.IO;
using NLog;

namespace ConsoleParserApp
{
    public class Program
    {
        private static readonly NLog.Logger Logger = NLog.LogManager.GetCurrentClassLogger();

        static void Main(string[] args)
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
                //runEngine.PublishCombinedRecordsToTextFile();
                runEngine.PublishGenderSortedRecords();
                runEngine.PublishBirthdaySortedRecords();
                runEngine.PublishLastNameSortedRecords();
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
            }
        }
    }
}
