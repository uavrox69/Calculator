using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;

namespace Calculator
{
    class Program
    {
        public static List<double> numsL = new List<double>();
        public static List<char> signL = new List<char>();
        public static int parsespot = 0;



        static void Main(string[] args)
        {
            
            double sum;//will need sum later on with culumitive
            CalcMethods work = new CalcMethods();
            Parsing sent = new Parsing();
            Console.WriteLine("Enter a equation");
            string test = Console.ReadLine();

            test = work.ElimSpace(test);

            string pattern = "[0-9.]";
            Regex r = new Regex(pattern);

            sum = sent.ReadString(test, r, parsespot);            

            Console.WriteLine(sum);
            
        }      
    }
}
