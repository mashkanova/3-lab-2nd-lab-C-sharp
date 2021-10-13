using System;

namespace ConsoleApp1
{
    internal partial class Car
    {
        static int count = 0;

        private readonly uint _fooSerialNumber = 0;
        private uint id;
        public uint Id
        {
            get
            {
                return id;
            }
            set
            {
                id = value;
            }
        }
        private string brand;
        public string Brand
        {
            get
            {
                return brand;
            }
            set
            {
                brand = value;
            }
        }
        private string model;
        public string Model
        {
            get
            {
                return model;
            }
            protected set
            {
                model = value;
            }
        }

        private int year;
        public int Year
        {
            get
            {
                return year;
            }
            set
            {
                year = value;
            }
        }

        private const string color = "blue";
        public string Color
        {
            get
            {
                return color;
            }

        }

        private int price;
        public int Price
        {
            get
            {
                return price;
            }
            set
            {
                price = value;
            }
        }
        private int regNum;
        public int RegNum
        {
            get
            {
                return regNum;
            }
            set
            {
                regNum = value;
            }
        }

        public Car(string br, string m, int y, int pr, int num)
        {

            brand = br;
            model = m;
            year = y;
            price = pr;
            regNum = num;
            count++;
            id = (uint)GetHashCode() + _fooSerialNumber;
            /*(uint)t.GetHashCode() + (uint)a.GetHashCode() +  (uint)y.GetHashCode() + (uint)pa.GetHashCode() + (uint)pr.GetHashCode() + (uint)ty.GetHashCode() + _fooSerialNumber;*/
            _fooSerialNumber++;
        }

        public Car()
        {
            brand = null;
            model = null;
            year = 0;
            price = 0;
            regNum = 0;
            count++;
            id = (uint)GetHashCode() + _fooSerialNumber;
            /*(uint)t.GetHashCode() + (uint)a.GetHashCode() +  (uint)y.GetHashCode() + (uint)pa.GetHashCode() + (uint)pr.GetHashCode() + (uint)ty.GetHashCode() + _fooSerialNumber;*/
            _fooSerialNumber++;
        }

        static Car()
        {
            Console.WriteLine("Статический конструктор сработал)");
        }

        public Car(string m, int y, int pr, int num, string br = "Mercedes")
        {
            model = m;
            year = y;
            price = pr;
            regNum = num;
            count++;
            id = (uint)GetHashCode() + _fooSerialNumber;
            /*(uint)t.GetHashCode() + (uint)a.GetHashCode() +  (uint)y.GetHashCode() + (uint)pa.GetHashCode() + (uint)pr.GetHashCode() + (uint)ty.GetHashCode() + _fooSerialNumber;*/
            _fooSerialNumber++;
        }
        public void ChangePrice(ref int price)
        {
            price = price * 2;
        }
        public void CompareBrand(string name1, out string yes_no)
        {
            int a = string.Compare(this.Brand, name1);
            if (a == 0)
            {
                yes_no = "да";
            }
            else
            {
                yes_no = "нет";
            }
        }
        public static void DisplayCounter()
        {
            Console.WriteLine($"Создано {count} объектa(ов) Book");
        }
        public void GetInfo()
        {
            Console.WriteLine("Information:");
            Console.WriteLine($"ID:{id} ");
            Console.WriteLine($"brand: {brand}");
            Console.WriteLine($"model: {model}");
            Console.WriteLine($"year: {year}");
            Console.WriteLine($"color: {Color}");
            Console.WriteLine($"price: {price}");
            Console.WriteLine($"Registration number: {regNum}");
        }
        public override string ToString()
        {
            return base.ToString() + ": " + Id.ToString() + "  " + Brand.ToString() + "  " + Model.ToString() + "  " + Color.ToString() + "  " + Year.ToString() + "  " + RegNum.ToString() + "  " + Price.ToString();
        }
        //  public override int GetHashCode()
        //{
        //  return HashCode.Combine(Title, Authors, Year, Page, Prace, Type);
        //}
        public override bool Equals(object obj)
        {
            return obj is Car car &&
                   brand == car.brand &&
                   model == car.model &&
                   regNum == car.regNum &&
                   price == car.price;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Car car1 = new Car("Cadillac", " Escalade", 2021, 10000000, 7499);
            Car car2 = new Car("Honda", " Accord", 2018, 2135000, 2354);
            Car car3 = new Car("Toyota", " Camry", 2020, 1790000, 1547);
            Car car4 = new Car();
            var car5 = new Car("Cadillac", " CTS-V", 2016, 6500000, 2280);
            car4.Price = 5542000;

            int newPrace = car1.Price;
            car1.ChangePrice(ref newPrace);
            car1.Price = newPrace;



            Car[] arr = { car1, car2, car3, car5 };

            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i].Brand == "Cadillac")
                {
                    Console.WriteLine("Машины марки Cadillac" + arr[i].Model);
                }
            }

            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i].Year > 2019)
                {
                    Console.WriteLine("Автомобили в эксплуатации более двух лет:" +arr[i].Brand + arr[i].Model + " " + arr[i].Year);
                }
            }
            car1.GetInfo();
            car2.GetInfo();
            car3.GetInfo();
            car4.GetInfo();
            car5.GetInfo();
        }
    }
}
