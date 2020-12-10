using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace ConsoleApp1
{

    interface ICarManagment
    {
        void Move();
        void GetMainInfo();
    }

    public interface IIntelligentCreature 
    {
        int LifeLength { get; }
        int IQ { get; }
        string Name { get; }
        void Think();
    }


    public interface ICollectionType<T> where T : IIntelligentCreature //обобщенный интерфейс
    {
        void Add(T element);
        void Delete(T element);
        void Show();
    }


    


    class Engine
    {
        private int powerEngine; //мощность
        private int yearEngine; //год изготовления
        private int massEngine;//масса
        public int PowerEngine { get { return powerEngine; } }
        public int YearEngine { get { return yearEngine; } }
        public int MassEngine { get { return massEngine; } }
        public Engine(int _power, int _year, int _mass)
        {
            if (_power < 0) throw new CreatingClassException(this, _power.GetType());
            if (_power < 0) throw new CreatingClassException(this, _year.GetType());
            if (_power < 0) throw new CreatingClassException(this, _mass.GetType());
            powerEngine = _power;
            yearEngine = _year;
            massEngine = _mass;
        }
        public Engine()
        {
            powerEngine = -1;
            yearEngine = -1;
            massEngine = -1;
        }
        public string ToConsoleEngine()
        {
            return "Двигатель:\n" +
                   "\tМощность: " + powerEngine.ToString() + " лошадиных сил" +
                   "\n\tГод изготовления: " + yearEngine.ToString() + " лет" +
                   "\n\tМасса: " + massEngine.ToString() + " кг";
        }
        public override string ToString()
        {
            return "Двигатель:\n" +
                   "\tМощность: " + powerEngine.ToString() + " лошадиных сил" +
                   "\n\tГод изготовления: " + yearEngine.ToString() + " лет" +
                   "\n\tМасса: " + massEngine.ToString() + " кг";
        }
    }


    abstract class Vehicle : Engine
    {
        protected Vehicle()
            : base()
        {
            brand = "";
            year = -1;
            Mass = -1;
            speed = -1;
        }
        protected Vehicle(string _brand, int _year, int _mass, int _speed, int _powerEngine, int _yearEngine, int _massEngine)
            : base(_powerEngine, _yearEngine, _massEngine)
        {
            brand = _brand ?? throw new CreatingClassException(this);
            if (_year < 0) throw new CreatingClassException(this, _year.GetType());
            if (_mass < 0) throw new CreatingClassException(this, _mass.GetType());
            if (_speed < 0) throw new CreatingClassException(this, _speed.GetType());
            year = _year;
            Mass = _mass;
            speed = _speed;
        }
        protected int speed;  //Скорость
        protected int Speed
        {
            get => speed;
            set => speed = value;
        }
        protected int mass;      //вес
        protected int Mass
        {
            get => mass;
            set => mass = value;
        }
        protected int year;
        public int Year
        {
            get => year;
            set => year = value;
        }
        protected string brand;
        protected string Brand
        {
            get => brand;
            set => brand = value;
        }
        abstract public string Type { get; }
    }


    sealed partial class Car : Vehicle, ICarManagment
    {
        private string type;
        public override string Type
        {
            get => type;
        }
        void ICarManagment.Move() //явная реалзация интерфейса
        {
            Console.WriteLine("Начинаем движение");
        }

        public void GetMainInfo()
        {
            Console.WriteLine("Модель: " + Brand + "\nГод: " + Year);
        }
        public override string ToString()
        {
            return "Тип:" + type +
                   "\nМодель: " + Brand +
                   "\nГод изготовления: " + year.ToString() +
                   "\nМакс скорость: " + Speed.ToString() +
                   "\nВес: " + Mass.ToString() + " кг" +
                   '\n' + ToConsoleEngine();
        }
        public override int GetHashCode()
        {
            int sum = 269;
            sum += brand.GetHashCode();
            sum += year.GetHashCode();
            sum += Speed.GetHashCode();
            sum += type.GetHashCode();
            sum += Mass.GetHashCode();
            return sum;
        }
        public override bool Equals(object obj)
        {
            if (obj.GetType() != GetType())
                return false;
            if (obj.GetHashCode() != GetHashCode())
                return false;
            return true;
        }
    }

    partial class Car
    {
        public Car() : base()
        {
            type = "Машина";
        }
        public Car(string _brand, int _year, int _speed, int _mass, int _powerEngine, int _yearEngine, int _massEngine)
            : base(_brand, _year, _mass, _speed, _powerEngine, _yearEngine, _massEngine)
        {
            type = "Машина";
        }
    }


    public partial class Human : IIntelligentCreature
    {
        private string name;
        public string Name { get { return name; } }
        private string country;
        public string Country { get { return country; } }
        private int lifelength;
        public int LifeLength
        {
            get => lifelength;
        }
        private int iq;
        public int IQ
        {
            get => iq;
        }
        [Serializable]
        struct Birthday
        {
            public int day;
            public int month;
            public int year;
            public Birthday(int _day, int _month, int _year)
            {

                day = _day;
                month = _month;
                year = _year;
            }

        }
        private enum HumanSex
        {
            Man = 9,
            Woman
        };
        private Birthday date;
        public int Day => date.day;
        public int Month => date.month;
        public int Year => date.year;
        private HumanSex sex;
        public string Sex
        {
            get
            {
                if (sex == HumanSex.Man)
                    return "Man";
                if (sex == HumanSex.Woman)
                    return "Woman";
                return "?";
            }
        }

        protected string BirthDate()
        {
            if ((date.day == -1) || (date.month == -1) || (date.year == -1))
                return "?:?:?";
            return date.day.ToString() + ':' + date.month.ToString() + ':' + date.year.ToString();
        }
        public void Think()
        {
            Console.WriteLine("Человек думает мозгами");
        }
        public override string ToString()
        {
            return "Человек:\n" +
                   "Продолжительность жизни: " + "~" + LifeLength + " лет" +
                   "\nИмя: " + Name.ToString() +
                   "\nПол: " + Sex.ToString() +
                   "\nГод рождения: " + BirthDate() + "\n";
        }
    }

    public partial class Human
    {
        public Human()
        {
            lifelength = 100;
            sex = 0;
            date = new Birthday(-1, -1, -1);
            iq = 0;
            name = "";
        }
        public Human(string _name, int _sex, int _age, string _country, int _day, int _month, int _year, int _iq)
        {
            lifelength = 100;
            if (_sex == 1)
                sex = HumanSex.Man;
            else if (_sex == 2)
                sex = HumanSex.Woman;
            else throw new CreatingClassException(this, sex.GetType()); ;
            iq = _iq;
            name = _name ?? throw new CreatingClassException(this);
            country = _country;
            if (_day < 1 || _day > 31) throw new CreatingClassException(this, _day.GetType());
            if (_month < 1 || _month > 12) throw new CreatingClassException(this, _day.GetType());
            if (_year < 1) throw new CreatingClassException(this, _day.GetType());
            date = new Birthday(_day, _month, _year);
        }
    }


    sealed partial class Transformer : Vehicle, IIntelligentCreature, ICarManagment
    {
        private string name;
        public string Name { get { return name; } }
        private bool isCar;
        public bool IsCar
        {
            get => isCar;
            set => isCar = value;
        }
        private string type;
        public override string Type
        {
            get => type;
        }
        private int lifelength;
        public int LifeLength
        {
            get => lifelength;
        }
        private int iq;
        public int IQ
        {
            get => iq;
        }
        public void Move()
        {
            if (IsCar)
                Console.WriteLine("Двигаемся в форме: " + Type);
            else
                Console.WriteLine("Двигаемся в форме: Человек");
        }
        public void ChangeForm()
        {
            IsCar = !IsCar;
        }
        public void Think()
        {
            Console.WriteLine("Трансформер думает железом");
        }
        public void GetMainInfo()
        {
            Console.WriteLine("Модель: " + Brand + "\nГод: " + Year);
        }
        public override string ToString()
        {
            return "Трансформер:" +
                   "Тип:" + type +
                   "\nИмя: " + Name +
                   "\nМодель: " + Brand +
                   "\nПоявился в ~: " + year.ToString() +
                   "\nСейчас в человекоподобной форме: " + (IsCar ? "Нет" : "Да") +
                   "\nМакс скорость: " + Speed.ToString() +
                   "\nВес: " + Mass.ToString() + " кг" +
                   '\n' + ToConsoleEngine();
        }
    }

    partial class Transformer
    {
        public Transformer() : base()
        {
            lifelength = 1000;
            type = "";
        }
        public Transformer(string _type, string _brand, string _name, int _year, int _speed, int _mass, int _iq, int _powerEngine, int _yearEngine, int _massEngine)
          : base(_brand, _year, _mass, _speed, _powerEngine, _yearEngine, _massEngine)
        {
            lifelength = 1000;
            type = _type;
            name = _name;
            iq = _iq;
            IsCar = true;
        }
    }


    class Printer
    {
        public virtual void iAmPrinting(ICarManagment someobj)
        {
            Console.WriteLine("Виртуальный метод");
        }
    }
    class A : Printer
    {
        public override void iAmPrinting(ICarManagment someobj)
        {
            Console.WriteLine(someobj.GetType());
            Console.WriteLine(someobj.ToString());
        }
    }



    //////////////lab6///////////
    class Army
    {
        private List<object> units = new List<object>(); //список
        public int Count => units.Count;
        public List<object> ListofUnits
        {
            get => units;
            set => units = value;
        }
        public void Add(Human human)  //добавление человека в армию
        {
            object x = human;
            units.Add(x);
        }
        public void Add(Transformer transformer) //добавление трансформера в армию
        {
            object x = transformer;
            units.Add(x);
        }
        public void Add(ICarManagment transformer)
        {
            object x = transformer;
            units.Add(x);
        }
        public void Remove(Human human) //удаление человека из армии
        {
            object x = human;
            units.Remove(x);
        }
        public void Remove(Transformer transformer) //удаление трансформера из армии
        {
            object x = transformer;
            units.Remove(x);
        }
        public void Remove(ICarManagment transformer)
        {
            object x = transformer;
            units.Remove(x);
        }
        public void ToConsole()  // вывод на консоль
        {
            object[] arr = units.ToArray();
            for (int i = 0; i < arr.Length; i++)
            {
                Console.WriteLine((i + 1).ToString() + ' ' + arr[i].ToString() + '\n');
            }
        }
    }

    static class ArmyControl
    {

        public static object SearchBirthDate(Army army, int day, int month, int year) //поиск по дню рождения
        {
            Console.WriteLine("Searching unit with birthday date " + day + ':' + month + ':' + year + "...");
            bool flag = false;
            object[] arr = army.ListofUnits.ToArray();
            for (int i = 0; i < arr.Length; i++)
                if (arr[i] is Transformer)
                {
                    Transformer transformer = arr[i] as Transformer;
                    if (transformer.Year == year)
                        return arr[i];
                }
                else
                {
                    Human human = arr[i] as Human;
                    if ((human.Day == day) && (human.Month == month) && (human.Year == year))
                        return arr[i];
                }
            if (flag == false)
                Console.WriteLine("Nothing");
            return "";
        }
        public static void SearchEnginePower(Army army, int power) // поиск по мощности двигателя
        {
            Console.WriteLine("Searching transformer with engine power " + power.ToString() + "...");
            bool flag = false;
            object[] arr = army.ListofUnits.ToArray();
            for (int i = 0; i < arr.Length; i++)
                if (arr[i] is Transformer)
                {
                    Transformer transformer = arr[i] as Transformer;
                    if (transformer.PowerEngine == power)
                    {
                        Console.WriteLine((i + 1).ToString() + ' ' + transformer.Name);
                        flag = true;
                    }
                }
            if (flag == false)
                Console.WriteLine("Nothing");
        }
        public static int Counts(Army army)
        {
            return army.Count;
        }
    }


    ////////////////////////////////lab7//////////////////////////
    class CreatingClassException : Exception //класс исключения
    {
        private string message, field;
        public CreatingClassException(object obj) //создание исключения
        {
            field = "-";
            Source = obj.GetType().ToString();
            message = "На конструктор было подано null значение";
        }
        public CreatingClassException(object obj, Type fieldType)
        {
            field = fieldType.ToString();
            Source = obj.GetType().ToString();
            message = "На конструктор было подано неверное значение";
        }
        public string GetMessage => message;
        public string WhatData => field;
    }
    class OutofRangeException : Exception //исключение вне диапазона
    {
        private string message;
        private int usedindex, range;
        private long outvalue;
        public OutofRangeException(long value)
        {
            if (value > 0)
                outvalue = value - int.MaxValue;
            if (value < 0)
                outvalue = int.MinValue - value;
            usedindex = 0;
            range = 0;
            message = "Выход за пределы типа значения";
        }
        public OutofRangeException(int value, int arrlength)
        {
            usedindex = value;
            range = arrlength;
            outvalue = 0;
            message = "Выход за пределы размера массива";
        }
        public string GetMessage => message;
        public long OutValue => outvalue;
        public int OutRange
        {
            get
            {
                if (usedindex < 0)
                    return usedindex;
                return usedindex - range;
            }
        }
    }
    class ArithmeticException : Exception //арифметическоле исключение
    {
        private string message;
        public ArithmeticException()
        {
            message = "Арифметическая ошибка";
        }
        public string GetMessage => message;
    }


    ////////////////////////////////lab8//////////////////////////
    public class Set<T> : ICollectionType<T> where T : IIntelligentCreature //обобщенный класс
    {
        public readonly Owner owner = new Owner(3, "Ivan Ivanovich", "BSTU");
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

        public void Add(T item)
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

        public static Set<T> Union(Set<T> set1, Set<T> set2) //объединение
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

        public static Set<T> Intersection(Set<T> set1, Set<T> set2) //пересечение 
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
        // перегрузка оператора false
        public static bool operator false(Set<T> obj)
        {
            if (obj.Count < 6 && obj.Count > 1)
                return true;
            return false;
        }

        //  перегрузка оператора true
        public static bool operator true(Set<T> obj)
        {
            if (obj.Count > 6 || obj.Count < 1)
                return true;
            return false;
        }

    }




    internal class Program
    {
        private static void Main(string[] args)
        {
            #region
            Car car1 = new Car("toyota", 2010, 180, 3000, 800, 2010, 100);
            Car car12 = new Car("AUDI", 2011, 300, 3250, 1100, 2009, 600);
            ICarManagment car2 = new Car("toyota", 2010, 300, 3000, 900, 2008, 700);
            Vehicle vehicle;
            vehicle = car12 as Vehicle;

            Console.WriteLine("------------------------------------------------");
            Console.WriteLine("Вывод созданных объектов");
            Console.WriteLine(vehicle.ToString());
            Console.WriteLine("------------------------------------------------");
            Console.WriteLine(car1.ToString());
            Console.WriteLine("------------------------------------------------");
            Console.WriteLine(car2.ToString());
            Console.WriteLine("------------------------------------------------");

            ICarManagment car;
            //car.Move(); не присвоено значение
            car = car1 as ICarManagment;
            //car1.Move(); //не содержит метода Move
            Console.WriteLine("Демонстрация движения машины и вывод информации");
            car.Move();
            car2.Move();
            car2.GetMainInfo();
            Console.WriteLine("------------------------------------------------");

            Human human1 = new Human("Ivan Ivanovich", 1, 18, "Belarus", 1, 1, 2000, 130);
            Human human2 = new Human("Petr Petrovich", 1, 18, "Belarus", 2, 2, 2000, 130);
            Transformer transformer1 = new Transformer("Car", "Bamblbee", "BMW", 1985, 300, 4385, 125, 749, 2001, 800);
            ICarManagment transformer2 = new Transformer("Car", "Optimus1", "МАЗ", 1093, 320, 1500, 154, 749, 2013, 720);
            IIntelligentCreature creature1;
            creature1 = human1 as IIntelligentCreature;
            Console.WriteLine("------------------------------------------------");
            Console.WriteLine("Вывод созданных объектов");
            Console.WriteLine(human1.ToString());
            Console.WriteLine("------------------------------------------------");
            Console.WriteLine(creature1.ToString());
            Console.WriteLine("------------------------------------------------");
            Console.WriteLine(transformer1.ToString());
            Console.WriteLine("------------------------------------------------");
            Console.WriteLine(transformer2.ToString());
            Console.WriteLine("------------------------------------------------");


            Console.WriteLine("Демонстрация движения трансформера и вывод информации");
            transformer1.Move();
            transformer1.ChangeForm();
            transformer1.Move();
            transformer1.GetMainInfo();

            Console.WriteLine("------------------------------------------------");
            Console.WriteLine("Как думает трансфомер и человек");
            creature1 = transformer2 as IIntelligentCreature;
            human1.Think();
            creature1.Think();
            Console.WriteLine("------------------------------------------------");
            ICarManagment[] arr = { car2, transformer2 };

            Printer printer = new Printer();
            Printer printerA = new A();
            printer.iAmPrinting(arr[0]);
            Console.WriteLine("------------------------------------------------");
            for (int i = 0; i < arr.Length; i++)
            {
                printerA.iAmPrinting(arr[i]);
                Console.WriteLine("------------------------------------------------");
            }

            Army army1 = new Army();
            army1.Add(human1);
            army1.Add(human2);
            army1.Add(transformer1);
            army1.Add(transformer2);
            Console.WriteLine("------------------------------------------------");
            Console.WriteLine("------------------------------------------------");
            Console.WriteLine("------------------------------------------------");
            army1.ToConsole();
            //army1.ListofUnits[0] = transformer1;
            Console.WriteLine(army1.ListofUnits[0].GetType());
            Console.WriteLine("------------------------------------------------");
            Console.WriteLine(human1.GetType());
            object temp = human1;
            Console.WriteLine(temp.GetType());
            Console.WriteLine("------------------------------------------------");
            Console.WriteLine(ArmyControl.SearchBirthDate(army1, 1, 1, 2000)); //поиск по дате рождения
            ArmyControl.SearchEnginePower(army1, 749); //поиск по мощности двигателя
            try
            {
                Human humanExeption = new Human("Petr Petrovich", 1, 18, "Belarus", 90, 2, 2, 130); //дата
            }
            catch (CreatingClassException exception)
            {
                Console.WriteLine(exception.GetMessage);
                Console.WriteLine(exception.StackTrace);
                Console.WriteLine("Класс который вызвал ошибку: " + exception.Source);
                Console.WriteLine("Тип поля которое вызвало ошибку: " + exception.WhatData);
            }
            Console.WriteLine("------------------------------------------------");
            try
            {
                Human humanExeption = new Human(null, 1, 18, "Belarus", 90, 2, 2, 130); //дата
            }
            catch (CreatingClassException exception)
            {
                Console.WriteLine(exception.GetMessage);
                Console.WriteLine(exception.StackTrace);
                Console.WriteLine("Класс который вызвал ошибку: " + exception.Source);
                Console.WriteLine("Тип поля которое вызвало ошибку: " + exception.WhatData);
            }
            Console.WriteLine("------------------------------------------------");
            try
            {
                int[] arr1 = { 1, 2, 3 };
                int i = -4;
                if (i > arr1.Length || i < 0)
                {
                    throw new OutofRangeException(i, arr1.Length);
                }
                else
                {
                    Console.WriteLine(arr[i].ToString());
                }
            }
            catch (OutofRangeException exception)
            {
                Console.WriteLine(exception.GetMessage);
                Console.WriteLine(exception.StackTrace);
                Console.WriteLine("Вышло за пределы типа на значение: " + exception.OutValue.ToString());
                Console.WriteLine("Вышло за пределы массива на значение: " + exception.OutRange.ToString());
            }
            Console.WriteLine("------------------------------------------------");
            try
            {
                long i = 200;
                long x = i + int.MaxValue;
                if (x > int.MaxValue || x < int.MinValue)
                {
                    throw new OutofRangeException(x);
                }
            }
            catch (OutofRangeException exception)
            {
                Console.WriteLine(exception.GetMessage);
                Console.WriteLine(exception.StackTrace);
                Console.WriteLine("Вышло за пределы типа на значение: " + exception.OutValue.ToString());
                Console.WriteLine("Вышло за пределы массива на значение: " + exception.OutRange.ToString());
            }
            Console.WriteLine("------------------------------------------------");
            try
            {
                int x = 10;
                int y = 0;
                int result = (y == 0) ? throw new ArithmeticException() : x / y;
            }
            catch (ArithmeticException exception)
            {
                Console.WriteLine(exception.GetMessage);
                Console.WriteLine(exception.StackTrace);
            }
            Console.WriteLine("------------------------------------------------");
            try
            {
                int x = 0;
                int y = 10 / x;
            }
            catch
            {
                Console.WriteLine("Вызвано исключение");
            }
            finally
            {
                Console.WriteLine("Обработка ошибок завершена");
            }
            Console.WriteLine("------------------------------------------------");
            int[] aa = null;
            #endregion
            Set<IIntelligentCreature> myList1 = new Set<IIntelligentCreature>();
            Console.WriteLine("------------------------------------------------");
            Console.WriteLine("------------------------------------------------");
            Console.WriteLine("Lab8");
            myList1.Add(human1);
            myList1.Add(human2);
            myList1.Show();
            Console.ReadKey();
        }
    }
}
