using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Formatters.Soap;
using System.Xml.Serialization;
using System.Runtime.Serialization.Json;
using System.Xml.Linq;
using System.Xml.XPath;
namespace lab14
{


    public interface IIntelligentCreature
    {
        int LifeLength { get; }
        int IQ { get; }
        string Name { get; }
        void Think();
    }


    [Serializable]
    [XmlRoot("Human")]
    public partial class Human : IIntelligentCreature
    {
        private string sex;
        private int age;
        private int iq;
        private string name;
        private int lifelength;
        public int LifeLength
        {
            get => lifelength;
            set => lifelength = value;
        }
        public Human()
        {
            LifeLength = 100;
            sex = "";
            age = -1;
            iq = -1;
            name = "";
        }
        public Human(string _sex, int _age, int _iq, string _name)
        {
            LifeLength = 100;
            sex = _sex;
            age = _age;
            iq = _iq;
            name = _name;
        }
        public string Name
        {
            get => name;
            set => name = value;
        }
        public string Sex
        {
            get => sex;
            set => sex = value;
        }
        public int Age
        {
            get => age;
            set => age = value;
        }
        public int IQ
        {
            get => iq;
            set => iq = value;
        }
        public void Think()
        {
            Console.WriteLine("think");
        }
        public override string ToString()
        {
            return "Человек:\n" +
                   "Продолжительность жизни: " + "~" + LifeLength + " лет" +
                   "\nИмя: " + name.ToString() +
                   "\nПол: " + sex.ToString() +
                   "\nВозвраст: " + age.ToString() + " лет" +
                   "\nIQ: " + iq.ToString();
        }
    }


    [Serializable]
    [XmlRoot("Human")]
    
    public class Army
    {
        private List<Human> units = new List<Human>();
        public Army()
        {

        }
        [XmlAttribute]
        public int Count => units.Count;
        [XmlArray("ListofUnits")]
        [XmlArrayItem("Human")]
        [XmlIgnore]
        public List<Human> ListofUnits
        {
            get => units;
            set => units = value;
        }
        public void Add(Human human)
        {
            Human x = human;
            units.Add(x);
        }
        public void Remove(Human human)
        {
            Human x = human;
            units.Remove(x);
        }
        public void ToConsole()
        {
            Human[] arr = units.ToArray();
            for (int i = 0; i < arr.Length; i++)
            {
                Console.WriteLine((i + 1).ToString() + ' ' + arr[i].ToString() + '\n');
            }
           }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Human human = new Human("Man", 19, 175, "Anton");
            Human human1 = new Human("Man", 20, 175, "Nikita");
            Army army = new Army();
            army.Add(human);
            army.Add(human1);
            BinaryFormatter formatter = new BinaryFormatter();
            SoapFormatter formatter1 = new SoapFormatter();
            XmlSerializer formatter2 = new XmlSerializer(typeof(Army));
            DataContractJsonSerializer formatter3 = new DataContractJsonSerializer(typeof(Army));

            using (FileStream fs = new FileStream("army.dat", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, army);
            }

            using (FileStream fs = new FileStream("human.soap", FileMode.OpenOrCreate))
            {
                formatter1.Serialize(fs, human);
            }

            using (TextWriter fs = new StreamWriter("army.xml"))
            {
                formatter2.Serialize(fs, army);
            }

            using (FileStream fs = new FileStream("army.json", FileMode.OpenOrCreate))
            {
                formatter3.WriteObject(fs, army);
            }

            using (FileStream fs = new FileStream("army.dat", FileMode.OpenOrCreate))
            {
                Army army1;
                army1 = (Army)formatter.Deserialize(fs);
                Console.WriteLine("Binary");
                army1.ToConsole();
            }

            using (FileStream fs = new FileStream("human.soap", FileMode.OpenOrCreate))
            {
                Human human3;
                human3 = (Human)formatter1.Deserialize(fs);
                Console.WriteLine("SOAP");
                Console.WriteLine(human3.ToString());
            }

            using (FileStream fs = new FileStream("army.xml", FileMode.OpenOrCreate))
            {
                Army army1;
                army1 = (Army)formatter2.Deserialize(fs);
                Console.WriteLine("XML");
                army1.ToConsole();
            }
            using (FileStream fs = new FileStream("army.json", FileMode.OpenOrCreate))
            {
                Army army1 = new Army();
                Console.WriteLine("JSON");
                ((Army)formatter3.ReadObject(fs)).ToConsole();
            }

            Human[] humans = new Human[] { new Human("Man", 19, 175, "Anton"), new Human("Woman", 18, 165, "Veronika"), new Human("Man", 20, 180, "Misha") };
            using (FileStream fs = new FileStream("array.xml", FileMode.OpenOrCreate))
            {
                formatter2 = new XmlSerializer(typeof(Human[]));
                formatter2.Serialize(fs, humans);

            }
            using (FileStream fs = new FileStream("array.xml", FileMode.OpenOrCreate))
            {
                foreach (Human x in (Human[])formatter2.Deserialize(fs))
                    Console.WriteLine(x.ToString());
            }

            XPathDocument xmldoc = new XPathDocument("array.xml");
            Console.WriteLine("HERE");
            foreach (XPathItem x in xmldoc.CreateNavigator().Select("//Human/Name"))
                Console.WriteLine(x.Value);
            Console.WriteLine();
            foreach (XPathItem x in xmldoc.CreateNavigator().Select("//Human[Sex = \"Man\"]/Name"))
                Console.WriteLine(x.Value);
            using (FileStream fs = new FileStream("array.xml", FileMode.OpenOrCreate))
            {
                XDocument xdoc = XDocument.Load(fs);
                XElement root = xdoc.Element("ArrayOfHuman");
                foreach (XElement xe in root.Elements("Human").Where(x => x.Element("Name").Value.Contains("o")).ToList())
                {
                    if (Int32.Parse(xe.Element("Age").Value) > 19)
                    {
                        xe.Add(new XElement("Permission", "Yes"));
                    }
                    else
                    {
                        xe.Remove();
                    }
                }
                root.Add(new XElement("Human",
                            new XElement("LifeLength", "100"),
                            new XElement("Name", "Valera"),
                            new XElement("Sex", "Man"),
                            new XElement("Age", "20"),
                            new XElement("IQ", "100"),
                            new XElement("Permission", "Yes")));
                xdoc.Save("newArray.xml");

            }

        }
    }
}