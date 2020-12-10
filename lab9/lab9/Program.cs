using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    //делегаты
    public delegate void Salary(int sum);
    public delegate void Working();

    public class Director
    {
        private event Salary ActionWithSalary;
        private event Working ActionWithWork;
        public void Fine(int x) => ActionWithSalary?.Invoke(x); //событие штраф
        public void Boost() => ActionWithWork?.Invoke(); //событие повышение
        public Salary SalaryAction { get => ActionWithSalary; set => ActionWithSalary = value; }
        public Working WorkAction { get => ActionWithWork; set => ActionWithWork = value; }
    }


    // студенты - заочники
    public class PartTimeStudents
    {
        int count = 50;
        public void OnDirectorMessage() => Console.WriteLine("Один из студентов получил квалификацию токаря. Осталось студентов: " + (--count).ToString());
    }


    //токари
    public class Turners
    {
        private int count = 50;
        private int salary = 100;
        public void OnDirectorMessage(int x) => Console.WriteLine("С зарплаты будет вычтен штраф в размере " + x.ToString() + "$. Ожидаемая зарплата: " + (salary -= x).ToString() + "$");
        public void OnDirectorMessage() => Console.WriteLine("Один из токарей получил повышение. Осталось работников: " + (--count).ToString());
    }


    internal class Program
    {
        public static void DisplayMessage(int x)
        {
            Console.WriteLine(x.ToString());
        }

        public static StringBuilder RemoveS(StringBuilder str)//удаление знаков
        {
            char[] sign = { '.', ',', '!', '?', '-', ':' };
            for (int i = 0; i < str.Length; i++)
            {
                if (sign.Contains(str[i]))
                {
                    str = str.Remove(i, 1);
                }
            }
            return str;
        }
        public static StringBuilder RemoveSpase(StringBuilder str)//удаление пробелов
        {
            return str.Replace(" ", string.Empty);//возвр. изменённую строку
        }
        public static StringBuilder ToUpper(StringBuilder str)//удаление пробелов
        {
            for (int i = 0; i < str.Length; i++)
            {
                if (char.IsLetter(str[i]))
                {
                    str[i] = char.ToUpper(str[i]);
                }
            }
            return str;
        }
        public static StringBuilder ToLower(StringBuilder str)//удаление пробелов и добавление верхнего регистра
        {
            Console.WriteLine(str.Length);
            for (int i = str.Length - 1; i > str.Length / 2; i--)
            {
                if (char.IsLetter(str[i]))
                {
                    str[i] = char.ToLower(str[i]);
                }
            }
            return str;
        }
        //public static StringBuilder ToUpper(StringBuilder str)//удаление пробелов
        //{
        //    foreach (var s in str)
        //    {
        //    }
        //    return str.Replace(" ", string.Empty);//возвр. изменённую строку
        //}
        private static int Operation(int x, Func<int, int> retF)
        {
            return x < 0 ? 0 : retF(x);
        }

        private static void Main(string[] args)
        {
            Director director = new Director();
            Turners turners = new Turners();
            PartTimeStudents students = new PartTimeStudents();
            Salary salary = DisplayMessage;
            director.SalaryAction += turners.OnDirectorMessage;
            director.WorkAction += turners.OnDirectorMessage;
            director.WorkAction += students.OnDirectorMessage;
            director.Fine(20);
            director.Boost();
            director.Boost();
            director.Fine(20);

            StringBuilder Data = new StringBuilder("Это, предложение! с? пунктуацией.");
            Console.WriteLine(Data);

            Func<StringBuilder, StringBuilder> action;
            action = (str) => str = RemoveS(str);
            action += ((str) => str = RemoveSpase(str));
            action += ((str) => str = ToUpper(str));
            action += ((str) => str = ToLower(str));
            //action +=((str) => str )
            Data = action(Data);
            Console.WriteLine(Data);
            //action = (str) => Console.WriteLine("1"+RemoveS(str));
            //action += (str) => Console.WriteLine("2"+str.ToUpper());
            //action += (str) => Console.WriteLine("3"+str.ToLower());
            //action += (str) => Console.WriteLine("4"+RemoveSpase(str));
            Console.WriteLine(Operation(6, x => x * x));
            foreach (Delegate s in action.GetInvocationList())
            {
                Console.WriteLine();
            }

            Console.ReadKey();
        }
    }
}