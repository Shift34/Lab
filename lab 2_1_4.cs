using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp8
{
    class SoftwareContainer<T> where T : Software
    {
        SortedSet<Software> set = new SortedSet<Software>();
        public void Add(Software software) => set.Add(software);
        public void Remove(Software software) => set.Remove(software);
        public bool Contains(Software software) => set.Contains(software);
        public int  Count { get { return set.Count; } }
        public void Clear() => set.Clear();
        public Software ElementAt(int index) => set.ElementAt(index); 
    }
    public class SizeException : Exception 
    {
        public SizeException(string message) : base(message) { }
    }

    abstract class Software : IComparable<Software>
    {
        private string name;
        private string developer;
        private int year;
        private double price;

        public Software()
        {
            this.Name = "N/A";
            this.Developer = "N/A";
            this.Year = 0;
            this.Price = 0;
        }

        public Software(string name) : this(name, "Microsoft", 2015, 199.99) { }

        public Software(string name, string developer, int year, double price)
        {
            this.Name = name;
            this.Developer = developer;
            this.Year = year;
            this.Price = price;
        }
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                if (value.Length < 1)
                {
                    throw new ArgumentException("Название программы не может состоять из 0 символов");
                }
                else
                {
                    this.name = value;
                }
            }
        }
        public int Year
        {
            get
            {
                return year;
            }
            set
            {
                if (value < 1980)
                {
                    throw new ArgumentException("Программа не могла быть создана в этом году.");
                }
                else
                {
                    this.year = value;
                }
            }
        }
        public double Price
        {
            get
            {
                return price;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Цена не может быть отрицательной.");
                }
                else
                {
                    this.price = value;
                }
            }
        }

        public string Developer
        {
            get
            {
                 return developer;           
            }
            set
            {
                if (value.Length < 1 )
                {
                    throw new ArgumentException("Название разработчиков не может состоять из 0 символов");
                }
                else
                {
                    this.developer = value;
                }
            }
        }
        abstract public void Proportions();

        public static bool operator <(Software a, Software b)
        {
            if (a.price < b.price) return true;
            else return false;
        }
        public static bool operator >(Software a, Software b)
        {
            if (a.price > b.price) return true;
            else return false;
        }
        public virtual int Years()
        {
            return (2022 - this.year);
        }

        public  int CompareTo(Software other)
        {
            if (this.Price > other.Price)
                return 1;
            if (this.Price < other.Price)
                return -1;
            return 0;
        }
    }
    abstract class Systemic : Software
    {
        private int system_Systemic_size;
        public Systemic(string name, string developer, int year, double price, int size) : base(name, developer, year, price) { }
        public int SizeSystemic
        {
            get { return system_Systemic_size; }
            set
            {
                if (value > 0 && value < 100)
                {
                    system_Systemic_size = value;
                }
                else throw new SizeException("Размер операционной системы не может быть таким"); ;
            }
        }
    }

    class Service : Software
    {
        private int system_Service_size;
        public Service() : this("WinRAR", "win.rar GmbH", 1995, 5, 20) { }
        public Service(string name, string developer, int year, double price,int size) : base(name,developer,year,price)
        {
            this.SizeService = size;          
        }
        public override void Proportions()
        {
            Console.WriteLine("Размер сервисного обеспечения : {0} МБ", SizeService);
        }
        public int SizeService
        {
            get { return system_Service_size; }
            set
            {
                if (value > 0 && value < 1000)
                {
                    system_Service_size = value;
                }
                else throw new SizeException("Размер сервисного обеспечения не может быть таким");
            }
        }
        public override string ToString()
        {
            return string.Format("Название продукта:{0},Разработчики:{1},Год выпуска:{2},Цена в долларах:{3},Размер сервисного обеспечения:{4} МБ", Name, Developer, Year, Price,SizeService);
        }
    }
    class Applied : Software
    {

        private int system_Applied_size;
        public override void Proportions()
        {
            Console.WriteLine("Размер служебного обеспечения : {0} МБ", SizeApplied);
        }
        public Applied() : this("Corel", "Corelus", 2010, 0, 500) { }
        public Applied(string name, string developer, int year, double price, int size) : base(name, developer, year, price)
        {
            this.SizeApplied = size;
        }
        public int SizeApplied
        {
            get { return system_Applied_size; }
            set
            {
                if (value > 0 && value < 10000)
                {
                    system_Applied_size = value;
                }
                else throw new SizeException("Размер служебного обеспечения не может быть таким");
            }
        }
        public override string ToString()
        {
            return string.Format("Название продукта:{0},Разработчики:{1},Год выпуска:{2},Цена в долларах:{3},Размер служебного обеспечения:{4} МБ", Name, Developer, Year, Price, SizeApplied);
        }
    }

    class OS : Systemic
    {
 
        public override void Proportions()
        {
            Console.WriteLine("Размер операционной системы : {0} МБ", SizeSystemic);
        }
        public OS() : this("Windows", "Windows 11", 2021, 199, 40) { }
        public OS(string name, string developer, int year, double price, int size) : base(name, developer, year, price, size)
        {
            this.SizeSystemic = size;
        }
        public override string ToString()
        {
            return string.Format("Название продукта:{0},Разработчики:{1},Год выпуска:{2},Цена в долларах:{3},Размер операционной системы:{4} МБ", Name, Developer, Year, Price, SizeSystemic);
        }
    }
    class Comparer<T> : IComparer<T>
        where T : Software
    {
        public int Compare(T x, T y)
        {
            if (x.Year> y.Year)
                return 1;
            if (x.Year < y.Year)
                return -1;
            return 0;
        }
    }
    internal class Program
    {
        static public void Log(Exception ex)
        {
            Console.WriteLine("Что-то пошло не так.");
            Console.WriteLine(ex.Message);
            using (StreamWriter sw = new StreamWriter("logs.txt", true))
            {
                sw.WriteLine(System.DateTime.Now.ToString());
                sw.WriteLine(ex.Message);
                sw.WriteLine(ex.StackTrace);
                sw.WriteLine(ex.InnerException);
                sw.WriteLine(ex.TargetSite);
                sw.WriteLine(ex.Data);
            }
        }
        static void Main(string[] args)
        {
            Software[] Softwares = new Software[3];
            string[] line = new string[5];
            string fileName;
            while (true)
            {
                try
                {
                    Console.Write("Введите имя файла: ");
                    fileName = Console.ReadLine();
                    using (StreamReader sr = new StreamReader(fileName))
                    {
                        line = sr.ReadLine().Split();
                        Softwares[0] = new Service(line[0], line[1], int.Parse(line[2]), double.Parse(line[3]), int.Parse(line[4]));
                        line = sr.ReadLine().Split();
                        Softwares[1] = new Applied(line[0], line[1], int.Parse(line[2]), double.Parse(line[3]), int.Parse(line[4]));
                        line = sr.ReadLine().Split();
                        Softwares[2] = new OS(line[0], line[1], int.Parse(line[2]), double.Parse(line[3]), int.Parse(line[4]));
                    }
                    break;
                }
                catch (FileNotFoundException ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine("Файл, имя которого вы ввели, не существует.\n" +
                        "Введите имя существующего файла.");
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (DirectoryNotFoundException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (UnauthorizedAccessException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (SizeException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (Exception ex)
                {
                    Log(ex);
                }
            }

            List<Software> List = new List<Software>(Softwares);
            List.Sort();
            foreach(Software Software in List)
            {
                Console.WriteLine(Software.Price);
            }

            Console.WriteLine();

            Comparer<Software> comparer = new Comparer<Software>();
            List.Sort(comparer);
            foreach (Software Software in List)
            {
                Console.WriteLine(Software.Year);
            }

            Console.WriteLine();

            List.Clear();
            List.AddRange(Softwares);
            List.Add(Softwares[2]);
            List.RemoveAt(1);
            Console.WriteLine(List.Contains(Softwares[1]));
            foreach (Software Software in List)
            {
                Console.WriteLine(Software.ToString());
            }

            Console.WriteLine();

            SoftwareContainer<Software> softwareContainer = new SoftwareContainer<Software>();
            softwareContainer.Add(Softwares[0]);
            softwareContainer.Add(Softwares[1]);
            softwareContainer.Add(Softwares[2]);
            for (int i = 0; i < softwareContainer.Count; i++)
            {
                Console.WriteLine(softwareContainer.ElementAt(i));
            }
            Console.WriteLine(softwareContainer.Contains(Softwares[0]));
            softwareContainer.Remove(Softwares[0]);
            for (int i = 0; i < softwareContainer.Count; i++)
            {
                Console.WriteLine(softwareContainer.ElementAt(i));
            }
            softwareContainer.Clear();
            Console.WriteLine(softwareContainer.Count);
            Console.ReadKey();
        }
    }
}
