/*using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace лаба_5
{
 public class Library
        {
            public int n = 5;
            public int time;
            public string name;
            public string[] Books = new string[5] { "NIFEDOV", "TURGENEV", "ABC", "MATHEMATICS", "BROTHERS GRIMM" };
            public int[] Date = new int[5] { 1954, 1899, 1945, 1966, 1987 };

            public string llibraryadd
            {
                get { return Books[n]; }
                set
                {
                    Console.WriteLine("Введите название книги: ");
                    n++;
                    name = Console.ReadLine();
                    Books[n] = name;
                }
            }

            public int datenadd
            {
                get { return Date[n]; }
                set
                {
                    Console.WriteLine("Введите дату издания книги: ");
                    n++;
                    time = Convert.ToInt32(Console.ReadLine());
                    Date[n] = time;
                }
            }

            public string llibraryremove
            {
                get { return Books[n]; }
                set
                {
                    Console.WriteLine("Введите название книги, которую нужно удалить: ");
                    n--;
                    name = Console.ReadLine();
                    for (int i = 0; i < Books[n].Length; i++)
                    {
                        if (Books[i] == name)
                        {
                            Books[i] = "";
                        }
                    }
                }
            }

            public int datenremove
            {
                get { return Date[n]; }
                set
                {
                    Console.WriteLine("Введите дату книги, которую нужно удалить: ");
                    n--;
                    time = Convert.ToInt32(Console.ReadLine());
                    for (int i = 0; i < n; i++)
                    {
                        if (Date[i] == time)
                        {
                            Date[i] = 0;
                        }
                    }
                }
            }

        }

        public class Controller : Library
        {
            public int l;
            public int timeng;
            public int[] Array;
            public string Sorting()
            {
                Console.WriteLine("Введите год для сортировки: ");
                timeng = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Наименование всех книг в библиотеке, вышедших не ранее указанного года: ");

                for (int i = 0; i < Date[n]; i++)
                {
                    if (Date[i] >= timeng)
                    {
                        Array[l] = i;
                        l++;
                    }
                }
                l = 0;
                for (int i = 0; i < Books[5].Length; i++)
                {
                    if (Array[l] == i)
                    {
                        Console.WriteLine(Books[i] + " ");
                        l++;
                    }
                }
                return Books[n];
            }
        }

        struct Bookss
        {
            public string ABC;
            public string Murshilka;
            public string Tolstoy;
            public string Dictionary;
            enum Books { first = 1902, second = 1924, third = 1954, fourth = 1978 };
        }
    abstract class Overall
    {
        public string Selling { get; set; }
        public string Vehicle { get; set; }
        public int Year { get; set; }
    }
    //Наследование - это механизм получения нового класса на основе уже существуюущего
    class Machine : Overall // После двоеточия мы указываем базовый класс для данного класса
    {
        // реализация первого конструктора
        public Machine(string selling, string vehicle)
        {
            Selling = selling;
            Vehicle = vehicle;
        }
        public override string ToString() // переопределение виртуального метода в производном классе
        {
            Console.WriteLine("Автомобиль");
            return ("Можно ли купить?: " + Selling + " \\ " + "Транспортное средство?: " + Vehicle);
        }
    }

    class Person : Overall
    {
        // реализация второго конструктора
        public Person(string selling, string vehicle)
        {
            Selling = selling;
            Vehicle = vehicle;
        }
        public override string ToString()
        {
            Console.WriteLine("Человек");
            return ("Можно ли купить?: " + Selling + " \\ " + "Транспортное средство?: " + Vehicle);
        }
    }

    class Transformer : Overall
    {
        // реализация третьего конструктора
        public Transformer(string selling, string vehicle)
        {
            Selling = selling;
            Vehicle = vehicle;
        }
        public override string ToString()
        {
            Console.WriteLine("Трансформер");
            return ("Можно ли купить?: " + Selling + " \\ " + "Транспортное средство?: " + Vehicle);
        }
    }

    //Полиморфизм - способность к изменению функций, унаследованных от базового класса
    public class Printer
    {
        public string IAmPrinting(Object obj)
        {
            return obj.ToString();
        }
    }
    interface ICommentable // реализация интерфейса
    {
        void Comment();
    }
    abstract class Comments
    {
        public abstract void Comment();
    }
    sealed class Engine : Comments, ICommentable //бесплодный класс - от него нельзя наследовать
    {
        public string Type { get; set; }
        public Engine(string type)
        {
            Type = type;
        }
        public override string ToString()
        {
            return ("Двигатель : " + Type);
        }
        public override void Comment()
        {
            Console.WriteLine("двигатель человека"); //переопределяем абстрактный метод
        }
    }
    class Sentient : Overall
    {
        public string TrueOrFalse { get; set; }
        public Sentient(string trueorfalse)
        {
            TrueOrFalse = trueorfalse;
        }
        public override string ToString()
        {
            return ("Разумное существо: " + TrueOrFalse);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Machine machine = new Machine("True", "True");
            Engine engine1 = new Engine("V8");
            Sentient sentient1 = new Sentient("false");
            Person person = new Person("false", "false");
            Engine engine2 = new Engine("heart");
            Sentient sentient2 = new Sentient("true");
            Transformer transformer = new Transformer("True", "True");
            Engine engine3 = new Engine("Kollmorgen");
            Sentient sentient3 = new Sentient("false");
            Printer Printer = new Printer();
            Object[] mass = new object[] { machine, engine1, sentient1, person, engine2, sentient2, transformer, engine3, sentient3 };
            for (int i = 0; i < mass.Length; i++)
            {
                Console.WriteLine(Printer.IAmPrinting(mass[i]));
                Console.WriteLine();
            }
            Console.WriteLine("Вывод: " + engine2.Type);
            engine2.Comment();

            Console.ReadLine();

             Library library = new Library();

            Console.WriteLine("Список книг: ");
            for (int i = 0; i < library.Books.Length; i++)
            {
                Console.Write(library.Books[i] + " ");
            }
            Console.WriteLine();
            Console.WriteLine("Список даты: ");
            for (int j = 0; j < library.Date.Length; j++)
            {
                Console.Write(library.Date[j] + " ");
            }
            Console.WriteLine();

            int k = 0;
            for (int i = 0; i < 5; i++)
            {
                k++;
            }

            Console.WriteLine("Количество книг: " + k);

            Console.ReadKey();
        }
    }
}
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp5
{
    public class Library
    {
        public int n = 5;
        public int time;
        public string name;
        public string[] Books = new string[5] { "NIFEDOV", "TURGENEV", "ABC", "MATHEMATICS", "BROTHERS GRIMM" };
        public int[] Date = new int[5] { 1954, 1899, 1945, 1966, 1987 };

        public string libraryadd()
        {
            
            
                Console.WriteLine("Введите название книги: ");
                n++;
                name = Console.ReadLine();
                Books[n] = name;
            return name;
            
        }

        public int datenadd
        {
            get { return Date[n]; }
            set
            {
                Console.WriteLine("Введите дату издания книги: ");
                n++;
                time = Convert.ToInt32(Console.ReadLine());
                Date[n] = time;
            }
        }

        public string libraryremove
        {
            get { return Books[n]; }
            set
            {
                Console.WriteLine("Введите название книги, которую нужно удалить: ");
                n--;
                name = Console.ReadLine();
                for (int i = 0; i < Books[n].Length; i++)
                {
                    if (Books[i] == name)
                    {
                        Books[i] = "";
                    }
                }
            }
        }

        public int datenremove
        {
            get { return Date[n]; }
            set
            {
                Console.WriteLine("Введите дату книги, которую нужно удалить: ");
                n--;
                time = Convert.ToInt32(Console.ReadLine());
                for (int i = 0; i < n; i++)
                {
                    if (Date[i] == time)
                    {
                        Date[i] = 0;
                    }
                }
            }
        }



        public class Controller : Library
        {
            public int l;
            public int timeng;
            public int[] Array;
            public string Sorting()
            {
                Console.WriteLine("Введите год для сортировки: ");
                timeng = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Наименование всех книг в библиотеке, вышедших не ранее указанного года: ");

                for (int i = 0; i < Date[n]; i++)
                {
                    if (Date[i] >= timeng)
                    {
                        Array[l] = i;
                        l++;
                    }
                }
                l = 0;
                for (int i = 0; i < Books[5].Length; i++)
                {
                    if (Array[l] == i)
                    {
                        Console.WriteLine(Books[i] + " ");
                        l++;
                    }
                }
                return Books[n];
            }
        }

        struct Bookss
        {
            public string ABC;
            public string Murshilka;
            public string Tolstoy;
            public string Dictionary;
            enum Books { first = 1902, second = 1924, third = 1954, fourth = 1978 };
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
                
          
            Library library = new Library();
         

            Console.WriteLine("Список книг: ");
            for (int i = 0; i < library.Books.Length; i++)
            {
                Console.Write(library.Books[i] + " ");
            }
            Console.WriteLine();
            Console.WriteLine("Список даты: ");
            for (int j = 0; j < library.Date.Length; j++)
            {
                Console.Write(library.Date[j] + " ");
            }
            Console.WriteLine();

            int k = 0;
            for (int i = 0; i < 5; i++)
            {
                k++;
            }

            Console.WriteLine("Количество книг: " + k);
            

            Console.ReadKey();

        }
    }
}