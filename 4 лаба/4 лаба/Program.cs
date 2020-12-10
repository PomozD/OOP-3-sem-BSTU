using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;

namespace lab4
{
    public class Set
    {

        //добавление данных в массив 
        public static int[] Add(int[] A, int temp)  //Перенос из массива
        {
            int[] B = new int[20];
            int i; int k = B.Length;
            for (i = 0; i < A.Length; i++)
            {
                B[i] = A[i];
            }
            B[A.Length] = temp;
            for (i = 0; i < A.Length + 1; i++)
            {
                Console.Write(B[i] + " ");
            }
            Console.WriteLine();
            return B;
        }

        public static void Pro(int[] x)
        {
            int[] y = new int[5]; int j = 0;
            int k = y.Length;
            for (int i = 0; i < x.Length; i++)
            {
                if (x[i] < 30 && x[i] > 0) { y[j] = x[i]; j++; }
                else { k = k - 1; }
            }
            for (int i = 0; i < k; i++)
            {
                Console.Write(y[i] + " ");
            }
            Console.WriteLine();
        }
        //разность со скалярным значением
        public static int Razn(int[] x)
        {
            Array.Sort(x);
            int result = x[0];

            for (int i = 1; i < x.Length; i++)
            {
                result = result - x[i];
            }
            return result;
        }

        //  проверка на неравенство массивов
        public static bool Proverka(int[] x1, int[] x2)
        {

            // Результирующее множество.
            bool nerav;


            Array.Sort(x1);
            Array.Sort(x2);
            if (x1 == x2)
            {
                nerav = true;
            }
            else
            {
                nerav = false;
            }

            return nerav;
        }

        // объединение массивов
        public static void Sub(int[] x1, int[] x2)

        {
            int j = 0;
            int[] s = new int[100];
            for (int i = 0; i < x1.Length; i++)
            {
                s[j] = x1[i]; j++;
            }
            for (int i = 0; i < x2.Length; i++)
            {
                s[j] = x2[i]; j++;
            }
            int k = s.Length;
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == 0) { k = k - 1; }
            }
            for (int i = 0; i < k; i++)
            {
                Console.Write(s[i] + " ");
            }

            //for (int i=0; i<s.Length; i++)
            //{
            //    Console.Write(s[i] + "  ");
            //}

        }
        public static void Inters(int[] x1, int[] x2)

        {
            int[] result = x1.Intersect(x2).ToArray();


        }

    }

    class Program
    {

        static void Main(string[] args)
        {
            Console.WriteLine();
            // Создаем множества.
            int[] mas1 = new int[] { 1, 2, 3, 4, 5 };

            int[] mas2 = new int[] { 5, 23, 13, 54, 15 };

            int[] mas3 = new int[] { 71, 12, 63, 14, 25, 4, 35, 10 };

            int[] mas4 = new int[] { 10, 12, 17, 19, 31 };

            // Выполняем операции со множествами.
            var union = Set.Razn(mas1);
            var intersection = Set.Proverka(mas2, mas4);


            // Выводим исходные множества на консоль.
            PrintSet(mas1, "Первое множество: ");
            PrintSet(mas2, "Второе множество: ");
            PrintSet(mas3, "Третье множество: ");
            PrintSet(mas4, "Четвертое множество: ");
            Console.WriteLine();
            Console.Write("obedinenie (2 i 3): "); Set.Sub(mas2, mas3);//
            Console.WriteLine();
            Console.WriteLine(" massivi s elementami >0 i <30 :");
            Set.Pro(mas1); Set.Pro(mas2); Set.Pro(mas3); Set.Pro(mas4);
            Console.WriteLine();
            Print(union, "Raz elementov 1 mas: ");
            Console.Write("Dobavili element v 1 massiv  "); Set.Add(mas1, 10);//
            Console.WriteLine();
            Console.WriteLine("Пересечение 1 и 2 множеств  "); int[] result = mas1.Intersect(mas2).ToArray();
            Console.WriteLine();
            if (intersection) //
            {
                Console.WriteLine("massivi odinakovie");
            }
            else
            {
                Console.WriteLine("massivi raznie");
            }


            Console.WriteLine();
            string testString = "im tired, let me out to hang out";//
            Console.WriteLine(testString);
            testString.Com();

            Console.WriteLine("Максимальный элемент 2 массива= " + MathOperation.GetMaxElement(mas2));
            Console.WriteLine("Минимальный элемент 2 массива= " + MathOperation.GetMinElement(mas2));
            Console.WriteLine("(Max-Min)= " + MathOperation.Raz(mas2));
            Console.WriteLine("Сумма элементов 1 массива= " + MathOperation.Sum(mas1));
            Console.Write("Множество mas3 без повторов: "); MathOperation.Del(mas3);
        }
        private static void Print(int a, string title)
        {

            Console.Write(title);

            Console.Write($"{a} ");


            Console.WriteLine();
        }
        private static void PrintSet(int[] a, string title)
        {

            Console.Write(title);
            foreach (var item in a)
            {
                Console.Write($"{item} ");
            }
            Console.Write($"  |||  Мощность множества: {a.Count()}");
            Console.WriteLine();
        }
    }
    static class MathOperation
    {
        public static string Com(this string str)  //метод расширения
        {
            str = str.Replace('e', ' ');
            str = str.Replace('y', ' ');
            str = str.Replace('u', ' ');
            str = str.Replace('i', ' ');
            str = str.Replace('o', ' ');
            str = str.Replace('a', ' ');
            Console.WriteLine(str);
            return str;
        }




        public static void Del(this int[] x) //метод расширения 
        {
            int[] y = new int[10]; int j = 0;
            for (int i = 5; i < x.Length; i++)
            {
                y[j] = x[i]; j++;
            }
            int k = y.Length;
            for (int i = 0; i < y.Length; i++)
            {
                if (y[i] == 0) { k = k - 1; }
            }
            for (int i = 0; i < k; i++)
            {
                Console.Write(y[i] + " ");
            }
        }



        public static int GetMaxElement(int[] x)
        {
            return x.Max();
        }

        public static int GetMinElement(int[] x)
        {
            return x.Min();
        }

        public static int Sum(int[] x)
        {
            int Sum = 0;
            for (int i = 0; i < x.Length; i++)
            {
                Sum = Sum + x[i];
            }
            return Sum;
        }

        public static int Raz(int[] x)
        {
            int Raz, max, min;
            min = x.Min();
            max = x.Max();
            Raz = max - min;
            return Raz;
        }
    }
}

