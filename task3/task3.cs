using System;
using System.Globalization;
using System.IO;

namespace task3
{
    class task3
    {
        static float[] Cash1 = new float[16];
        static float[] Cash2 = new float[16];
        static float[] Cash3 = new float[16];
        static float[] Cash4 = new float[16];
        static float[] Cash5 = new float[16];
        static float[] allCashes = new float[16];
        static CultureInfo culture;
        static void Main(string[] args)
        {
            culture = (CultureInfo)CultureInfo.CurrentCulture.Clone();
            culture.NumberFormat.NumberDecimalSeparator = ".";
            getAllData(args[0]);
            summAllCashes();
            Console.WriteLine(getBiggestSumIndex() + 1);
            Console.ReadLine();
        }
        
        static void getAllData(string path)
        {
            string p1 = path + "/Cash" + 1 + ".txt";
            string p2 = path + "/Cash" + 2 + ".txt";
            string p3 = path + "/Cash" + 3 + ".txt";
            string p4 = path + "/Cash" + 4 + ".txt";
            string p5 = path + "/Cash" + 5 + ".txt";
            string[] Cash1String = File.ReadAllLines(p1);
            string[] Cash2String = File.ReadAllLines(p2);
            string[] Cash3String = File.ReadAllLines(p3);
            string[] Cash4String = File.ReadAllLines(p4);
            string[] Cash5String = File.ReadAllLines(p5);
            for (int i = 0; i < Cash1String.Length; i++)
            {
                Cash1[i] = float.Parse(Cash1String[i], culture);
            }
            for (int i = 0; i < Cash2String.Length; i++)
            {
                Cash2[i] = float.Parse(Cash2String[i], culture);
            }
            for (int i = 0; i < Cash3String.Length; i++)
            {
                Cash3[i] = float.Parse(Cash3String[i], culture);
            }
            for (int i = 0; i < Cash4String.Length; i++)
            {
                Cash4[i] = float.Parse(Cash4String[i], culture);
            }
            for (int i = 0; i < Cash5String.Length; i++)
            {
                Cash5[i] = float.Parse(Cash5String[i], culture);
            }
        }
        static void summAllCashes()
        {
            for (int i = 0; i < Cash1.Length; i++)
                allCashes[i] += Cash1[i] + Cash2[i] + Cash3[i] + Cash4[i] + Cash5[i];
        }
        static int getBiggestSumIndex()
        {
            int index = 0;
            float currentBiggestSumm = allCashes[0];
            for (int i = 1; i < allCashes.Length; i++)
            {
                if (allCashes[i] > currentBiggestSumm)
                {
                    currentBiggestSumm = allCashes[i];
                    index = i;
                }
            }
            return index;
        }
    }
}