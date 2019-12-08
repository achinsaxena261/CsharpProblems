using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTestsApp
{
    public class Comparable
    {
        public class Car
        {
            public string Name { get; set; }
            public int MaxSpeed { get; set; }

            //public int CompareTo(object obj)
            //{
            //    Car car = obj as Car;
            //    return MaxSpeed.CompareTo(car.MaxSpeed);
            //}
        }

        class CarComparer : IComparer<Car>
        {
            public int Compare(Car x, Car y)
            {
                return x.MaxSpeed.CompareTo(y.MaxSpeed);
            }
        }

        public static void TestComparable()
        {
            Car[] cars = new Car[3]
            {
                new Car(){ Name="Maruti", MaxSpeed=180},
                new Car(){ Name="Hyundai", MaxSpeed=250},
                new Car(){ Name="Suzuki", MaxSpeed=220}
            };
            Array.Sort(cars, (Car x, Car y) => x.MaxSpeed.CompareTo(y.MaxSpeed));
            Array.ForEach(cars, (e) => { Console.Write("{0} ", e.Name); });
        }
    }
}
