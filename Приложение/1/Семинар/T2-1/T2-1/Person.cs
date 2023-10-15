
using System.Runtime.CompilerServices;
using T2_1;

namespace T2_1
{
    enum GenderEnum
    {
        Мужской,
        Женский
    }
    internal class Person
    {


        public string Name { get; }
        public GenderEnum Gender { get; }
        public Person? Mother { get; set; }
        public Person? Father { get; set; }
        public Person? Spouse { get; set; }

        private LinkedList<Person> Children = new();



        public LinkedList<Person> GetChildren()
        {
            LinkedList<Person> listChildren = new(Children);
            return listChildren;
        }

        public void SetChildren(Person children)
        {
            this.Children.AddLast(children);
            if (this.Gender == GenderEnum.Мужской)
            {
                children.Father = this;
            }
            else
            {
                children.Mother = this;
            }
        }


        //Родители неизвестны
        public Person(string name, GenderEnum gender)
        {
            this.Name = name;
            this.Gender = gender;

        }
        //Родители известны
        public Person(string name, GenderEnum gender, Person father, Person mother)
        {
            this.Name = name;
            this.Gender = gender;
            this.Father = father;
            this.Mother = mother;
            father.Children.AddLast(this);
            mother.Children.AddLast(this);

        }

        //Родители известны + супруг/супруга
        public Person(string name, GenderEnum gender, Person father, Person mother, Person spouse)
        {
            this.Name = name;
            this.Gender = gender;
            this.Father = father;
            this.Mother = mother;
            this.Spouse = spouse;
            father.Children.AddLast(this);
            mother.Children.AddLast(this);
        }

        public override string? ToString()
        {
            string result = $"{Name}";
            return result;
        }

        public static void GetTreeConsole(Person person, int depth = 0)
        {
            if (depth == 0)
            {
                if (person.Spouse !=null)
                {
                    Console.WriteLine($"({person.ToString()}:{person.Spouse.ToString()})");
                    depth++;
                }
                else
                {
                    Console.WriteLine($"{person.ToString()}");
                    depth++;
                }


            }
            if (person == null || person.Children.Count == 0)
            {
                Console.WriteLine(String.Concat(Enumerable.Repeat("-----", depth)));
            }
            else
            {
                foreach (var item in person.Children)
                {
                    if (item.Spouse != null)
                    {
                        Console.WriteLine($"{String.Concat(Enumerable.Repeat("----", depth))} ({item.ToString()}:{item.Spouse.ToString()})");
                        GetTreeConsole(item, depth + 1);
                    }
                    else
                    {
                        Console.WriteLine($"{String.Concat(Enumerable.Repeat("----", depth))} {item.ToString()}");
                        GetTreeConsole(item, depth + 1);
                    }
                }
            }
        }
    }
}
