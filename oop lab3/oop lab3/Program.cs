using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*Создать класс Student: id, Фамилия, Имя, Отчество,
Дата рождения, Адрес, Телефон, Факультет, Курс,
Группа. Свойства и конструкторы должны обеспечивать
проверку корректности.*/

namespace lab3
{
    public partial class Student
    {
        public string surname, name, middlename, date, address, phonenumber, faculty, group;
        public int course, id;
        private const string university = "BGTU";



    }
    public partial class Student
    {
        public Student()
        {
            id = GetHashCode();
            name = "Даниил";
            surname = "Помоз";
            middlename = "Сергеевич";
            date = "01.01.2002";
            address = "Белорусская";
            phonenumber = "80291234567";
            faculty = "ФИТ";
            course = 2;
            group = "13";

        }

        public Student(string a, string b, string c, string d, string e, string f, string g, int h, string k)
        {
            Console.WriteLine();
            name = a;
            surname = b;
            middlename = c;
            date = d;
            address = e;
            phonenumber = f;
            faculty = g;
            course = h;
            group = k;
            id = GetHashCode();

        }


        public void Info()
        {
            Console.WriteLine($"id   {id}");
            Console.WriteLine($"Имя   {name}");
            Console.WriteLine($"Фамилия   {surname}");
            Console.WriteLine($"Отчество       {middlename}");
            Console.WriteLine($"Дата рождения       {date}");
            Console.WriteLine($"Адрес       {address}");
            Console.WriteLine($"Номер телефона     {phonenumber}");
            Console.WriteLine($"Факультет   {faculty}");
            Console.WriteLine($"Курс   {course}");
            Console.WriteLine($"Группа   {group}");
            Console.WriteLine($"Университет   {university}");
        }

    }



    class Cmin
    {
        public static int min(int x, int y)
        {
            int z = (x < y) ? x : y;
            return z;
        }
        public static int minabs(ref int x, ref int y)
        {
            x = (x < 0) ? -x : x; y = (y < 0) ? -y : y;
            int z = (x < y) ? x : y;
            return z;
        }
        public static void Sum(ref int x, ref int y, out int a)
        {
            a = x + y;
        }

    }


    class Program
    {
        static void Main(string[] args)
        {
            Student student1 = new Student();
            Console.WriteLine();
            student1.Info();

            Student[] arr = new Student[6];
            arr[0] = new Student("Петр", "Петров", "Петрович", "03.03.2002", "Минская", "80299876543", "ФИТ", 2, "10");
            arr[1] = new Student("Василий", "Васильев", "Васильевич", "04.04.2002", "Московская", "80299876342", "ИЭФ", 2, "10");
            arr[2] = new Student("Андрей", "Андреев", "Андреевич", "01.03.2002", "Фрунзенская", "80299656543", "ФИТ", 2, "5");
            arr[3] = new Student("Леонид", "Леонидов", "Леонидович", "21.04.2002", "Ленинская", "80299456543", "ХТиТ", 2, "6");
            arr[4] = new Student("Антон", "Антонов", "Антонович", "15.09.2002", "Могилевская", "80299812342", "ФИТ", 2, "2");
            arr[5] = new Student("Генадий", "Генадьев", "Генадьевич", "06.02.2002", "Первомайская", "80292376543", "ФИТ", 2, "4");

            Student student2 = new Student();
            student2.name = "Иван";
            student2.surname = "Иванов";
            student2.middlename = "Иванович";
            student2.date = "02.02.2002";
            student2.address = "Гомельская";
            student2.phonenumber = "80293818395";
            student2.faculty = "ЛиП";
            student2.course = 4;
            student2.group = "8";
            student2.Info();
            Console.WriteLine();

            Console.WriteLine("student1==student2?  " + student1.Equals(student2));
            Console.WriteLine("Student1 " + student1.GetType());
            Console.WriteLine(student1.GetHashCode());
            Console.WriteLine(student1.ToString() + "\n");


            int a = -4;
            int b = 2;
            int z;
            Console.WriteLine("a={0}  b={1}", a, b);
            int k = Cmin.min(a, b);
            Console.WriteLine("k=" + k);
            k = Cmin.minabs(ref a, ref b);
            Console.WriteLine("a={0}  b={1}", a, b);
            Console.WriteLine("k=" + k);
            Cmin.Sum(ref a, ref b, out z);
            Console.WriteLine("a+b={0}", z);
            Console.WriteLine();

            Console.Write("Введите номер группы: ");
            string gruppa = Console.ReadLine();


            Console.WriteLine(" ");
            Console.WriteLine($"группа {gruppa}:   ");
            Console.WriteLine("");
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i].group == gruppa)
                {
                    arr[i].Info();
                    Console.WriteLine(" ");
                }

            }

            Console.Write("Введите Факультет: ");
            string fac = Console.ReadLine();


            Console.WriteLine(" ");
            Console.WriteLine($"факультет {fac}:   ");
            Console.WriteLine(" ");
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i].faculty == fac)
                {
                    arr[i].Info();
                }

            }
            Console.ReadLine();
        }
    }
}