using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace lab12
{

    public interface IIntelligentCreature
    {
        int LifeLength { get; }
        int IQ { get; }
        string Name { get; }
        void Think();
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
            Console.WriteLine("Я думаю мозгами");
        }
        public override string ToString()
        {
            return "Человек:\n" +
                   "Продолжительность жизни: " + "~" + LifeLength + " лет" +
                   "\nИмя: " + Name.ToString() +
                   "\nПол: " + Sex.ToString() +
                   "\nГод рождения: " + BirthDate() + "\n";
        }
        public int Met(string name)
        {
            Console.WriteLine("Name " + name);
            return 0;
        }
        public int Met1(string name, int a)
        {
            Console.WriteLine("Name " + name);
            return 0;
        }
        public int Met2(string name, int ab)
        {
            Console.WriteLine("Name " + name);
            return 0;
        }
    }


    [Serializable]
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
            iq = _iq;
            country = _country;
            date = new Birthday(_day, _month, _year);
        }
    }

    


    public class Reflector
    {

        public Type type;
        
        public Reflector(string type)
        {
            this.type = Type.GetType(type, false, true);
        }
        public Reflector(Type type)
        {
            this.type = type;
        }
        public void AboutClass()
        //вся инфа о классе
        {
            FileStream fstream = new FileStream(this.type.Name + " class.txt", FileMode.Create);
            using (fstream)
            {
                StreamWriter sw = new StreamWriter(fstream);
                foreach (MemberInfo info in type.GetMembers())//GetMembers возвращает члены (свойства, методы, поля, события и т. д.) текущего объекта Type.
                {
                    sw.WriteLine(info.DeclaringType + " - " + info.MemberType + " - " + info.Name + "\n");
                }
                sw.Close();
            }
        }

        public void PublicMethods()
        {
            using (FileStream fstream = new FileStream(this.type.Name + " methods.txt", FileMode.Create))
            {
                StreamWriter sw = new StreamWriter(fstream);
                foreach (MethodInfo method in type.GetMethods())
                {
                    if (method.IsPublic)
                    {
                        sw.WriteLine(method.Name + "\n");//Массив байтов, содержащий результаты кодирования указанного набора символов.
                    }
                }
                sw.Close();
            }
        }
        public void Fields()
        {
            using (FileStream fstream = new FileStream(this.type.Name + " fields_properties.txt", FileMode.Create))
            {
                StreamWriter sw = new StreamWriter(fstream);
                foreach (FieldInfo field in type.GetFields())
                {
                    sw.WriteLine(field.FieldType + " - " + field.Name + "\n");
                }
                foreach (PropertyInfo prorertie in type.GetProperties())
                {
                    sw.WriteLine(prorertie.PropertyType + " - " + prorertie.Name + "\n");
                }
                sw.Close();
            }
        }
        public void Interfaces()
        {
            using (FileStream fstream = new FileStream(this.type.Name + " interfaces.txt", FileMode.Create))
            {
                StreamWriter sw = new StreamWriter(fstream);
                foreach (Type interfaces in type.GetInterfaces())
                {
                    sw.WriteLine(interfaces.DeclaringType + " - " + interfaces.MemberType + " - " + interfaces.Name + "\n");
                }
                sw.Close();
            }
        }
        public void Methods()
        {
            var methods = type.GetMethods();
            Console.Write("Введите тип параметра: ");
            string name = Console.ReadLine();
            Type paramtype = typeof(int);
            var result = methods.Where(a => a.GetParameters().Where(t => t.ParameterType.Name.ToLower() == name.ToLower()).Count() != 0);
            Console.WriteLine($"Все методы, содержащие заданный параметр {name}: ");
            foreach (var el in result)
                Console.WriteLine(el.Name);
        }
        public void Runtimemethod(string method)
        {
            FileStream fstream = new FileStream("param.txt", FileMode.OpenOrCreate);
            StreamReader sr = new StreamReader(fstream);
            object obj = Activator.CreateInstance(type);
            string r;
            r = sr.ReadToEnd();
            MethodInfo m = type.GetMethod(method);
            m.Invoke(obj, new object[] { r });
        }

    }
   

    class Program
    {
        static void Main(string[] args)
        {
            Reflector reflector = new Reflector("lab12.Human");
            reflector.AboutClass();
            reflector.PublicMethods();
            reflector.Fields();
            reflector.Interfaces();
            reflector.Methods();
            reflector.Runtimemethod("Met");

            Reflector reflector1 = new Reflector("lab12.IIntelligentCreature");
            reflector1.AboutClass();
            reflector1.PublicMethods();
            reflector1.Fields();
            reflector1.Interfaces();
            reflector1.Methods();
            string str = "as";
            Reflector reflector2 = new Reflector(str.GetType());
            reflector2.AboutClass();
            reflector2.PublicMethods();
            reflector2.Fields();
            reflector2.Interfaces();
            reflector2.Methods();
        }
    }
}

/*


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.IO;

namespace OOP_Lab12
{

    public class Test
    {
        public string LabName;

        public string LABName
        {
            get => LabName;
            set => LabName = value;
        }

        public Test() => LabName = "unknown";
        public Test(string str) => LabName = str;

        public void PrintLabName() => Console.WriteLine($"LabName: {LabName}");

        public void ChangeLabName(string name) => LABName = name;

        public void WriteSmth(string str) => Console.WriteLine(str + "\n");

    }

    public static class Reflector
    {
        private static string path = "MyFile.txt";
        public static StreamWriter file = null;
        public static string GetPath
        {
            get => path;
        }

        public static string SetPath
        {
            set => path = value;
        }

        private static void OpenFile()
        {
            if (path != null)
                file = new StreamWriter(path, true);
        }
        public static void CloseFile()
        {
            if (file != null)
                file.Close();
        }

        public static void AssemblyName(string AssemblyName = @"lab12.exe")
        {
            OpenFile();
            Assembly assembly = Assembly.LoadFrom(AssemblyName);

            file.WriteLine($"Assembly: {AssemblyName}");
            file.WriteLine();
            CloseFile();
        }

        public static void PublicConstructors(string ClassName)
        {
            bool AnyPublic = false;
            OpenFile();

            foreach (var item in Type.GetType(ClassName).GetConstructors())
            {
                if (item.IsPublic)
                    AnyPublic = true;
            }

            file.WriteLine($"Class name: {ClassName} - have public constructor: {AnyPublic}");
            file.WriteLine();
            CloseFile();
        }

        public static void PublicMethods(string ClassName)
        {
            OpenFile();

            file.WriteLine($"{ClassName} public methods: ");
            foreach (var item in Type.GetType(ClassName).GetMethods())
            {
                file.WriteLine(item.Name);
            }
            file.WriteLine();
            CloseFile();
        }

        public static void FieldAndProps(string ClassName)
        {
            OpenFile();

            file.WriteLine($"Fields of class: {ClassName}");

            foreach (var item in Type.GetType(ClassName).GetFields())
                file.WriteLine($"Fields: {item.Name}");

            file.WriteLine($"Properties of class: {ClassName}");
            foreach (var item in Type.GetType(ClassName).GetProperties())
                file.WriteLine($"Properties: {item.Name}");

            file.WriteLine();
            CloseFile();
        }

        public static void ImplementedInterfaces(string ClassName)
        {
            OpenFile();

            file.WriteLine($"{ClassName} Implemented interfaces: ");
            foreach (var item in Type.GetType(ClassName).GetInterfaces())
            {
                file.WriteLine(item.Name);
            }

            file.WriteLine();
            CloseFile();
        }

        public static void MethodsWithPar(string ClassName)
        {
            OpenFile();

            Console.WriteLine("Enter a Method Parameter: ");
            string parm = Console.ReadLine();
            file.WriteLine($"Methods with parm: {parm} in class: {ClassName}");

            foreach (var item in Type.GetType(ClassName).GetMethods())
                foreach (var itemParm in item.GetParameters())
                    if (parm == itemParm.ParameterType.Name)
                        file.WriteLine($"Method: {itemParm.Name}");

            file.WriteLine();
            CloseFile();
        }

        public static void Invoke(string ClassName, string MethodName, string ArgPath)
        {
            Console.WriteLine($"Try to call method:{MethodName} in class: {ClassName}");

            var CurMethod = Type.GetType(ClassName).GetMethod(MethodName);

            if (CurMethod == null)
                Console.WriteLine("Didn't find method...");
            else
            {
                StreamReader streamReader = new StreamReader(ArgPath);

                object obj = Activator.CreateInstance(Type.GetType(ClassName));
                string parm;
                while ((parm = streamReader.ReadLine()) != null)
                {
                    if (CurMethod.GetParameters().Length != 0)
                        CurMethod.Invoke(obj, parm.Split(' '));
                    else
                        CurMethod.Invoke(obj, new object[] { });
                }

            }

        }

        public static object CreateType(string className)
        {

            return Activator.CreateInstance(Type.GetType(className));
        }
    }

    // запускать без отладки + название типа параметра метода писать с большой буквы (String)
    class Program
    {
        static void Main(string[] args)
        {
            File.WriteAllText(@"MyFile.txt", string.Empty);
            string className = "OOP_Lab12.Test";
            Reflector.AssemblyName(); //название сборки
            Reflector.PublicConstructors(className);
            Reflector.PublicMethods(className);
            Reflector.FieldAndProps(className); //поле и реквизит
            Reflector.ImplementedInterfaces(className); // реализация интерфейса
            Reflector.MethodsWithPar(className);
            Console.WriteLine();

            Reflector.Invoke("OOP_Lab12.Test", "WriteSmth", "argPath.txt");

            Test obj = (Test)Reflector.CreateType("OOP_Lab12.Test");
            obj.LABName = "Lab12";
            obj.PrintLabName();
        }
    }
}
*/