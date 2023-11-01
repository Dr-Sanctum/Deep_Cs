namespace T2_5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var calc = new Calc();
            calc.CalcChange += CalcChangeEvent;


            calc.Run();

        }

        private static void CalcChangeEvent(object? sender, EventArgs e)
        {
            if (sender is Calc)
            {
                Console.WriteLine(((Calc)sender).Result);
            }

        }
    }
}