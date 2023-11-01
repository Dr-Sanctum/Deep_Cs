using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace T2_5
{
    internal class Calc : ICalc
    {
        public double Result { get; set; }

        public event EventHandler<EventArgs>? CalcChange;

        public void PrintResult()
        {
            CalcChange?.Invoke(this, new EventArgs());
        }

        public double Divide(int x, int y)
        {
            Result = x / y;
            PrintResult();
            return Result;
        }

        public double Multy(int x, int y)
        {
            Result = x * y;
            PrintResult();
            return Result;
        }

        public double Sub(int x, int y)
        {
            Result = x - y;
            PrintResult();
            return Result;
        }

        public double Sum(int x, int y)
        {
            Result = x + y;
            PrintResult();
            return Result;
        }

        public void Run()
        {
            bool run = true;
            string[] expression;
            while (run)
            {
                Console.WriteLine("Введите выражение в виде X + Y, допустимые действия + - / *, чтобы выйти введите 0 или пустую строку");
                try
                {
                    expression = Console.ReadLine().Split(" ");
                    if (expression.Length == 1 && expression[0].Equals("0"))
                    {
                        break;
                    }
                }
                catch (NullReferenceException)
                {
                    break;
                }

                try
                {
                    switch (expression[1])
                    {
                        case "+":
                            {
                                Sum(int.Parse(expression[0]), int.Parse(expression[2]));
                                break;
                            }
                        case "-":
                            {
                                Sub(int.Parse(expression[0]), int.Parse(expression[2]));
                                break;
                            }
                        case "/":
                            {
                                Divide(int.Parse(expression[0]), int.Parse(expression[2]));
                                break;
                            }
                        case "*":
                            {
                                Multy(int.Parse(expression[0]), int.Parse(expression[2]));
                                break;
                            }
                        default:
                            {
                                Console.WriteLine("Неверный формат ввода");
                                continue;
                            }
                    }
                }
                catch (Exception)
                {

                    Console.WriteLine("Неверный формат ввода");
                }

            }
        }


    }
}
