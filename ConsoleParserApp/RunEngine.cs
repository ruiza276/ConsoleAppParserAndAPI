using System;
using System.IO;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using NLog;
using ConsoleParserApp.Models;

namespace ConsoleParserApp
{
    public class RunEngine
    {
        //Logger GetLogger = new Logger(); Need to instanciate logger for propper debug logging or at least some d=sort of logging
        Logger logger = LogManager.GetLogger("Logger");

        List<Record> totalRecords = new List<Record>();
        
        public void ReadingEngine(string fileName)
        {
            var culture = System.Globalization.CultureInfo.InvariantCulture;
            //Logger logger = LogManager.GetLogger("Logger");
            try
            {
                string line = File.ReadLines(fileName).First(); //????
                if (line.Contains("|"))
                {
                    using (StreamReader reader = new StreamReader(fileName))
                        while ((line = reader.ReadLine()) != null)
                        {
                            Record pipeRecord = new Record();
                            pipeRecord.LastName = (line.Split("|"))[0];
                            pipeRecord.FirstName = (line.Split("|"))[1];
                            pipeRecord.Gender = (line.Split("|"))[2];
                            pipeRecord.FavoriteColor = (line.Split("|"))[3];
                            pipeRecord.DateOfBirth = DateTime.Parse((line.Split(" "))[4]); //WHY
                            pipeRecord.DelimiterFlag = "|";
                            if (pipeRecord.Gender.Trim() == "F")
                            {
                                pipeRecord.GenderFlag = 0;

                            }
                            else
                            {
                                pipeRecord.GenderFlag = 1;
                            }
                            totalRecords.Add(pipeRecord);
                        }
                }
                else if (line.Contains(","))
                {
                    using (StreamReader reader = new StreamReader(fileName))
                        while ((line = reader.ReadLine()) != null)
                        {
                            Record commaRecord = new Record();
                            commaRecord.LastName = (line.Split(","))[0];
                            commaRecord.FirstName = (line.Split(","))[1];
                            commaRecord.Gender = (line.Split(","))[2];
                            commaRecord.FavoriteColor = (line.Split(","))[3];
                            commaRecord.DateOfBirth = DateTime.Parse((line.Split(" "))[4]); //WHY
                            commaRecord.DelimiterFlag = ",";


                            if (commaRecord.Gender.Trim() == "F")
                            {
                                commaRecord.GenderFlag = 0;

                            }
                            else
                            {
                                commaRecord.GenderFlag = 1;
                            }


                            totalRecords.Add(commaRecord);
                        }
                }

                else
                {
                    using (StreamReader reader = new StreamReader(fileName))
                        while ((line = reader.ReadLine()) != null)
                        {
                            Record spaceRecord = new Record();
                            spaceRecord.LastName = (line.Split(" "))[0];
                            spaceRecord.FirstName = (line.Split(" "))[1];
                            spaceRecord.Gender = (line.Split(" "))[2];
                            spaceRecord.FavoriteColor = (line.Split(" "))[3];
                            DateTime formattedDay = DateTime.Parse(line.Split(" ")[4]).Date;
                            spaceRecord.DateOfBirth = formattedDay.Date; //WHY??
                            spaceRecord.DelimiterFlag = " ";

                            if (spaceRecord.Gender.Trim() == "F")
                            {
                                spaceRecord.GenderFlag = 0;

                            }
                            else
                            {
                                spaceRecord.GenderFlag = 1;
                            }

                            totalRecords.Add(spaceRecord);
                        }
                }

            }
            catch (Exception)
            {

                System.ArgumentException argEx = new System.ArgumentException("Something went wrong with the ReadingEngine!!!", "ReadingEngine");
                logger.Error(argEx);
                Console.WriteLine(argEx);

            }

        }

        public void PublishCombinedRecordsToTextFile() //This is not needed BUT it doesn't hurt to have it.
        {
            using (StreamWriter sw = (File.Exists("CombineSetRecords.txt")) ? File.AppendText("CombineSetRecords.txt") : File.CreateText("CombineSetRecords.txt"))
            {
                foreach (var item in totalRecords)
                {
                    sw.WriteLine(item);
                }
            }
        }

        public List<Record> PublishGenderSortedRecords()
        {
            List<Record> GenderSortedRecords = new List<Record>();
            Console.WriteLine("\nRecords Sorted by Gender and Last Name: \n");
            foreach (var item in (totalRecords.OrderBy(o => o.GenderFlag).ThenBy(o => o.LastName)))
            {
                GenderSortedRecords.Add(item);
                Console.WriteLine(item);
            }
            return GenderSortedRecords;
        }

        public List<Record> PublishBirthdaySortedRecords()
        {
            List<Record> BdaySortedRecords = new List<Record>();
            Console.WriteLine("\nRecords Sorted by Date of Birth: \n");
            foreach (var item in (totalRecords.OrderBy(o => o.DateOfBirth)))
            {
                BdaySortedRecords.Add(item);
                Console.WriteLine(item);
            }
            return BdaySortedRecords;
        }

        public List<Record> PublishLastNameSortedRecords()
        {
            List<Record> LastNameSorted = new List<Record>();
            Console.WriteLine("\nRecords Sorted by Last Name: \n");
            foreach (var item in (totalRecords.OrderByDescending(o => o.LastName)))
            {
                LastNameSorted.Add(item);
                Console.WriteLine(item);
            }
            return LastNameSorted;
        }
    }
}
