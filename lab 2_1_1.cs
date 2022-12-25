using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp8
{
    internal class OS
    {
        public string name;
        private string developer;
        private int year;
        private double price;
        
        public OS()
        {
            this.name = "N/A";
            this.developer = "N/A";
            this.year = 0;
            this.price = 0;
        }

        public OS(string name) : this(name, "Microsoft", 2015,199.99){}
        
        public  OS(string name,string developer,int year,double price)
        {
            this.name = name;
            this.developer = developer;
            this.year = year;
            this.price = price;
        }
        public double Check_Price
        {
            get
            {
                return this.price;
            }
            set
            {
                if (value < 0)
                {
                    this.price = 0;
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
                return this.Developer;
            }
            set
            {
                if (value.Length<1&&value.Length >40)
                {
                    this.developer = "";
                }
                else
                {
                    this.developer = value;
                }
            }
        }
        public static bool operator <(OS a, OS b)
        {
            if (a.price < b.price) return true;
            else return false;
        }
        public static bool operator>(OS a, OS b)
        {
            if (a.price > b.price) return true;
            else return false;
        }
        public int Years()
        {
            return (2022 - this.year);
        }
        public string Name()
        {
            return this.name;
        }
        public override string ToString()
        {
            return string.Format("{0}, {1}, {2}, {3}",name,developer,year,price);
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("*** Операционные системы ***");
            OS Windows_10 = new OS();
            OS Windows_11_Home = new OS("Windows 11 Home","Microsoft",2021,139.99);
            OS Windows_11_Pro = new OS("Windows 11 Pro", "Microsoft", 2021, 199.99);
            Console.WriteLine(Windows_10.ToString());
            Windows_10.Developer = "";
            Windows_10.Check_Price = 199.99;
            Console.WriteLine(Windows_10.ToString());
            Console.WriteLine(Windows_11_Home.ToString());
            Console.WriteLine(Windows_11_Pro.ToString());
            Console.WriteLine(Windows_11_Pro.Years());
            Console.WriteLine(Windows_11_Pro.Name());
            Windows_10.Check_Price = 149.99;
            Windows_11_Home.Check_Price = 249.99;
            Windows_11_Home.Developer = "Soft";
            Console.WriteLine(Windows_10.ToString());
            Console.WriteLine(Windows_11_Home.ToString());
            if (Windows_10 > Windows_11_Home) Console.WriteLine("Windows 10 дороже");
            if (Windows_10 < Windows_11_Home) Console.WriteLine("Windows 11 дороже");
            Console.ReadKey();
        }
    }
}
