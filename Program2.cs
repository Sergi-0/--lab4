using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab4_2
{
    public class Car
    {
        public string Name { get; set; }
        public int ProductionYear { get; set; }
        public int MaxSpeed { get; set; }
        public Car(string name, int productionyear, int maxspeed) {
            Name = name;
            ProductionYear = productionyear;
            MaxSpeed = maxspeed;
        }
    }

    public class CarComparer : IComparer<Car>
    {
        private string sortnum;

        public CarComparer(string sortnum)
        {
            this.sortnum = sortnum;
        }

        public int Compare(Car x, Car y)
        {
            switch (sortnum)
            {
                case "Name":
                    return string.Compare(x.Name, y.Name);
                case "ProductionYear":
                    return x.ProductionYear.CompareTo(y.ProductionYear);
                case "MaxSpeed":
                    return x.MaxSpeed.CompareTo(y.MaxSpeed);
                default:
                    throw new ArgumentException("Неверный параметр сравнения");
            }
        }
        internal class Program2
        {
            static void Main(string[] args)
            {
                Car car1 = new Car("bmw", 1991, 228);
                Car car2 = new Car("gaz", 1992, 229);
                Car car3 = new Car("audi", 2026, 666);
                Car car4 = new Car("volvo", 3026, 999);
                Car[] cars = new Car[4];
                cars[0] = car1;
                cars[1] = car2;
                cars[2] = car3;
                cars[3] = car4;
                Array.Sort(cars, new CarComparer("Name"));
                foreach (Car car in cars) {
                    Console.WriteLine($"{car.Name} ({car.ProductionYear}) - {car.MaxSpeed}");
                }

                Array.Sort(cars, new CarComparer("ProductionYear"));
                foreach (Car car in cars)
                {
                    Console.WriteLine($"{car.Name} ({car.ProductionYear}) - {car.MaxSpeed}");
                }

                Array.Sort(cars, new CarComparer("MaxSpeed"));
                foreach (Car car in cars)
                {
                    Console.WriteLine($"{car.Name} ({car.ProductionYear}) - {car.MaxSpeed}");
                }
            }
        }
    }
}
