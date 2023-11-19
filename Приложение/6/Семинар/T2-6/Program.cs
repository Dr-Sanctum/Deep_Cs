/*
 * Доработайте класс калькулятора способным работать как с целочисленными так и с дробными числами. (возможно стоит задействовать перегрузку операций).
 * заменить Convert.ToDouble на собственный DoubleTryPars и обрабатываем ошибку
 * проверить что введенное число небыло отрицательное (вывести ошибку Exeption , отловить Catch)
 * сумма не может быть отрицательной (при делении и вычитании)
*/



namespace T2_6
{
    internal class Program
    {
        static void Main()
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