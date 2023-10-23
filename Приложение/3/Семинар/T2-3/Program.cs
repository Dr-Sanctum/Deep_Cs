﻿/*Доработайте приложение поиска пути в лабиринте, но на этот раз вам нужно определить сколько всего выходов имеется в лабиринте:
 * int[,] labirynth1 = new int[,]
 * 
 * {
 * {1, 1, 1, 1, 1, 1, 1 },
 * {1, 0, 0, 0, 0, 0, 1 },
 * {1, 0, 1, 1, 1, 0, 1 },
 * {0, 0, 0, 0, 1, 0, 0 },
 * {1, 1, 0, 0, 1, 1, 1 },
 * {1, 1, 1, 0, 1, 1, 1 },
 * {1, 1, 1, 0, 1, 1, 1 }
 * };
 * 
 * Сигнатура метода:
 * 
 * static int HasExit(int startI, int startJ, int[,] l)
*/

using System.Reflection.Metadata;

namespace T2_3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[,] labirynth1 = new int[,]
            {
            {1, 1, 1, 1, 1, 1, 1 },
            {1, 0, 0, 0, 0, 0, 1 },
            {1, 0, 1, 1, 1, 0, 1 },
            {2, 0, 0, 0, 1, 0, 2 },
            {1, 1, 0, 0, 1, 1, 1 },
            {1, 1, 1, 0, 1, 1, 1 },
            {1, 1, 1, 2, 1, 1, 1 }
            };



            LabirintFindingAnExit.PrintLab(labirynth1);
            Console.WriteLine();



            Console.WriteLine($"Количество выходов найдено{LabirintFindingAnExit.HasExit(1, 2, labirynth1)}");

            LabirintFindingAnExit.PrintLab(labirynth1);
            Console.WriteLine();

        }





    }
}