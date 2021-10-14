#nullable enable
using System;
using System.Collections.Generic;
using Project.Domain;
using Project.DAL;

namespace Project.BL
{
    public class Manager : IManager
    {
        private readonly IRepository _repo;
        public Manager()
        {
            _repo = new InMemoryRepository();
        }

        public Car GetCar(int numberplate)
        {
            return _repo.ReadCar(numberplate);
        }

        public IEnumerable<Car> GetAllCars()
        {
            return _repo.ReadAllCars();
        }

        public IEnumerable<Car> GetCarsBy(Fuel fuel)
        {
            return _repo.ReadCarsOf(fuel);
        }

        public Car AddCar(long? purchasePrice, string brand, Fuel fuel, short seats, double mileage, Garage garage)
        {
            var car = new Car(purchasePrice, brand, fuel, seats, mileage, garage);
            _repo.CreateCar(car);
            return car;
        }

        public Driver GetDriver(int socialnumber)
        {
            return _repo.ReadDriver(socialnumber);
        }

        public IEnumerable<Driver> GetAllDrivers()
        {
            return _repo.ReadAllDrivers();
        }

        public IEnumerable<Driver> GetAllDriversBy(string? name, DateTime? dateofbirth)
        {
            return _repo.ReadDriversBy(name,dateofbirth);
        }

        public Driver AddDriver(string firstName, string lastName,DateTime dateOfBirth)
        {
            var driver = new Driver(firstName,lastName,dateOfBirth);
            _repo.CreateDriver(driver);
            return driver;
        }
    }
}