using System;

namespace P01.Stream_Progress
{
    public class Program
    {
        static void Main()
        {
            StreamProgressInfo progress = new StreamProgressInfo(new CodeSheet("C#", 50, 10000));
            Console.WriteLine(progress.CalculateCurrentPercent());
        }
    }
}
