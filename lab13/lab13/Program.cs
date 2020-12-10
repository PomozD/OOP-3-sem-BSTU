using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace lab13
{

    internal class BAADirInfo
    {
        private DirectoryInfo dir;
        public BAADirInfo(string _dir = null)
        {
            BAALog.WriteMessage("Вызов конструктора класса: " + GetType().Name);
            dir = new DirectoryInfo(_dir);
        }
        public void DirInfo()
        {
            BAALog.WriteMessage("Вывод инфомации о папке: " + dir.Name + ". В классе :" + GetType().Name);
            if (dir.Exists)
            {
                Console.WriteLine("\nИмя каталога: " + dir.Name);
                Console.WriteLine("Количество файлов: " + dir.GetFiles().Count());
                Console.WriteLine("Время создание каталога: " + dir.GetFiles().Count());
                Console.WriteLine("Количество подкаталогов: " + dir.GetDirectories().Count());
                Console.WriteLine("Список родительских катологов подкаталогов: ");
                ParentList();
            }
        }
        private void ParentList()
        {
            BAALog.WriteMessage("Вывод списка родительских папок , папки: " + dir.Name + ". В классе :" + GetType().Name);
            DirectoryInfo temp = new DirectoryInfo(dir.FullName);
            while (temp != null)
            {
                Console.WriteLine(temp = temp.Parent);
            }
        }
    }

    internal static class BAADiskInfo
    {
        private static readonly DriveInfo[] AllDisk = DriveInfo.GetDrives();

        public static void FreeSpace(string name)
        {
            BAALog.WriteMessage("Метод для вывода информации о свободном месте на диске: " + name);
            Console.WriteLine(name);
            name = name + ":\\";
            Console.WriteLine(name);
            foreach (DriveInfo disk in AllDisk)
            {
                if (disk.Name == name)
                {
                    Console.WriteLine($"Name disk:{disk.Name}");
                    if (disk.IsReady)
                    {
                        Console.WriteLine($"Free space: {disk.TotalFreeSpace / 1024 / 1024 / 1024} ГБ\n");
                    }
                }
            }
        }
        public static void DisInfo()
        {
            BAALog.WriteMessage("Метод для вывода информации о дисках компьютера: ");
            foreach (DriveInfo disk in AllDisk)
            {
                Console.WriteLine($"Name disk:{disk.Name}");
                if (disk.IsReady)
                {
                    Console.WriteLine($"Total size: {disk.TotalSize / 1024 / 1024 / 1024} ГБ");
                    Console.WriteLine($"Free space: {disk.TotalFreeSpace / 1024 / 1024 / 1024} ГБ");
                    Console.WriteLine($"FileSystem:{disk.RootDirectory}");
                    Console.WriteLine($"VolumeLabel:{disk.VolumeLabel}");
                    Console.WriteLine($"DriveType:{disk.DriveType}\n");
                }
            }
        }
    }


    internal class BAAFileInfo
    {
        private FileInfo file;
        public BAAFileInfo(string name = null)
        {
            BAALog.WriteMessage("Вызов конструктора класса: " + GetType().Name);
            if (name != null)
            {
                file = new FileInfo(name);
            }
        }

        public void Path()
        {
            BAALog.WriteMessage("Вывод инфомации о файле: " + file.Name + ". В классе :" + GetType().Name);
            if (file.Exists)
            {
                Console.WriteLine("\n Полный путь файла: " + file.FullName);
                Console.WriteLine(" Размер файла: " + file.Length + "байт");
                Console.WriteLine(" Расширение файла: " + file.Extension);
                Console.WriteLine(" Имя файла: " + file.Name);
                Console.WriteLine(" Дата создания файла: " + file.CreationTimeUtc);
                Console.WriteLine(" Дата создания файла: " + file.CreationTime);
            }

        }


    }


    internal static class BAAFileManager
    {
        private static ZipArchive zip;
        public static void FileSubdir(string name = null)
        {
            BAALog.WriteMessage("Вывод инфомации о вложенных папках и файлах диска: " + name);
            if (name != null)
            {
                Console.WriteLine("Подкаталоги:");
                string[] dirs = Directory.GetDirectories(name);
                foreach (string s in dirs)
                {
                    Console.WriteLine(s);
                }
                Console.WriteLine();
                Console.WriteLine("Файлы:");
                string[] files = Directory.GetFiles(name);
                foreach (string s in files)
                {
                    Console.WriteLine(s);
                }
            }
        }
        public static void CreateA()
        {
            BAALog.WriteMessage("Создание папки,файла,заполнение,копирование,удаления");
            string path = @"D:\\БГТУ 2 курс\\OOP\\";
            DirectoryInfo directory = new DirectoryInfo(path);
            directory.CreateSubdirectory("BAAInspect");
            if (!directory.Exists)
            {
                directory.Create();
            }

            Console.WriteLine(directory.FullName);
            FileInfo file = new FileInfo(directory.FullName + "BAAInspect\\baadirinfo.txt");
            using (FileStream fs = new FileStream(file.FullName, FileMode.OpenOrCreate))
            {
                string text = "Hello World";
                byte[] array = System.Text.Encoding.Default.GetBytes(text);
                fs.Write(array, 0, array.Length);
                fs.Close();
            }
            File.Copy(file.FullName, file.DirectoryName + "\\test.txt", true);
            file.CopyTo("newfile.txt", true);
            file.Delete();
        }
        public static void CreateB()
        {
            BAALog.WriteMessage("Создание папки,перемещение файлов с заданым расширение из одной папки в другую");
            string path = @"D:\\БГТУ 2 курс\\OOP\\";
            DirectoryInfo directory = new DirectoryInfo(path);
            directory.CreateSubdirectory("BAAFiles");
            if (!directory.Exists)
            {
                directory.Create();
            }

            Console.WriteLine(directory.FullName);
            DirectoryInfo source = new DirectoryInfo(@"D:\\БГТУ 2 курс\\OOP\\лекции");
            DirectoryInfo destin = new DirectoryInfo(@"D:\\БГТУ 2 курс\\OOP\\BAAFiles\\");
            DirectoryInfo destin1 = new DirectoryInfo(@"D:\\БГТУ 2 курс\\OOP\\BAAInspect\\BAAFiles");
            foreach (FileInfo item in source.GetFiles().Where(x => x.Extension == ".txt").ToList())
            {
                item.CopyTo(destin + item.Name, true);
            }
            if (!destin1.Exists)
            {
                destin.MoveTo(destin1.FullName);
            }
        }
        //public static void Ziping(string what)
        //{
        //        bufdirectory = new DirectoryInfo(what);
        //        ZipFile.CreateFromDirectory(bufdirectory.FullName, bufdirectory.FullName + ".zip");
        //        zip = new ZipArchive(File.Open(bufdirectory.FullName + ".zip", FileMode.Open));
        //}
        //public static void UnZiping(string where)
        //{
        //        bufdirectory = new DirectoryInfo(where);
        //        foreach (ZipArchiveEntry x in zip.Entries)
        //            x.ExtractToFile(bufdirectory.FullName + '\\' + x.Name);

        //}
        public static void CreateC()
        {
            BAALog.WriteMessage("Архивирование папки");
            DirectoryInfo bufdirectory = new DirectoryInfo(@"D:\\БГТУ 2 курс\\OOP\\BAAInspect\\BAAFiles");
            if (!File.Exists(@"D:\\БГТУ 2 курс\\OOP\\BAAInspect\\BAAFiles.zip"))
            {
                ZipFile.CreateFromDirectory(bufdirectory.FullName, bufdirectory.FullName + ".zip");
            }
            using (ZipArchive zip = new ZipArchive(File.Open(bufdirectory.FullName + ".zip", FileMode.Open)))
            {
                DirectoryInfo bufdirectory1 = new DirectoryInfo(@"D:\\БГТУ 2 курс\\OOP\\BAAInspect");
                foreach (ZipArchiveEntry x in zip.Entries)
                    x.ExtractToFile(bufdirectory1.FullName + '\\' + x.Name, true);
            }
        }
    }


    public static class BAALog
    {
        private static StreamWriter writer = new StreamWriter("baalogfile.txt", true);

        public static void WriteMessage(string message)
        {
            writer.WriteLine(message + ' ' + DateTime.Now.ToString());
        }

        public static void SearchDateDay(string _day)
        {
            string day = _day.Length == 1 ? "0" + _day : _day;
            writer.Close();
            string x, y = "";
            bool space = false;
            StreamReader reader = new StreamReader("baalogfile.txt");
            while (reader.EndOfStream == false)
            {
                x = reader.ReadLine();
                int i = x.Length - 1;
                while (true)
                {
                    if (x[i] == ' ')
                    {
                        if (space == false)
                        {
                            space = true;
                        }
                        else
                        {
                            break;
                        }
                    }

                    y = x[i] + y;
                    i--;
                }
                if (y.Substring(0, 2) == day)
                {
                    Console.WriteLine(x);
                }

                y = "";
                space = false;
            }
            reader.Close();
            writer = new StreamWriter("baalogfile.txt", true);
        }

        public static void SearchPartTime(string parttime)
        {
            DateTime time1, time2, time3;
            int j = 0;
            while (parttime[j] != '-')
            {
                j++;
            }

            time1 = DateTime.Parse(parttime.Substring(0, j));
            time2 = DateTime.Parse(parttime.Substring(j + 1, parttime.Length - j - 1));
            writer.Close();
            string x, y = "";
            StreamReader reader = new StreamReader("baalogfile.txt");
            while (reader.EndOfStream == false)
            {
                x = reader.ReadLine();
                int i = x.Length - 1;
                while (true)
                {
                    if (x[i] == ' ')
                    {
                        break;
                    }
                    y = x[i] + y;
                    i--;
                }
                time3 = DateTime.Parse(y);
                if ((time3 >= time1) && (time3 <= time2))
                {
                    Console.WriteLine(x);
                }

                y = "";
            }
            reader.Close();
            writer = new StreamWriter("baalogfile.txt", true);
        }

        public static void SearchWord(string word)
        {
            writer.Close();
            string x;
            StreamReader reader = new StreamReader("baalogfile.txt");
            while (reader.EndOfStream == false)
            {
                if ((x = reader.ReadLine()).Contains(word) == true)
                {
                    Console.WriteLine(x);
                }
            }

            reader.Close();
            writer = new StreamWriter("baalogfile.txt", true);
        }
        public static void Count()
        {
            writer.Close();
            int count = 0;
            StreamReader reader = new StreamReader("baalogfile.txt");
            while (reader.EndOfStream == false)
            {
                reader.ReadLine();
                count++;
            }
            reader.Close();
            Console.WriteLine("Всего записей: " + count);
            writer = new StreamWriter("baalogfile.txt", true);
        }
        public static void Delete()
        {
            writer.Close();
            DateTime time1, time2, time3;
            time1 = DateTime.Now;
            time2 = time1.AddHours(-1);
            Console.WriteLine(time2.ToShortTimeString());
            int count = 0;
            string x, y = "";
            StreamReader reader = new StreamReader("baalogfile.txt");
            StreamWriter writer1 = new StreamWriter("baalogfiletemp.txt");
            while (reader.EndOfStream == false)
            {
                x = reader.ReadLine();
                int i = x.Length - 1;
                while (true)
                {
                    if (x[i] == ' ')
                    {
                        break;
                    }
                    y = x[i] + y;
                    i--;
                }
                time3 = DateTime.Parse(y);
                if ((time3 >= time2) && (time3 <= time1))
                {
                    writer1.WriteLine(x);
                }

                y = "";
            }
            reader.Close();
            writer1.Close();
            File.Delete("baalogfile.txt");
            File.Move("baalogfiletemp.txt", "baalogfile.txt");
            Console.WriteLine("Всего записей: " + count);
            writer = new StreamWriter("baalogfile.txt", true);
        }
        public static void Close()
        {
            writer.Close();
        }
    }


    internal class Program
    {
        private static void Main(string[] args)
        {
            BAADiskInfo.FreeSpace("C");
            BAADiskInfo.DisInfo();
            BAAFileInfo file = new BAAFileInfo(@"D:\БГТУ 2 курс\OOP\Лабы\lab13\lab13\lab13test.txt");
            BAADirInfo dir = new BAADirInfo(@"D:\БГТУ 2 курс\OOP\Лабы\lab13\lab13");
            file.Path();
            dir.DirInfo();
            BAAFileManager.FileSubdir("D:\\");
            BAAFileManager.CreateA();
            BAAFileManager.CreateB();
            BAAFileManager.CreateC();
            BAALog.SearchWord("файле");
            BAALog.SearchDateDay("21");
            BAALog.SearchPartTime("22:00-23:00");
            BAALog.Count();
            BAALog.Delete();
            BAALog.Close();
            Console.ReadKey();
        }
    }
}