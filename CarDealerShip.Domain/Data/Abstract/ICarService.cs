using CarDealerShip.Domain.DomainModels;
using System;
using System.Collections.Generic;

namespace CarDealerShip.Domain.Data.Abstract
{
    public interface ICarService
    {
        IEnumerable<Car> GetAll();
        IEnumerable<Car> GetCarsByYear(int year);
        IEnumerable<Car> GetCarsByMake(string make);
        Car Get(Guid Id);
        void Remove(Guid Id);
        bool Update(Car item);
        Car Add(Car item);
    }
}
