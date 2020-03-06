# ConsoleAppParserAndAPI
Console App takes in text file with formatted records and sorts them and publishes the ordered data to a API endpoint

One Solution file but 2 different and stand alone projects. Here's how to run them in Visual Studio 2019!

ConsoleParserApp:
Set ConsoleParserApp to Start up project in Visual Studio.
This console app takes 3 command line string arguments that should be the name of text files that need to be parsed.
I.e: Character.txt (extension should be included)
    Assumption 1: ConsoleParserApp > Properties > Debug > Working Directory is set to the directory that the text files are in.
This should output to the Console screen the combined records of the three files sorted by:
-Gender then by last name ascending
-Birth date ascending
-Last name descending

ParserAPI:
Set ParserAPI to Start up project.
  Assumption 2: Within the appsettings.json file, the paths for the text files are specified with the following keys:
    FilePath1: "C:\\Example\\File\\Path\\CharacterFile1.txt"
    FilePath2: "C:\\Example\\File\\Path\\CharacterFile2.txt"
    FilePath3: "C:\\Example\\File\\Path\\CharacterFile3.txt"
    Change the values to those keys for those files to be processed by the ConsoleParserApp.
Run the project, ISS set with Firefox or Google Chrome should be fine.
Once the initial endpoint appears you should be greated with a message of conformation that the ParserAPI is now running.
You can navigate to a few diferent endpoints to see records in a JSON format and sorted using the ConsolParserApp above.
localhost:XXXXX/records/gender --> returns records sorted by gender
localhost:XXXXX/records/name --> returns records sorted by birthdate
localhost:XXXXX/records/birthdate --> returns records sorted by name
localhost:XXXXX/records --> Send a line of a JSON record.












:D
