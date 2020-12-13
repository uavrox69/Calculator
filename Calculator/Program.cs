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
            string nonConNum = "";
            double a = 0;

            sum = sent.ReadString(test, r, parsespot);            
            for (int x = 0; x< numsL.Count; x++)
            {
                Console.WriteLine(numsL[x]);
            }
            for (int x = 0; x < signL.Count; x++)
            {
                Console.WriteLine(signL[x]);
            }
            
            //work.FillList(numsL, signL);
            //sum = work.DoMath();
            Console.WriteLine(sum);
            
        }
        public void ReadString(string equation, Regex pass, int stringSpot)
        {
            int size = equation.Length;
            int place = stringSpot;
            string nonConNum = "";
            double a =0;
            Regex r = pass;
            for (int x = place; x <= size - 1; x++)
            {
                if (r.IsMatch(equation[x].ToString()))
                {
                    nonConNum = nonConNum + equation[x].ToString();

                    if (x == size-1 )
                    {
                        a = Convert.ToDouble(nonConNum);
                        nonConNum = "";
                        numsL.Add(a);
                    }
                }
                else if ( equation[x].ToString() == "(" && r.IsMatch(equation[x-1].ToString()))
                {
                    Console.WriteLine("here");
                    a = Convert.ToDouble(nonConNum);
                    nonConNum = "";
                    numsL.Add(a);
                    signL.Add('*');
                    //place = x + 1;
                    //ReadString(equation, pass, x);

                }
                else if (equation[x].ToString() == "(")
                {
                    Console.WriteLine("or here");
                }
                else if (equation[x].ToString() == ")")
                {
                    Console.WriteLine("or here!");
                }               
                else
                {
                    a = Convert.ToDouble(nonConNum);
                    nonConNum = "";
                    numsL.Add(a);
                    signL.Add(equation[x]);
                }
            }
        }

    }
}
