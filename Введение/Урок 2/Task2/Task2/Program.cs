/*Дан двумерный массив.
732
496
185

Отсортировать данные в нем по возрастанию.

123
456
789

Вывести результат на печать.
class Program
{
static void Main(string[] args)
{
int[,] a = { { 7, 3, 2 }, { 4, 9, 6 }, { 1, 8, 5 } };
}
}*/

using System.Collections;

namespace Task2
{
  
    internal class Program
    {
        static void Main(string[] args)
        {
            int[,] arrayInt = { { 7, 3, 2 }, { 4, 9, 6 }, { 1, 8, 5 }};

            for (int i = 0; i < arrayInt.GetLength(0); i++)
            {
                Console.WriteLine();
                for (int j = 0; j < arrayInt.GetLength(1); j++)
                {
                    Console.Write(arrayInt[i, j]);
                }
            }
            Console.WriteLine();
           Array2dSort(arrayInt);

            for (int i = 0; i < arrayInt.GetLength(0); i++)
            {
                Console.WriteLine();
                for (int j = 0; j < arrayInt.GetLength(1); j++)
                {
                    Console.Write(arrayInt[i, j]);
                }
            }
        }

        public static void Array2dSort(int[,] array)
        {
            int[] temp = new int[array.Length];
            int counter = 0;
                for (int i = 0; i < array.GetLength(0); i++)
                {
                    for (int j = 0; j < array.GetLength(1); j++)
                    {
                    temp[counter] = array[i, j];
                    counter++;
                    }
                }
                Array.Sort(temp);

            counter = 0;
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    array[i, j] = temp[counter];
                    counter++;
                }
            }
        }
    }
}