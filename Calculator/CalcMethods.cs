using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Calculator
{
    class CalcMethods
    {
        private List<double> nums;
        private List<char> signs;
        
        public void Calcmethods()
        {
            nums = new List<double>();
            signs = new List<char>();

        }       
        public double Addition(double a, double b)
        {
            double sum = a + b;
            return sum;
        }
        public double Subtraction(double a, double b)
        {
            double sum = a - b;
            return sum;
        }
        public double Division(double a, double b)
        {
            double sum = a / b;
            return sum;
        }
        public double Multiplication(double a, double b)
        {
            double sum = a * b;
            return sum;
        }
        
       public double DoMath()
        {            
            double sum = 0;
            int spot = 0;
            while (signs.Count != 0)
            {
                spot = FindHiSign();

                if ( spot == signs.Count + 1)
                {
                    spot = 0;
                }
                char sign = signs[spot];
                switch (sign)
                {
                    case '+':
                        sum = Addition(nums[spot], nums[spot + 1]);
                        break;
                    case '-':
                        sum = Subtraction(nums[spot], nums[spot + 1]);
                        break;
                    case '*':
                        sum = Multiplication(nums[spot], nums[spot + 1]);
                        break;
                    case '/':
                        sum = Division(nums[spot], nums[spot + 1]);
                        break;
                    default:
                        Console.WriteLine("Not a valid sign");
                        break;

                }
                nums.RemoveAt(spot);
                nums.Insert(spot, sum);
                nums.RemoveAt(spot + 1);
                signs.RemoveAt(spot);
                sum = 0;
            }
            
            return nums[0];

        }
        public int FindHiSign()
        {
            int place = signs.Count + 1;
            
            for (int x = 0; x < signs.Count; x++)
            {
                char checker = signs[x];
                if ( checker == '*' || checker == '/' )
                {
                    place = x;                 
                }
            }

            return place;
        }
        public void FillList( List<double>num, List<char>ops )
        {
            nums = num;
            signs = ops;
        }
       
       
    }
}
