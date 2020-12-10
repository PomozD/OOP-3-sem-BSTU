using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab11
{
    class Player
    {
        public string Name { get; set; }
        public string Team { get; set; }
    }
    class Team
    {
        public string Name { get; set; }
        public string Country { get; set; }
    }


    interface ICollectionType<T> where T : struct
    {
        void Add(T element);
        void Delete(T element);
        void Show();
    }
    public class Set<T> : IComparable, ICollectionType<T> where T : struct
    {
        public readonly Owner owner = new Owner(3, "Daniil", "BSTU");
        public readonly Date creationDate = new Date();
        public class Owner
        {
            public readonly int id;
            public readonly string name;
            public readonly string organisation;

            public Owner(int id, string name, string organisation)
            {
                this.id = id;
                this.name = name;
                this.organisation = organisation;
            }
            public void Getinfo()
            {
                Console.WriteLine($"ID: {id} Name: {name} Organization: {organisation}");
            }
        }
        public class Date
        {
            DateTime dateTime = DateTime.Now;

            public override String ToString()
            {
                return dateTime.ToShortDateString();
            }
        }
        private List<T> _items = new List<T>();

        public int Count => _items.Count;

        public void Add(T item) //добавление во множество
        {
            if (!_items.Contains(item))
            {
                _items.Add(item);
            }
        }


        public void Delete(T item)
        {
            _items.Remove(item);
        }

        public int Sum() //сумма множества
        {
            int sum = 0;
            if (_items is List<int>)
            {
                List<int> item = _items as List<int>;
                foreach (int temp in item)
                {
                    sum += temp;
                };
                return sum;
            }
            else
            {
                Console.WriteLine("Error");
                return -1;
            }
        }
        public bool IsHaveNeg() //содержание отрицательного значения
        {
            List<int> item = _items as List<int>;
            foreach (int s in item)
            {
                if (s < 0)
                    return true;
            }
            return false;
        }
        public bool IsContain(int n) //поиск множества по введенному значению
        {
            List<int> item = _items as List<int>;
            return item.Contains(n);
        }
        public static Set<T> Union(Set<T> set1, Set<T> set2)
        {
            var resultSet = new Set<T>();

            var items = new List<T>();
            if (set1._items != null && set1._items.Count > 0)
            {
                items.AddRange(new List<T>(set1._items));
            }
            if (set2._items != null && set2._items.Count > 0)
            {
                items.AddRange(new List<T>(set2._items));
            }
            resultSet._items = items.Distinct().ToList();
            return resultSet;
        }

        public static Set<T> Intersection(Set<T> set1, Set<T> set2) //пересечение и
        {
            var resultSet = new Set<T>();

            if (set1.Count < set2.Count)
            {
                foreach (var item in set1._items)
                {
                    if (set2._items.Contains(item))
                    {
                        resultSet.Add(item);
                    }
                }
            }
            else
            {
                foreach (var item in set2._items)
                {
                    if (set1._items.Contains(item))
                    {
                        resultSet.Add(item);
                    }
                }
            }
            return resultSet;
        }

        public static Set<T> Difference(Set<T> set1, Set<T> set2) //разность А\В
        {
            var resultSet = new Set<T>();

            foreach (var item in set1._items)
            {
                if (!set2._items.Contains(item))
                {
                    resultSet.Add(item);
                }
            }

            foreach (var item in set2._items)
            {
                if (!set1._items.Contains(item))
                {
                    resultSet.Add(item);
                }
            }
            resultSet._items = resultSet._items.Distinct().ToList();
            return resultSet;
        }


        public static bool Subset(Set<T> set1, Set<T> set2)
        {
            bool result = set1._items.All(s => set2._items.Contains(s));
            return result;
        }
        public IEnumerator<T> GetEnumerator()
        {
            return _items.GetEnumerator();
        }

        public void Show()
        {
            foreach (T str in this)
            {
                Console.Write(str + " ");
            }
            Console.WriteLine();
        }

        public int CompareTo(object obj) //сравнение
        {
            Set<int> set = obj as Set<int>;
            if (this.Count > set.Count)
                return 1;
            else if (this.Count == set.Count)
                return -1;
            else return 0;
        }
        public int GetFirst() //сортировка
        {
            List<int> item = _items as List<int>;
            return item.First();
        }
        public static Set<T> operator +(Set<T> list, T item)
        {
            list.Add(item);
            return list;
        }
        public static Set<T> operator +(Set<T> list1, Set<T> list2)
        {
            var resultSum = new Set<T>();
            resultSum = Set<T>.Union(list1, list2);
            return resultSum;
        }
        public static Set<T> operator *(Set<T> list1, Set<T> list2)
        {
            var resultSum = new Set<T>();
            resultSum = Set<T>.Intersection(list1, list2);
            return resultSum;
        }
        public static explicit operator int(Set<T> list1)
        {
            return list1.Count;
        }
        // Перегружаем оператор false
        public static bool operator false(Set<T> obj)
        {
            if (obj.Count < 6 && obj.Count > 1)
                return true;
            return false;
        }

        // Обязательно перегружаем оператор true
        public static bool operator true(Set<T> obj)
        {
            if (obj.Count > 6 || obj.Count < 1)
                return true;
            return false;
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            #region First
            string[] month = { "January", "February", "March", "April", "May", "June", "July", "August", "September", "November", "December" };
            string[] WinSumMounth = { "January", "February", "December", "June", "July", "August" };
            Console.WriteLine($" Введите n:");
            int n = int.Parse(Console.ReadLine());
            var strLength = from t in month // определяем каждый объект из month как t
                            where t.Length == n //фильтрация по критерию
                            select t; // выбираем объект
            //var strLength = month.Where(t => t.Length == n);
            Console.WriteLine($"Строки с длиной строки n = {n}");
            foreach (string s in strLength)
                Console.WriteLine(s);
            var strWinSum = from t in month
                            where WinSumMounth.Contains(t)
                            select t;
            //var strWinSum = month.Where(t => WinSumMounth.Contains(t));
            Console.WriteLine($"Зимнии и летнии месяца:");
            foreach (string s in strWinSum)
                Console.WriteLine(s);
            var strOrderBy = from t in month
                             orderby t
                             select t;
            //var strOrderBy = month.OrderBy(t => t);
            Console.WriteLine($"Вывод в алфавитном порядке:");
            foreach (string s in strOrderBy)
                Console.WriteLine(s);
            int strCount = (from t in month
                            where t.Contains("u") && t.Length > 4
                            select t).Count();
            //int strCount = month.Where(t => t.Contains("u") && t.Length > 4).Count();
            Console.WriteLine($"Количество месяцев содержащих u и длиной строки > 4 :");
            Console.WriteLine(strCount);
            #endregion
            #region Second + Third
            Console.WriteLine($"________________________________________________________");
            Console.WriteLine($"Задание 2-3: ");
            List<Set<int>> tables = new List<Set<int>>();
            Set<int> a1 = new Set<int>();
            a1.Add(-1); a1.Add(2); a1.Add(3); a1.Add(4); a1.Add(5); a1.Add(6); a1.Add(7); a1.Add(8);
            Set<int> a2 = new Set<int>();
            a2.Add(10); a2.Add(20); a2.Add(30); a2.Add(40); a2.Add(50); a2.Add(60); a2.Add(8);
            Set<int> a3 = new Set<int>();
            a3.Add(100); a3.Add(200); a3.Add(300); a3.Add(400); a3.Add(500); a3.Add(600);
            tables.Add(a1); tables.Add(a2); tables.Add(a3);
            foreach (var s in tables)
                foreach (var t in s)
                    Console.WriteLine(t);
            var task1sum = from t in tables
                           select t.Sum();
            int max = task1sum.Max();
            var set1 = from t in tables
                       where t.Sum() == max
                       select t;
            Console.WriteLine($" Множества c наибольшей суммой элементов: {max} \n:");
            foreach (var s in set1)
                foreach (var t in s)
                {
                    Console.WriteLine(t);
                }
            var set2 = from set in tables
                       where set.IsHaveNeg()
                       select set;
            //var set2 = tables.Where(set => set.IsHaveNeg());
            Console.WriteLine($" Множества содержащие отрицательные элементы:");
            foreach (var s in set2)
                foreach (var t in s)
                {
                    Console.WriteLine(t);
                }
            Console.WriteLine($"Введите элемент:");
            int m = int.Parse(Console.ReadLine());
            var set3 = from set in tables
                       where set.IsContain(m)
                       select set;
            Console.WriteLine($" Множества содержащие введеное число m: {m}");
            foreach (var s in set3)
                foreach (var t in s)
                {
                    Console.WriteLine(t);
                }
            var set4 = tables.Max();
            Console.WriteLine($"Макимальное множество: ");
            foreach (var s in set4)
                Console.WriteLine(s);
            var set5 = tables.First(set => set.IsContain(m));
            Console.WriteLine($" Первое множества содержащие введеное число m: {m}");
            foreach (var s in set5)
                Console.WriteLine(s);
            var set6 = from set in tables
                       orderby set.GetFirst()
                       select set;
            Console.WriteLine($"Отсортированный массив множеств:");
            foreach (var s in set6)
                foreach (var t in s)
                    Console.WriteLine(t);
            //#endregion
            #region Fourth

            List<Player> players = new List<Player>() {   new Player {Name="Месси", Team="Барселона"},
                                                         new Player {Name="Гризманн", Team="Барселона"},
                                                           new Player {Name="Левандовский", Team="Бавария"}
                                                                                                };
            var temp1 = from player in players
                        where player.Team == "Барселона"
                        orderby player.Name
                        group player by player.Team;

            foreach (IGrouping<string, Player> g in temp1)
            {
                Console.WriteLine(g.Key);
                foreach (var t in g)
                    Console.WriteLine(t.Name);
                Console.WriteLine();
            }

            #endregion
            #region Fifth
            List<Team> teams = new List<Team>() { new Team { Name = "Бавария", Country ="Германия" },
                                                 new Team { Name = "Барселона", Country ="Испания" }
            };
            //var result = from pl in players
            //             join t in teams on pl.Team equals t.Name
            //             select new { Name = pl.Name, Team = pl.Team, Country = t.Country };
            var result = players.Join(teams, p => p.Team, t => t.Name, (p, t) => new { Name = p.Name, Team = p.Team, Country = t.Country });
            foreach (var item in result)
                Console.WriteLine($"{item.Name} - {item.Team} ({item.Country})");
            #endregion
            Console.ReadKey();
            #endregion
        }
    }
}