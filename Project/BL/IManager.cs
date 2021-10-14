using System;
using System.Collections.Generic;
using Project.Domain;

namespace Project.BL
{
    public interface IManager
    {
        // GetX, GetAllXs, GetXsBy... en AddX
        public Car GetCar(int numberplate);
        public IEnumerable<Car> GetAllCars();
        public IEnumerable<Car> GetCarsBy(Fuel fuel);
        public Car AddCar(long? purchasePrice, string brand, Fuel fuel, short seats, double mileage, Garage garage);
        public Driver GetDriver(int socialnumber);
        public IEnumerable<Driver> GetAllDrivers();
        public IEnumerable<Driver> GetAllDriversBy(string? name, DateTime? dateofbirth);
        public Driver AddDriver(string firstName, string lastName,DateTime dateOfBirth);
    }
}