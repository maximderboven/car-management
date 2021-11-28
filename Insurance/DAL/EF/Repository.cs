using System;
using System.Collections.Generic;
using System.Linq;
using Insurance.Domain;
using Microsoft.EntityFrameworkCore;

namespace Insurance.DAL.EF
{
    public class Repository : IRepository
    {
        private InsuranceDbContext _context;

        public Repository()
        {
            _context = new InsuranceDbContext();
        }

        public Car ReadCar(int numberplate)
        {
            //return _context.Cars.Find(numberplate);
            return _context.Cars.Single(c => c.NumberPlate.Equals(numberplate));
        }

        public IEnumerable<Car> ReadAllCars()
        {
            return _context.Cars.AsEnumerable();
        }

        public IEnumerable<Car> ReadCarsOf(Fuel fuel)
        {
            return _context.Cars.Where(car => car.Fuel.Equals(fuel)).AsEnumerable();
        }

        public void CreateCar(Car car)
        {
            _context.Cars.Add(car);
            _context.SaveChanges();
        }

        public Driver ReadDriver(int socialnumber)
        {
            return _context.Drivers.Single(d=>d.SocialNumber.Equals(socialnumber));
        }

        public IEnumerable<Driver> ReadAllDrivers()
        {
            return _context.Drivers.AsEnumerable();
        }

        public IEnumerable<Garage> ReadAllGarages()
        {
            return _context.Garages.AsEnumerable();
        }

        public IEnumerable<Driver> ReadDriversBy(string? name, DateTime? dateofbirth)
        {
            IQueryable<Driver> filteredList = _context.Drivers;
            if (!string.IsNullOrEmpty(name))
            {
                filteredList = filteredList.Where(d => (d.FirstName + " " + d.LastName).ToLower().Contains(name.ToLower()));
            }

            if (!dateofbirth.Equals(DateTime.MinValue))
            {
                filteredList = filteredList.Where(d => dateofbirth.Equals(d.DateOfBirth.Date));
            }

            return filteredList;

            /*/return _context.Drivers.Where(d =>
                ((name == "") || (d.FirstName + " " + d.LastName).ToLower().Contains(name.ToLower()))
                && (dateofbirth.Equals(default(DateTime)) || dateofbirth.Equals(d.DateOfBirth.Date))); */
        }

        public void CreateDriver(Driver driver)
        {
            _context.Drivers.Add(driver);
            _context.SaveChanges();
        }

        public IEnumerable<Car> ReadAllCarsWithGarage()
        {
            return _context.Cars.Include(c => c.Garage);
        }

        public IEnumerable<Driver> ReadAllDriversWithCars()
        {
            return _context.Drivers.Include(d => d.Cars).ThenInclude(r => r.Car);
        }

        public void CreateRental(Rental rental)
        {
            _context.Rentals.Add(rental);
            _context.SaveChanges();
        }

        public void DeleteRental(int socialnumber, int numberplate)
        {
            var rental = _context.Rentals
                .Where(r => r.Car.NumberPlate == numberplate)
                .Single(r => r.Driver.SocialNumber == socialnumber);
            _context.Rentals.Remove(rental);
            _context.SaveChanges();
        }

        public IEnumerable<Driver> ReadDriversOfCar(int numberplate)
        {
            var car = _context.Cars.Include(c => c.Drivers).ThenInclude(r => r.Driver)
                .ThenInclude(d => d.Cars).Single(c => c.NumberPlate == numberplate);
            return car.Drivers.Select(r => r.Driver).ToList();
        }
    }
}