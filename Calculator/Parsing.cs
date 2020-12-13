using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Calculator
{
    class Parsing
    {
        //public static List<double> numsL = new List<double>();
        //public static List<char> signL = new List<char>(); 
        public static int parseSpot = 0;
        public static int stringSize= 0;
        Regex r;


        public double ReadString(string equation, Regex pass, int stringSpot)
        {
            stringSize = equation.Length;
            int place = stringSpot;
            string nonConNum = "";
            double stringSum = 0;
            double a = 0;
            Parsing paran = new Parsing();
            CalcMethods work = new CalcMethods();
            List<double> numsL = new List<double>();
            List<char> signL = new List<char>();
            r = pass;
            for (int x = place; x <= stringSize - 1; x++)
            {
                //Console.WriteLine(equation[x]);
                if (r.IsMatch(equation[x].ToString()))
                {
                    nonConNum = nonConNum + equation[x].ToString();

                    if (x == stringSize - 1)
                    {
                        a = Convert.ToDouble(nonConNum);
                        nonConNum = "";
                        numsL.Add(a);
                    }
                }
                else if (equation[x].ToString() == "(" && r.IsMatch(equation[x - 1].ToString()))
                {
                    //Console.WriteLine("here");
                    a = Convert.ToDouble(nonConNum);
                    nonConNum = "";
                    numsL.Add(a);
                    signL.Add('*');
                    place = x + 1;                  
                    numsL.Add(paran.ReadString(equation, pass,place));
                    x = Program.parsespot;

                }
                else if (equation[x].ToString() == "(")
                {
                    //Console.WriteLine("or here");
                    place = x + 1;
                    numsL.Add(paran.ReadString(equation, pass, place));
                    x = Program.parsespot;
                }
                else if (equation[x].ToString() == ")")
                {
                    //Console.WriteLine("or here!");
                    if (nonConNum != "")
                    {
                        a = Convert.ToDouble(nonConNum);
                        nonConNum = "";
                        numsL.Add(a);
                    }
                    if ( x != stringSize - 1)
                    {
                        Program.parsespot = x;
                    }
                    else
                    {
                        Program.parsespot = x;
                    }
                    break;
                }
                else
                {
                    if ( nonConNum != "")
                    {
                        a = Convert.ToDouble(nonConNum);
                        nonConNum = "";
                        numsL.Add(a);
                    }
                    
                    signL.Add(equation[x]);
                }
            }
            work.FillList(numsL, signL);
            /*
            for (int x = 0; x < numsL.Count; x++)
            {
                Console.WriteLine(numsL[x]);
            }
            for (int x = 0; x < signL.Count; x++)
            {
                Console.WriteLine(signL[x]);
            }
            */
            //Console.WriteLine("end list");
            stringSum = work.DoMath();
            //Console.WriteLine(stringSum);
            return stringSum;

        }
        /*
        public double ReadParan( string equation, Regex r, int spot)
        {
            double stringSum = 0;
            double a = 0;
            string nonConNum = "";
            List<double> pNumsL = new List<double>();
            List<char> pSignL = new List<char>();

            for (int x = spot; x <= stringSize - 1; x++)
            {
                if (r.IsMatch(equation[x].ToString()))
                {
                    nonConNum = nonConNum + equation[x].ToString();

                    if (x == stringSize - 1)
                    {
                        a = Convert.ToDouble(nonConNum);
                        nonConNum = "";
                        numsL.Add(a);
                    }
                }
                else if (equation[x].ToString() == "(" && r.IsMatch(equation[x - 1].ToString()))
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

            return stringSum;

        }
        */
    }
}
