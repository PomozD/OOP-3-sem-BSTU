using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oop_lab1_task1
{
    class Program
    {
        static void Main(string[] args)
        {
            // 1 задание а часть
            Console.WriteLine("Определение переменных и их инициализация:");
            Console.WriteLine();
            int o = 10;
            char c = 'c';
            double d = 1.1;
            long l = 15;
            float f = 3.5f;
            Console.WriteLine("int = " + o + "; " + "char = " + c + "; " + "double = " + d + "; " + "long = " + l + "; " + "float = " + f);
            Console.ReadLine();

            // 1 задание b часть
            Console.WriteLine("Явное и неявное приведение:");
            Console.WriteLine();
            decimal de = (decimal)d; // явно
            // decimal de = d; // неявно
            int t = 8;
            byte tir = (byte)(o + t); // явно
            // byte tir = (o + t); // неявно
            int first = 5;
            byte second = (byte)first; // явно
            // byte second = first; // неявно
            Single s = first;
            Int16 v = (Int16)s; // явно
            // Int16 v = s; // неявно
            Int32 n = (Int32)t; // явно
            // Int32 n = t; // неявно
            Console.WriteLine(de + "; " + tir + "; " + second + "; " + v + "; " + n);
            Console.ReadLine();

            // 1 задание c часть 
            Console.WriteLine("Упаковка и распаковка:");
            Console.WriteLine();
            int x = 15;
            Object ob = x; // Упаковка x
            byte m = (byte)(int)ob; // Распаковка, а затем приведение типа
            Console.WriteLine(x + "; " + m);
            Console.ReadLine();

            // 1 задание d часть
            Console.WriteLine("Работа с неявно типизированной переменной:");
            Console.WriteLine();
            var matrix1 = new[] { 6, 12, 23, 12, 4.4, 123.53, 76, 56 };
            Console.Write(matrix1.GetType());
            Console.WriteLine();
            Console.ReadLine();

            // 1 задание e часть
            Console.WriteLine("Работа с Nullable переменной:");
            Console.WriteLine();
            int? x1 = null;
            int? x2 = null;
            System.Console.Write(x1 == x2);
            Console.ReadLine();

            // 2 задание а,b часть
            Console.WriteLine("Объявление строковых литералов и создание трех строк на основе String. Выполнено: сцепление,копирование, выделение подстроки, разделение строки на слова, вставки подстроки в заданную позицию, удаление заданной подстроки:");
            Console.WriteLine();
            string s1 = "Hello";
            string s2 = "world";
            string s3 = "I'm Daniel";
            string s4 = s1 + " " + s2 + " " + s3;
            string s5 = String.Copy(s4);
            string s6 = s2.Substring(0, 5);
            string[] words = s4.Split(' ');
            // string[] stringSplit = s4.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            Console.Write("Сцепление строк: " + s4 + "; " + "Сравнение: ");
            Console.WriteLine(String.Compare(s1, s2) == 0 ? "true" : "false");
            Console.Write("Копирование строки: " + s5 + "; ");
            Console.Write("Выделение подстроки: " + s6 + "; ");
            for (int i = 0; i < words.Length; i++)
            {
                Console.WriteLine("Разделение строки: " + words[i] + "; ");
            }
            string stringIntsert = s1.Insert(5, s3);
            Console.WriteLine("Вставка подстроки в заданную позицию: " + stringIntsert);
            // индекс последнего символа
            int ind = s4.Length - 6;
            // вырезаем последний символ
            string stringRemove = s4.Remove(ind);
            Console.WriteLine("Удаление подстроки из строки: " + stringRemove);

            // 2 задание с часть
            Console.WriteLine("Создание пустой и null строки и работа с ними:");
            Console.WriteLine();
            string still = "";
            string nulled = null;
            Console.WriteLine(String.IsNullOrEmpty(still));

            // 2 задание d часть
            Console.WriteLine("Создание строки на основе StringBuilder, удаление определенных позиций и добавление новых символов в начало и конец строки:");
            Console.WriteLine();
            StringBuilder sb = new StringBuilder("Hello World", 50);
            Console.WriteLine(sb);
            Console.WriteLine("Remove: " + sb.Remove(6, 5));
            Console.WriteLine("Insert: " + sb.Insert(0, "aasd"));
            Console.WriteLine("Append: " + sb.Append("sdasd"));

            //3 задание a часть
            Console.WriteLine("Создание целого двумерного массива и вывод его на консоль в отформатированном виде(матрица):");
            Console.WriteLine();
            int[,] mas = { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 }, { 10, 11, 12 } };

            int rows = mas.GetUpperBound(0) + 1;
            int columns = mas.Length / rows;
            

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    Console.Write($"{mas[i, j]} \t");
                }
                Console.WriteLine();
            }
            Console.WriteLine();

            //3 задание b часть
            //Строковый одномерный массив
            Console.WriteLine("Создание одномерного массива строк. Вывод на консоль его содержимого, длину массива. Изменение произвольного элемента: ");
            Console.WriteLine();
            string[] ArrayString = { "Hello", "world", "I'm Daniel" };
            foreach (string i in ArrayString)
                Console.Write($"{i} ");
            Console.WriteLine();
            Console.WriteLine("Длина: " + ArrayString.Length);
            Console.WriteLine("Введите элемент, который нужно заменить от 0 до 2:");
            int num = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите текст на который нужно заменить:");
            string newString = Console.ReadLine();
            ArrayString[num] = ArrayString[num].Replace(ArrayString[num], newString);
            Console.WriteLine("Новый массив:");
            foreach (string i in ArrayString)
                Console.Write($"{i} ");
            Console.WriteLine();


            //3 задание с часть. Ступенчатый массивы
            Console.WriteLine("Создание ступечатого массива вещественных чисел с 3 - мя строками, в каждой из которых 2, 3 и 4 столбцов соответственно. Значения массива введен с консоли.");
            Console.WriteLine();
            int[][] myArr = new int[3][];
            myArr[0] = new int[2];
            myArr[1] = new int[3];
            myArr[2] = new int[4];
            for (int k = 0; k < myArr.Length; k++)
            {
                Console.Write("Введите {0} значений через пробел: ", myArr[k].Length);
                var inputArgs = Console.ReadLine().Split(' ');
                for (int j = 0; j < myArr[k].Length; j++)
                {
                    myArr[k][j] = (int)Convert.ToDouble(inputArgs[j]);
                }
            }
            Console.WriteLine();

            //3 задание d часть. Неявно типизированые массивы
            Console.WriteLine("Создание неявно типизированной переменной для хранения массива и строки");
            Console.WriteLine();
            var AArr = new[] { "A", "A", "A", "A" };
            var NumArr = new[] { 1, 2, 3, 4, 5 };

            Console.ReadLine();

            //4 задание. Кортежи
            Console.WriteLine("Задан кортеж из 5 элементов с типами int, string, char, string, ulong. ");
            Console.WriteLine();
            ValueTuple<int, string, char, string, ulong> corteg = (123, "Даниил", '%' , "Помоз", 112312);
            Console.WriteLine("Кортеж: " + corteg);
            Console.WriteLine(corteg.Item1);
            Console.WriteLine(corteg.Item3);
            Console.WriteLine(corteg.Item4);
            Console.WriteLine("Распаковка ");
            int Item1 = corteg.Item1;
            string Item2 = corteg.Item2;
            char Item3 = corteg.Item3;
            string Item4 = corteg.Item4;
            ulong Item5 = corteg.Item5;

            Console.WriteLine(Item1);
            Console.WriteLine(Item2);
            Console.WriteLine(Item3);
            Console.WriteLine(Item4);
            Console.WriteLine(Item5);

            Console.ReadLine();
            Console.Clear();
            //5) Локальная функция
            var localFun = FUNCTION();
            Console.WriteLine(localFun);
            Console.ReadKey();
            Console.ReadLine();
        }

        private static (int, int, int, char) FUNCTION()
        {
            int[] mass = new int[3] { 10, 25, 50 };
            Console.WriteLine("Массив:");
            for (int i = 0; i < mass.Length; i++)
            {
                Console.Write(mass[i] + " ");
            }
            string str1 = "Hello";
            int maximum = mass.Max();
            int minimum = mass.Min();
            int sum = mass.Sum();
            char firstLetter = str1[0];
            var end = (maximum, minimum, sum, firstLetter);
            Console.WriteLine();
            Console.WriteLine("Кортеж: " + " ");
            return end;
        }
        
    }
}
