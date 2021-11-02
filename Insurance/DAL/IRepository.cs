using System;
using System.Collections.Generic;
using Insurance.Domain;

namespace Insurance.DAL
{
    public interface IRepository
    {
        public Car ReadCar(int numberplate);
        public IEnumerable<Car> ReadAllCars();
        public IEnumerable<Car> ReadCarsOf(Fuel fuel);
        public void CreateCar(Car car);
        
        public Driver ReadDriver(int socialnumber);
        public IEnumerable<Driver> ReadAllDrivers();
        public IEnumerable<Garage> ReadAllGarages();
        public IEnumerable<Driver> ReadDriversBy(string? name, DateTime? dateofbirth);
        public void CreateDriver(Driver driver);
        
        
    }
}