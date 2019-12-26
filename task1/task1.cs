using System;
using System.Collections.Generic;
using System.IO;

namespace task1
{
    class task1
    {
        static List<int> numbers = new List<int>();
        static void Main(string[] args)
        {
            if (getNumbers(args[0]))
            {
                numbers.Sort();
                Console.WriteLine(getPrcntl().ToString("0.00"));
                Console.WriteLine(getMedian().ToString("0.00"));
                Console.WriteLine(numbers[numbers.Count - 1].ToString("0.00"));
                Console.WriteLine(numbers[0].ToString("0.00"));
                Console.WriteLine(getAvg().ToString("0.00"));
            }
            Console.ReadLine();
        }
        static bool getNumbers(string path)
        {
            try
            {
                string[] fileData = File.ReadAllLines(path);
                foreach (var s in fileData)
                {
                    if (short.TryParse(s, out short result))
                        numbers.Add(result);
                    else
                        continue;
                }
                return true;
            }
            catch (FileNotFoundException ex) { Console.WriteLine(ex.Message); Console.WriteLine("Не смог открыть файл"); return false; }
        }
        static double getAvg()
        {
            int summ = 0;
            foreach (var n in numbers)
                summ += n;
            return summ / (double)numbers.Count;
        }
        static double getMedian()
        {
            if (numbers.Count % 2 == 0)
            {
                int index = numbers.Count / 2;
                return (numbers[index - 1] + numbers[index]) / 2d;
            }
            else
            {
                return numbers[(numbers.Count) / 2];
            }
        }
        static double getPrcntl()
        {
            double x = Math.Round(0.9f * (numbers.Count - 1) + 1, 2);
            return numbers[(int)x - 1] + (x - (int)x) * (numbers[(int)x] - numbers[(int)x - 1]);
        }
    }
}