using CarDealerShip.Domain.Data.Abstract;
using CarDealerShip.Domain.DomainModels;
using System;
using System.Collections.Generic;

namespace CarDealerShip.Service
{
    public class CarService : ICarService
    {
        private List<Car> cars = new List<Car>();
        public CarService()
        {
            PopulateInitialData();
        }

        public IEnumerable<Car> GetAll()
        {
            return cars;
        }

        public IEnumerable<Car> GetCarsByYear(int year)
        {
            return cars.FindAll(c => c.Year == year);
        }

        public IEnumerable<Car> GetCarsByMake(string make)
        {
            return cars.FindAll(c => c.Make == make);
        }

        public Car Get(Guid id)
        {
            return cars.Find(c => c.Id == id);
        }

        public Car Add(Car item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }

            // a new GUID is assigned every time a new item is added.
            item.Id = System.Guid.NewGuid();
            cars.Add(item);
            return item;
        }
               
        public void Remove(Guid id)
        {
             cars.RemoveAll(c => c.Id == id);
        }

        public bool Update(Car item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }

            int index = cars.FindIndex(c => c.Id == item.Id);
            if (index == -1)
            {
                return false;
            }
            cars.RemoveAt(index);
            cars.Add(item);

            return true;
        }


        private void PopulateInitialData()
        {
            Add(new Car { Make = "Infiniti", Model = "FX 35", Year = 2009, Trim = "Crossover" });
            Add(new Car { Make = "Toyota", Model = "RAV44", Year = 2005, Trim = "Sport" });
            Add(new Car { Make = "Audi", Model = "A5", Year = 2010, Trim = "Convertible" });
        }
    }
}
