namespace T2_1
{
    internal class Program
    {
        //Доработайте приложение генеалогического дерева таким образом чтобы программа выводила на экран близких
        //родственников(жену/мужа). Продумайте способ более красивого вывода с использованием горизонтальных и вертикальных черточек.
        static void Main(string[] args)
        {
            Person p1 = new Person("Василий", GenderEnum.Мужской);
            Person p2 = new Person("Мария", GenderEnum.Женский);
            p1.Spouse = p2;
            p2.Spouse = p1;
            Person p3 = new Person("Иван", GenderEnum.Мужской, p1, p2);
            Person p11 = new Person("Лилия", GenderEnum.Женский);
            p3.Spouse = p11;
            p11.Spouse = p3;
            Person p4 = new Person("Анна", GenderEnum.Женский, p1, p2);

            Person p10 = new Person("Вениамин", GenderEnum.Мужской);
            p4.Spouse = p10;
            p10.Spouse = p4;
            
            Person p5 = new Person("Сергей", GenderEnum.Мужской, p10, p4);

            Person p6 = new Person("Егор", GenderEnum.Мужской, p10, p4);
            Person p14 = new Person("Евгения", GenderEnum.Женский);
            p6.Spouse = p14;
            p14.Spouse = p6;
            Person p8 = new Person("Ксения", GenderEnum.Женский, p3, p11);
            Person p13 = new Person("Кирилл", GenderEnum.Мужской);
            p13.Spouse = p8;
            p8.Spouse = p13;

            Person p7 = new Person("Александра", GenderEnum.Женский, p3, p11);

            
            
            Person p9 = new Person("Виктор", GenderEnum.Мужской, p6, p14);
            Person p12 = new Person("Галина", GenderEnum.Женский, p13, p8);



            Person.GetTreeConsole(p1);

            

        }
    }
}