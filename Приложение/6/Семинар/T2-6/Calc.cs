
namespace T2_6
{
    internal class Calc : ICalc
    {
        private double x, y;
        public double Result { get; set; }

        public event EventHandler<EventArgs>? CalcChange;

        public void PrintResult()
        {
            CalcChange?.Invoke(this, new EventArgs());
        }

        public double Divide(double x, double y)
        {
            Result = x / y;
            if (Result < 0)
            {
                throw new NotNegativeException("Результат не должен быть отрицательным");
            }
            PrintResult();
            return Result;
        }

        public double Multy(double x, double y)
        {
            Result = x * y;
            PrintResult();
            return Result;
        }

        public double Sub(double x, double y)
        {
            Result = x - y;
            if (Result < 0)
            {
                throw new NotNegativeException("Результат не должен быть отрицательным");
            }
            PrintResult();
            return Result;
        }

        public double Sum(double x, double y)
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
                    string expressionString = Console.ReadLine().Replace(".", ",");
                    expression = expressionString.Split(" ");
                    if (expression.Length == 1 && expression[0].Equals("0"))
                    {
                        break;
                    }
                    if (DoubleTryPars(expression[0], out x) && DoubleTryPars(expression[2], out y)) 
                    {
                        if (x < 0 || y < 0)
                        {
                            throw new Exception("Числа не должны быть отрицательными");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Неверный формат ввода");
                        continue;
                    }
                }
                catch (NullReferenceException)
                {
                    break;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    continue;
                }

                try
                {
                    switch (expression[1])
                    {
                        case "+":
                            {
                                Sum(x, y);
                                break;
                            }
                        case "-":
                            {
                                Sub(x, y);
                                break;
                            }
                        case "/":
                            {
                                Divide(x, y);
                                break;
                            }
                        case "*":
                            {
                                Multy(x, y);
                                break;
                            }
                        default:
                            {
                                Console.WriteLine("Неверный формат ввода");
                                continue;
                            }
                    }
                }
                catch (NotNegativeException e)
                {
                    Console.WriteLine(e.Message);
                }   


            }
        }

        public bool DoubleTryPars(string str, out double res)
        {
            try
            {
                res = double.Parse(str);
                return true;
            }
            catch (Exception)
            {
                res = default;
                return false;
            }

        }

        class NotNegativeException : Exception
        {
           public NotNegativeException(string messge): base(messge) { }
        }
    }
}
