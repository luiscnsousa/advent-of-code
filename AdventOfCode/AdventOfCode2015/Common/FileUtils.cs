namespace AdventOfCode2015.Common
{
    using System;
    using System.Diagnostics;
    using System.IO;

    public static class FileUtils
    {
        public static string[] GetProblemInput()
        {
            var stackTrace = new StackTrace();
            var day = stackTrace.GetFrame(1).GetMethod().DeclaringType.Name;
            var filePath = Path.Combine(
                Environment.CurrentDirectory, 
                "Days", 
                day,
                $"{stackTrace.GetFrame(1).GetMethod().DeclaringType.Name}Input.txt");
            var problemInput = File.ReadAllLines(filePath);
            return problemInput;
        } 
    }
}
