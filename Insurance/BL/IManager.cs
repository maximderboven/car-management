﻿using System;
using System.Collections.Generic;
using Insurance.Domain;

namespace Insurance.BL
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
        public IEnumerable<Garage> GetAllGarages();
        public IEnumerable<Driver> GetAllDriversBy(string? name, DateTime? dateofbirth);
        public Driver AddDriver(string firstName, string lastName,DateTime dateOfBirth);
        public IEnumerable<Car> GetAllCarsWithGarage();
        public IEnumerable<Driver> GetAllDriversWithCars();
        public void AddRental(Rental rental);
        public void RemoveRental(int socialnumber, int numberplate);
        public IEnumerable<Driver> GetDriversOfCar(int numberplate);
    }
}