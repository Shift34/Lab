using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp8
{
    abstract class Software
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
                if (value.Length < 0 && value.Length > 40)
                {
                    this.name = "";
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
                    this.year = 1980;
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
                 return developer;           
            }
            set
            {
                if (value.Length < 1 && value.Length > 40)
                {
                    this.developer = "";
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
                else system_Systemic_size = 0;
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
                else system_Service_size = 0;
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
                else system_Applied_size = 0;
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
            Console.WriteLine("Размер операционной системы : {0} ГБ", SizeSystemic);
        }
        public OS() : this("Windows", "Windows 11", 2021, 199, 40) { }
        public OS(string name, string developer, int year, double price, int size) : base(name, developer, year, price, size)
        {
            this.SizeSystemic = size;
        }
        public override string ToString()
        {
            return string.Format("Название продукта:{0},Разработчики:{1},Год выпуска:{2},Цена в долларах:{3},Размер операционной системы:{4} ГБ", Name, Developer, Year, Price, SizeSystemic);
        }
    }

}
