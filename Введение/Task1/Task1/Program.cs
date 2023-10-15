namespace Task1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Написать программу-калькулятор, вычисляющую выражения вида a + b, a - b, a / b, a * b,
            //введенные из командной строки, и выводящую результат выполнения на экран.
            Console.WriteLine("Введите выражение вида a + b, a - b, a / b, a * b");
            Calc(Console.ReadLine());
            

        }

        public static void Calc(string expression) {
            string[] expressionElement = expression.Split(" ");
            double a = double.Parse(expressionElement[0]);
            double b = double.Parse(expressionElement[2]);

            switch (expressionElement[1]) { 
            case "+":
                    Console.WriteLine( a + b);
                    break;
            case "-":
                    Console.WriteLine(a - b);
                    break;
            case "/":
                    Console.WriteLine(a / b);
                    break;
            case "*":
                    Console.WriteLine(a * b);
                    break;
            }

        }
        }
    }
