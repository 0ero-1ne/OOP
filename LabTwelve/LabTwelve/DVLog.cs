using System;
using System.IO;

namespace LabTwelve
{
    static class DVLog
    {
        static string LogFile = @"D:\OOP\OOP\LabTwelve\LabTwelve\DVlogfile.txt";

        public static void SaveLog(string action, string fileName, string filePath)
        {
            string date = DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss");
            string log = $"File name: {fileName} - File path: {filePath} - Action: {action} - Date: {date}\n";
            File.AppendAllText(LogFile, log);
        }

        public static void FindLogsByMonth(string month)
        {
            var logs = File.ReadAllLines(LogFile);
            foreach (var log in logs)
            {
                if (log.Contains(" " + month + "/"))
                    Console.WriteLine(log);
            }
        }

        public static int GetLogsAmount()
        {
            return File.ReadAllLines(LogFile).Length;
        }

        public static void DeleteLogs()
        {
            var logs = File.ReadAllLines(LogFile);
            var currentDate = DateTime.Now.Month + "/" + DateTime.Now.Day + "/" + DateTime.Now.Year;
            var currentHour = DateTime.Now.Hour;

            string newLogs = "";

            foreach (var log in logs)
            {
                if (log.Contains(currentDate) && log.Contains(" " + currentHour + ":"))
                    newLogs += log + "\n";
            }

            File.WriteAllText(LogFile, newLogs);
        }
    }
}
