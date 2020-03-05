using System;
using System.IO;
using NLog;
using System.Threading.Tasks;
using ConsoleParserApp;
using System.Net.Http;
using System.Net.Http.Headers;

namespace ConsoleParserApp
{
    public class Program
    {
        private static readonly NLog.Logger Logger = NLog.LogManager.GetCurrentClassLogger();
        public static void Main(string[] args)
        {
            ParserApp parserApp = new ParserApp();
            parserApp.GetParserTask(args);

        }
    }
}
