namespace T2_1
{
    internal class Program
    {

        static void Main(string[] args)
        {
           Person a = new Person();
            Person b = new Person();
            Person c = new Person();
            Person d = new Person();
            a.children.AddLast(b);
            a.children.AddLast(c);
            a.children.AddLast(d);
            foreach (var item in a.children)
            {
                Console.WriteLine(item);
            }
            

        }
    }
}