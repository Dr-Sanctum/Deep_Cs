namespace T2_2
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Bits a = new Bits(534313216L);


            for (int i =64; i >= 0; i--)
            {
                Console.Write(Convert.ToSByte(a[i]));
            }
            Console.WriteLine();
            a = 12341;


            for (int i = 32; i >= 0; i--)
            {
                Console.Write(Convert.ToSByte(a[i]));
            }

            Console.WriteLine();
            a = 123413457347L;


            for (int i = 64; i >= 0; i--)
            {
                Console.Write(Convert.ToSByte(a[i]));
            }

        }

    }
}