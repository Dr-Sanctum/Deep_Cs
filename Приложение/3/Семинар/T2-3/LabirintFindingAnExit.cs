using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T2_3
{
    internal static class LabirintFindingAnExit
    {
        static Stack<(int, int)> stack = new Stack<(int, int)>();
        static int quantity = 0;

        public static int HasExit(int startX, int startY, int[,] l)
        {

            (int, int)[] tempStep = new (int, int)[4];

            tempStep[0] = (startX, startY + 1);

            tempStep[1] = (startX + 1, startY);

            tempStep[2] = (startX, startY - 1);

            tempStep[3] = (startX - 1, startY);


            foreach (var Step in tempStep)
            {
                if (l[Step.Item1, Step.Item2] == 0)
                {
                    stack.Push(Step);

                }
                if (l[Step.Item1, Step.Item2] == 2)
                {
                    quantity++;
                }
            }

            l[startX, startY] = 3;
            if (stack.Count == 0)
            {
                return quantity;
            }
            HasExit(stack.Peek().Item1, stack.Pop().Item2, l);
            return quantity;
        }



        public static void PrintLab(int[,] lab)
        {
            for (int i = 0; i < lab.GetLength(0); i++)
            {
                Console.WriteLine();
                for (int j = 0; j < lab.GetLength(1); j++)
                {
                    Console.Write($"{lab[i, j]} ");
                }
            }
        }
    }
}
