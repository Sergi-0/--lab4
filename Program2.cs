using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab4_3
{
    public class Car
    {
        public string Name { get; set; }
        public int ProductionYear { get; set; }
        public int MaxSpeed { get; set; }
        public Car(string name, int productionyear, int maxspeed)
        {
            Name = name;
            ProductionYear = productionyear;
            MaxSpeed = maxspeed;
        }
    }

    public class CarCatalog: IEnumerable<Car>
    {
        private Car[] cars;
        public CarCatalog(params Car[] Arg)
        {
            cars = new Car[Arg.Length];
            for(int i = 0; i < cars.Length; i++)
            {
                this.cars[i] = Arg[i];
            }
        }

        public IEnumerator<Car> GetEnumerator()
        {
            foreach (var car in cars)
            {
                yield return car;
            }
        }

        public IEnumerable<Car> GetEnumeratorReverse()
        {
            for (int i = cars.Length - 1; i >= 0; i--)
            {
                yield return cars[i];
            }
        }

        public IEnumerable<Car> GetEnumeratorByProductionYear(int year)
        {
            foreach (var car in cars)
            {
                if (car.ProductionYear == year)
                {
                    yield return car;
                }
            }
        }

        public IEnumerable<Car> GetEnumeratorByMaxSpeed(int maxSpeed)
        {
            foreach (var car in cars)
            {
                if (car.MaxSpeed >= maxSpeed)
                {
                    yield return car;
                }
            }
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    internal class Program2
    {
        static void Main(string[] args)
        {
            Car[] cars = new Car[]
            {
                new Car ("Toyota",2015,180),
                new Car ("Ford", 2012, 160),
                new Car ("Honda", 2018, 200),
                new Car ("Nissan", 2010, 140),
                new Car ("BMW", 2016, 220)
            };

            CarCatalog catalog = new CarCatalog(cars);

            foreach (var car in catalog)
            {
                Console.WriteLine($"{car.Name} - {car.ProductionYear} - {car.MaxSpeed}");
            }

            foreach (var car in catalog.GetEnumeratorReverse())
            {
                Console.WriteLine($"{car.Name} - {car.ProductionYear} - {car.MaxSpeed}");
            }

            foreach (var car in catalog.GetEnumeratorByProductionYear(2015))
            {
                Console.WriteLine($"{car.Name} - {car.ProductionYear} - {car.MaxSpeed}");
            }

            foreach (var car in catalog.GetEnumeratorByMaxSpeed(180))
            {
                Console.WriteLine($"{car.Name} - {car.ProductionYear} - {car.MaxSpeed}");
            }
        }
    }
}
