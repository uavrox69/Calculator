using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Calculator
{
    //This class is used to parse and order the equation setting it up to do the math following the proper rules 
    class Parsing
    {
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
                    place = x + 1;
                    numsL.Add(paran.ReadString(equation, pass, place));
                    x = Program.parsespot;
                }
                else if (equation[x].ToString() == ")")
                {
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
            stringSum = work.DoMath();
            return stringSum;

        }
    
    }
}
