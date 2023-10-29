
/*
 * Дан массив и число. Найдите три числа в массиве сумма которых равна искомому числу. 
 * Подсказка: если взять первое число в массиве, можно ли найти в оставшейся его части два числа равных по сумме первому.
*/
namespace T2_4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 44, 35, 36, 20 };

            int target = 100;

            var hs = new HashSet<int>();

            foreach (var item in numbers)
            {
                var x = target - item;

                foreach (var item1 in numbers)
                {
                    var y = x - item1;
                    if (hs.Contains(y) && y != item && y != item1)
                    {
                        Console.WriteLine($"{y} + {item} + {item1}");
                    }
                    else
                    {
                        hs.Add(item1);
                    }
                }
            }
        }
    }
}