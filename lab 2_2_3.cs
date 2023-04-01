using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;

namespace ConsoleApp23
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Exercise.FirstPart();
            Console.WriteLine();
            Exercise.SecondPart();
            Console.ReadKey();
        }
    }
    public class Exercise 
    {
        public static string text;
        public static void FirstPart()
        {
            StreamReader sr = new StreamReader("input1.txt");
            text = sr.ReadLine();
            string regex = Regex.Replace(text, @"[+,*,^,%,:,=]","");
            Console.WriteLine(regex);
        }
        public static void SecondPart()
        {
            StreamReader sr = new StreamReader("input2.txt");
            text = sr.ReadLine();
            MatchCollection MC = new Regex("(((0[1-9]|([1-2][0-9])|([3][0-1])).(0[1-9]|10|11|12)).2023)").Matches(text);
            foreach (Match M in MC)
            {
                Console.WriteLine(M);
            }
        }
    }

}
