/*using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace лаба_5
{
    abstract class Overall
    {
        public string Selling { get; set; }
        public string Vehicle { get; set; }
    }
    //Наследование позволяет определить дочерний класс, который использует (наследует), расширяет или изменяет возможности родительского класса.
    class Machine : Overall // Overall - базовый класс для данного класса
    {
        // реализация первого конструктора
        public Machine(string selling, string vehicle)
        {
            Selling = selling;
            Vehicle = vehicle;
        }

        // переопределение
        public override string ToString()
        {
            Console.WriteLine("Machine");
            return ("Selling: " + Selling + " \\ " + "Vehicle: " + Vehicle) ;
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
            Console.WriteLine("Person");
            return ("Selling: " + Selling + " \\ " +  "Vehicle: " + Vehicle);
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
            Console.WriteLine("Transformer");
            return ("Selling: " + Selling + " \\ " + "Vehicle: " + Vehicle);
        }
    }

    //Полиморфизм - изменению функций, унаследованных от базового класса 
    public class Printer
    {
        public string IAmPrinting(Object obj)
        {
            return obj.ToString();
        }
    }

    // реализация интерфейса
    interface ICommentable
    {
        void Comment();
    }
    abstract class Comments
    {
        public abstract void Comment();
    }

    //бесплодный класс - нельзя наследовать 
    sealed class Engine : Comments, ICommentable
    {
        public string Type { get; set; }
        public Engine(string type)
        {
            Type = type;
        }
        public override string ToString()
        {
            return ("Engine : " + Type);
        }
        public override void Comment()
        {
            Console.WriteLine("engine of human"); //переопределение абстрактного метода
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
            return ("Sentient: " + TrueOrFalse);
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
            Console.WriteLine("Conclusions: " + engine2.Type);
            engine2.Comment();

            Console.ReadLine();
        }
    }
}
*/

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
// Продукт, Кондитерское изделие, Товар, Цветы, Торт, Часы, Конфеты;  
namespace OOP_Lab5
{
    abstract class Name : IInterface, IInterface2
    {
        public string name;
        public abstract string Weight();
        public Name(string a)
        {
            name = a;
        }
    }
    interface IInterface
    {
        string Weight();
    }
    interface IInterface2
    {
        string Weight();
    }

    class Машина : Name, IInterface, IInterface2
    {

        string IInterface.Weight()
        {
            if (this.weight >= 1000)
                return "Тяжеловато";
            else return "Нормально";
        }
        string IInterface2.Weight()
        {
            if (this.weight >= 2000)
                return "Тяжеловато";
            else return "Нормально";
        }
        public int weight;
        public int count;
        public int cost;
        public string sentient;
        public string engine;
        public override string ToString()
        {
            return (this.GetType() + " " + "вес:" + weight + " Количество:" + count);
        }

        public override string Weight()
        {
            throw new NotImplementedException();
        }

        public Машина(string a, int b, int c) : base(a)
        {
            name = a;
            weight = b;
            count = c;
        }
        public Машина(string a) : base(a) { }
    }



    partial class Двигатель : Машина
    {
    
        public Двигатель(string a, int b, int c, int d, string e, int g) : base(a, b, c)
        {
            name = a;
            weight = b;
            count = c;
            countOfCylinder = d;
            torque = e;
            cost = g * c;
        }
    }

    partial class Двигатель : Машина
    {
        public int countOfCylinder;
        public string torque;
        public override string ToString()
        {
            return (this.GetType() + " Тип:" + name + " Вес:" + weight + " Количество:" + count + " Количество цилиндров:" + countOfCylinder + " Крутящий момент:" + torque);
        }
    }

    class Аккумулятор : Машина
    {
        public enum Types { tradicion = 1, hybrid };
        public int type;
        public override string ToString()
        {
            switch (this.type)
            {
                case 1: return (this.GetType() + " Производитель:" + name + " Вес:" + weight + " Количество:" + count + " Тип аккумулятора: гибридный ");
                case 2: return (this.GetType() + " Производитель:" + name + " Вес:" + weight + " Количество:" + count + " Тип аккумулятора: традиционный ");
                default: return (this.GetType() + " Производитель:" + name + " Вес:" + weight + " Количество:" + count + " Тип аккумулятора: none");

            }
        }
        public Аккумулятор(string a, int b, int c, Types d, int g) : base(a, b, c)
        {
            name = a;
            weight = b;
            count = c;
            type = (int)d;
            cost = g * c;
        }
    }

    class ТранспортноеСредство : Машина
    {
        public enum types { milk = 1, chocolate, meat };
        public string sentient;
        public string date;
        public override string ToString()
        {
            return (this.GetType() + " Название: " + name + " Является ли разумным существом: " + sentient + " Дата рождения(создания): " + date);
        }
        public ТранспортноеСредство(string a, string d, string e) : base(a)
        {
            name = a;
            sentient = d;
            date = e;
        }
    }

    class РазумноСущество : ТранспортноеСредство
    {
        public string date;
        public string sentient;
        public override string ToString()
        {
            return (this.GetType() + " Название: " + name + " Является ли разумным существом: " + sentient + " Дата рождения(создания): " + date);
        }
        public РазумноСущество(string a, string d, string e) : base(a, d, e)
        {
            name = a;
            sentient = d;
            date = e;
        }
    }


    class Человек : РазумноСущество
    {
        public override string ToString()
        {
            return (this.GetType() + " Название: " + name + " Является ли разумным существом: " + sentient + " Дата рождения: " + date);
        }
        public Человек(string a, string d, string e) : base(a, d, e)
        {
            name = a;
            sentient = d;
            date = e;
        }

    }

    class Трансформер : РазумноСущество
    {
        public override string ToString()
        {
            return (this.GetType() + " Название: " + name + " Является ли разумным существом: " + sentient + " Дата рождения(создания): " + date);
        }
       
        public Трансформер(string a, string d, string e) : base(a, d, e)
        {
            name = a;
            sentient = d;
            date = e;
        }
    }

     class Film : РазумноСущество
    {
        string name;
        string sentient;
        int year;

        public override string ToString()
        {

            return (name + ", ФЫвфыв: " + sentient +  "Дата " + date + " Год " + year );
        }

        public Film(string a, string d, string e, int f) : base(a, d, e)
        {
            name = a;
            sentient = d;
            date = e;
            Console.WriteLine("Введите год издания фильма: ");
            year = f;
            f = Convert.ToInt32(Console.ReadLine());

            string god = Console.ReadLine(); ;
        }
    }

    struct Портфель
    {
        readonly string name;
        readonly int cost;
        public Портфель(string Name, int Cost)
        {
            name = Name;
            cost = Cost;
        }
        public void Info()
        {
            Console.WriteLine("Портфель: " + name + "\nСтоимостью $" + cost);
        }
    }


    public class pereopr : Object
    {
        public override string ToString()
        {
            return "a";
        }

        public override int GetHashCode()
        {
            return 2;
        }

        public override bool Equals(object obj)
        {
            if (obj != null) return true;
            else return false;
        }
    }

    sealed class Printer
    {
        public string iAmPrinting(Name someobj)
        {
            Type a = someobj.GetType();
            return a.ToString();
        }

    }

    class Армия : List<object>
    {
        public Армия(params object[] list)
        {
            for (int i = 0; i < list.Length; i++)
            {
                this.Add(list[i]);
            }
        }
    }
    class PController : Армия
    {
        public PController(Армия pd)
        {
            for (int i = 0; i < pd.Count; i++)
            {
                this.Add(pd[i]);
            }
        }
        
        public int Cost()
        {
            int cost = 0;
            for (int i = 0; i < this.Count; i++)
            {
                if (this.ElementAt(i) is Машина)
                {
                    Машина ex = new Машина("");
                    ex = (Машина)this.ElementAt(i);
                    cost += ex.cost;
                }
            }
            return cost;
        }
        public void smass()
        {
            int mass = Int32.MaxValue;
            bool mass_test = false;
            string info = "";
            for (int i = 0; i < this.Count; i++)
            {
                if (this.ElementAt(i) is Машина)
                {
                    Машина ex = new Машина("");
                    ex = (Машина)this.ElementAt(i);
                    if (ex.weight < mass) { mass = ex.weight; mass_test = true; info = ex.ToString(); }
                }
            }
            if (mass_test) Console.WriteLine("Самая маленькая масса: " + info);
        }
        public void sort()
        {
            Машина ex = new Машина("");
            Машина ex1 = new Машина("");
            for (int i = 0; i < this.Count - 1; i++)
            {
                if (this.ElementAt(i) is Машина)
                {
                    ex = (Машина)this.ElementAt(i);
                    ex1 = (Машина)this.ElementAt(i + 1);
                    if (ex.weight < ex1.weight)
                    {
                        sorts();
                    }
                }
            }
            void sorts()
            {
                this.Remove(ex);
                this.Remove(ex1);
                this.Add(ex1);
                this.Add(ex);
                sort();
            }
        }

        public void print()
        {
            Console.WriteLine("--------------------------------------------------------------------------------");
            for (int i = 0; i < this.Count; i++)
            {
                if (this.ElementAt(i) is Машина)
                {
                    Машина ex = new Машина("");
                    ex = (Машина)this.ElementAt(i);
                    Console.WriteLine(ex.ToString());
                }
            }
            Console.WriteLine("--------------------------------------------------------------------------------");
        }
    }

    class except1 : Exception
    {
        public except1()
        {
        }
        public except1(string str) : base(str) { }
        public override string ToString()
        {
            return Message;
        }
    }

    class except2 : except1
    {
        public except2(string str) : base(str) { }
        public override string ToString()
        {
            return Message;
        }
    }

    public static class test
    {
        public static bool t;
        public static void assert()
        {
            Debug.Assert(t == false/*true*/, "Программа завершена без ошибок");
        }
    }
    class Program
    {
        static int dividenull(int x, int y)
        {
            if (y == 0)
            {
                Exception a = new Exception();
                a.HelpLink = "google.com";
                a.Data.Add("Время: ", DateTime.Now);
                throw a;
            };
            return x / y;//0000000000
        }
        static int My_Throw(int x, int y)
        {
            if (y == -11)
            {
                except1 a = new except1();
                a.HelpLink = "vk.com";
                a.Data.Add("Date: ", DateTime.Now);
                throw a;
            };
            return x + y;
        }
        static void Main(string[] args)
        {
            try
            {
                Машина mach = new Машина("Абвгд", 1900, 30);
                Console.WriteLine(((IInterface)mach).Weight());
                Console.WriteLine(((IInterface2)mach).Weight());
                Человек human1 = new Человек("Человек", "yes ", "01.01.2000");
                Человек human2 = new Человек("Человек", "yes ", "02.01.2000");
                Человек human3 = new Человек("Человек", "yes ", "03.01.2000");
                Трансформер trans1 = new Трансформер("Трансформер", "yes ", "11.10.2020");
                Трансформер trans2 = new Трансформер("Трансформер", "yes ", "12.10.2020");
                Трансформер trans3 = new Трансформер("Трансформер", "yes ", "13.10.2020");
                Аккумулятор accum1 = new Аккумулятор("AlphaLine", 5, 10, Аккумулятор.Types.hybrid, 100);
                Аккумулятор accum2 = new Аккумулятор("Bosch", 3, 10, Аккумулятор.Types.tradicion, 100);
                Двигатель engine = new Двигатель("Ford Flathead V8", 480, 33, 8, "296 Нм", 2);
                Console.WriteLine(human1.ToString());
                Console.WriteLine(human2.ToString());
                Console.WriteLine(human3.ToString());
                Console.WriteLine(trans1.ToString());
                Console.WriteLine(trans2.ToString());
                Console.WriteLine(trans3.ToString());
                Console.WriteLine(accum1.ToString());
                Console.WriteLine(accum2.ToString());
                Console.WriteLine(engine.ToString());



                Console.WriteLine("Film");
                Film obj1 = new Film("Na'Vi", "True Side", "123" , 1984);
                Film obj2 = new Film("Na'Vi", "True Side", "345", 1985);
                Film obj3 = new Film("Na'Vi", "True Side", "567", 1986);

                mas.Add(obj1);
                mas.Add(obj2);
                mas.Add(obj3);


                Console.WriteLine(trans1 is ТранспортноеСредство);
                Console.WriteLine(accum1 is int);
                Console.WriteLine(engine as Машина);
                Printer pr = new Printer();
                Console.WriteLine(pr.iAmPrinting(trans1));
                pereopr x = new pereopr();
                Console.WriteLine(x);
                Портфель myBag = new Портфель("Columbia", 35);
                myBag.Info();
                Армия p1 = new Армия(human1, human2, human3, trans1, trans2, trans3);
                PController pc1 = new PController(p1);
                Console.WriteLine("Общее количество в армии: $" + pc1.Cost());
                pc1.smass();
                pc1.sort();
                pc1.print();
                //dividenull(7, 0);//ERROR
                //My_Throw(7, -11);
                test.t = true;
                test.assert();

            }

            catch (except1 ex) when (ex.HelpLink == null) { Console.WriteLine("Не задана вспомогательная ссылка"); }
            catch (except1 ex) { Console.WriteLine(ex.HelpLink); }
            catch (Exception ex)
            {
                Console.WriteLine("------------------------------------------");
                Console.WriteLine(ex.Message + "\n");
                Console.WriteLine(ex.TargetSite + "\n");
                Console.WriteLine(ex.StackTrace + "\n");
                Console.WriteLine(ex.HelpLink + "\n");
                if (ex.Data != null)
                {
                    Console.WriteLine("Сведения: \n");
                    foreach (DictionaryEntry d in ex.Data)
                        Console.WriteLine(" {0} {1}", d.Key, d.Value);
                    Console.WriteLine("------------------------------------------");
                }
            }

            finally { if (!test.t) Console.WriteLine("Программа завершена с ошибкой"); }
        }
    }
}